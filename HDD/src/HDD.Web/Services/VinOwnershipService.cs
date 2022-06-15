using HDD.ApplicationCore.Entities;
using HDD.Infrastructure.Identity;
using HDD.Infrastructure.Services;
using HDD.Web.Interfaces;
using HDD.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Text;

namespace HDD.Web.Services
{
    public class VinOwnershipService : IVinOwnershipService
    {
        private IEmailService _emailService;
        private ILogger<VinOwnershipService> _logger;
        private readonly EmailOptions _options;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHDDRepository _hddRepository;
        public VinOwnershipService(ILogger<VinOwnershipService> logger, IEmailService emailService, IOptions<EmailOptions> options
            , UserManager<ApplicationUser> userManager, IHDDRepository hddRepository)
        {
            _logger = logger;
            _emailService = emailService;
            _options = options.Value;
            _userManager = userManager;
            _hddRepository = hddRepository;
        }

        public async Task<bool> IsIncomingPrimaryOwner(string vin, string plate, string registeredZip)
        {
            var x = await _hddRepository.IsIncomingPrimaryOwner(vin, plate, registeredZip);
            return x;
        }
        public async Task<bool> IsIncomingSecondaryOwner(string email)
        {
            var x = await _hddRepository.IsIncomingSecondaryOwner(email);
            return x;
        }
        public async Task AssignOwnershipToVin(string userId, string vin, bool isPrimary)
        {
            var ownersVin = new OwnersVin();
            ownersVin.OwnerId = userId;
            ownersVin.Vin = vin;
            ownersVin.UpdateDateTime = DateTime.Now;
            ownersVin.OwnerStatus = true;
            ownersVin.PrimaryOwner = isPrimary?"yes":"no";
            await _hddRepository.InsertOwnersVin(ownersVin);
        }

        public async Task AssignVinsToSecondaryOwnerAsync(ApplicationUser secondaryOwner)
        {
            await _hddRepository.AssignVinsToSecondaryOwnerAsync(secondaryOwner);
        }

        public async Task<ApReturnCodeMessage>AssignVinToPrimaryOwnerAsync(ApplicationUser primaryOwner)
        {
            var apReturnCodeMessage = await _hddRepository.AssignVinToPrimaryOwnerAsync(primaryOwner.VIN, primaryOwner.Id);
            return apReturnCodeMessage;
        }
        public void SendPermissionNotificationEmail(string requestEmail, string vin, bool isApproved)
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;
            sb.Append(now.ToLongDateString() + " " + now.ToLongTimeString() + "</br>");
            sb.Append("click here to approve https://localhost:7137/op/1/999/876  </br>");
            sb.Append("click here to deny    https://localhost:7137/op/0/999/876  </br>");
            throw new NotImplementedException();
        }

        public void SendRequestPermissionEmail(string primaryEmail, string requestEmail, string vin)
        {
            StringBuilder sb = new StringBuilder();
            DateTime now = DateTime.Now;
            sb.Append(now.ToLongDateString() + " " + now.ToLongTimeString() + "\r\n\r\n");
            sb.Append("click here to approve https://localhost:7137/op/1/999/876  \r\n\r\n");
            sb.Append("click here to deny    https://localhost:7137/op/0/999/876  \r\n\r\n");
            _emailService.SendEmail(_options.AdminEmail, "ngaquan4@gmail.com", "request secondary permission emal", sb.ToString(), false);
        }



        public async Task<IEnumerable<VinOwnership>> GetPrimaryOwnershipVins(string ownerId)
        {
            var ownersVins = _hddRepository.GetPrimaryOwnersVins(ownerId);
            IList<VinOwnership> vinOwnerships = new List<VinOwnership>();
            foreach (OwnersVin ownerVin in ownersVins)
            {
                var user = await _userManager.FindByIdAsync(ownerVin.OwnerId);
                var vinOwnership = new VinOwnership
                {
                    OwnerId = ownerVin.OwnerId,
                    Vin = ownerVin.Vin,
                    PrimaryOwner = ownerVin.PrimaryOwner,
                    OwnerStatus = ownerVin.OwnerStatus,
                    UpdateDateTime = ownerVin.UpdateDateTime,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                vinOwnerships.Add(vinOwnership);

            }

            return vinOwnerships;
        }

        public async Task<IList<EmailInfo>> GetSecondaryOwners(string ownerId)
        {
            //var secondaryOwnersVins = await _hddRepository.GetSecondaryOwnerIds("aaf7efd0-ae13-48e9-9d72-83e713ef8100");
            var secondaryOwnersVins = await _hddRepository.GetSecondaryOwnerIds(ownerId);
            //var secondaryOwnerIds = secondaryOwnersVins.GroupBy(o => o.OwnerId).Select(s => s.First());
            var distinctSecondaryOwnersVins = secondaryOwnersVins.GroupBy(o => new { o.OwnerId }).Select(g => g.First());
            IList<EmailInfo> emailInfos = new List<EmailInfo>();
            foreach (var secondaryOwnersVin in distinctSecondaryOwnersVins)
            {
                var user = await _userManager.FindByIdAsync(secondaryOwnersVin.OwnerId);
                var emailInfo = new EmailInfo
                {
                    //OwnerId = ownerId,
                    SecondaryOwnerId = secondaryOwnersVin.OwnerId,
                    Email = user.Email,
                    //FirstName = user.FirstName,
                    //LastName = user.LastName
                };
                emailInfos.Add(emailInfo);
            }
            return emailInfos;
        }

        public async Task<IList<VinSecondaryOwnerAction>> GetVinsForSecondaryOwnershipAssignment(string ownerId, string secondaryOwnerId)
        {
            var VinsForSecondaryOwnerAssignment = await _hddRepository.GetVinsForSecondaryOwnershipAssignment(ownerId, secondaryOwnerId);
            IList<VinSecondaryOwnerAction> vinSecondaryOwnerActions = new List<VinSecondaryOwnerAction>();
            foreach (var vin in VinsForSecondaryOwnerAssignment)
            {
                var vinSecondaryOwnerAction = new VinSecondaryOwnerAction
                {
                    Vin = vin.Vin,
                    SecondaryOwnerId = secondaryOwnerId,
                    SecondaryOwnerEmail = null,
                    Assigned = false
                };
                vinSecondaryOwnerActions.Add(vinSecondaryOwnerAction);
            }
            return vinSecondaryOwnerActions;
        }

        public async Task<ApReturnCodeMessage> ValidatePrimaryOwnerAtRegistrationAsync(string vin, string plate, string zip)
        {
            var apReturnCodeMessage = await _hddRepository.ValidatePrimaryOwnerAtRegistrationAsync(vin, plate, zip);
            return apReturnCodeMessage;
        }

        public async Task<bool> IsSecondaryOwnerEmailAsync(string email)
        {
            var apReturnCodeMessage = await _hddRepository.ValidateSecondaryOwnerAtRegistrationAsync(email);
            return  (apReturnCodeMessage.ReturnCode > 0 ? true : false);
        }







        //public async Task<IEnumerable<VinOwnership>> GetVinsAndSecondaryOwners(string ownerId)
        //{
        //    var secondaryOwnersVins = await _hddRepository.GetSecondaryOwnerIds(ownerId);

        ////public string? OwnerId { get; set; }
        ////public string? Vin { get; set; }
        ////public string? PrimaryOwner { get; set; }
        ////public bool? OwnerStatus { get; set; }
        ////public DateTime? UpdateDateTime { get; set; }
        //////public string? Certified { get; set; }
        ////public string? Email { get; set; }
        ////public string? FirstName { get; set; }
        ////public string? LastName { get; set; }
        ////public string? Title { get; set; }

        //    IList<VinOwnership> vinOwnerships = new List<VinOwnership>();
        //    foreach (var secondaryOwnersVin in secondaryOwnersVins)
        //    {
        //        var secondaryOwnerUserInfo = await _userManager.FindByIdAsync(secondaryOwnersVin.OwnerId);
        //        var vinOwnership = new VinOwnership
        //        {
        //            //OwnerId = ownerId,
        //            SecondaryOwnerId = secondaryOwnersVin.OwnerId,
        //            Email = secondaryOwnerUserInfo.Email,
        //            //FirstName = user.FirstName,
        //            //LastName = user.LastName
        //        };
        //        emailInfos.Add(emailInfo);
        //    }
        //    return null;
        //}


    }
}
