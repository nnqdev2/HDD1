using HDD.ApplicationCore.Entities;
using HDD.Infrastructure.Services;
using HDD.Web.Interfaces;
using HDD.Web.Services;
using HDD.Web.ViewModels;
using Microsoft.Extensions.Options;

namespace HDD.Web.Services
{
    public class VinService : IVinService
    {
        private IEmailService _emailService;
        private ILogger<VinService> _logger;
        private readonly EmailOptions _options;
        private readonly IHDDRepository _dataService;
        public VinService(ILogger<VinService> logger, IEmailService emailService, IOptions<EmailOptions> options
            , IHDDRepository dataService)
        {
            _logger = logger;
            _emailService = emailService;
            _options = options.Value;
            _dataService = dataService;
        }
        public async Task<bool> IsVinRegulated(string vin)
        {
            return await _dataService.IsVinRegulated(vin);
        }
        public async Task<bool> IsPlateRegulated(string plate)
        {
            return await _dataService.IsPlateRegulated(plate);
        }
        public async Task<bool> IsPlateEligibleToClaim(string plate)
        {
            var vin = await _dataService.GetVin(plate);
            return await IsVinEligibleToClaim(vin);
        }

        public async Task<bool> IsVinEligibleToClaim(string vin)
        {
            if (await _dataService.IsVinRegulated(vin) && !await _dataService.IsVinClaimed(vin))
                return true;
            return false;
        }
        public async Task ClaimAVin(string ownerId, string vin, string primaryOwner)
        {
            var ownersVin = new OwnersVin();
            ownersVin.OwnerId = ownerId;
            ownersVin.Vin = vin;
            ownersVin.UpdateDateTime = DateTime.Now;
            ownersVin.PrimaryOwner = primaryOwner;
            ownersVin.OwnerStatus = true;
            ownersVin.UpdateDateTime = DateTime.Now;
            await _dataService.InsertOwnersVin(ownersVin);
        }
        public RetrofitApplicationDmvccddata GetRetrofitApplicationDmvccddata(string vin)
        {
            var rad = _dataService.GetRetrofitApplicationDmvccddata(vin);
            //var da =  GetDocumentsAction(vin);
            //foreach (var d in da)
            //{
            //    rad.DocumentActions.Add(d);
            //}
            return rad;
        }

        public IList<DocumentAction> GetDocumentsAction(string vin)
        {
            var vehicleDocuments = _dataService.GetVehicleDocuments(vin);

            IList<DocumentAction> documentActions = vehicleDocuments.Select(x => new DocumentAction
            {
                Vin = vin,
                DocumentPath = x.DocumentPath,
                DocumentName = x.DocumentPath,
                IsDelete = false
            }).ToList();
            return documentActions;
        }



        //bool IVinService.IsPlateEligibleToClaim(string plate)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IVinService.IsVinEligibleToClaim(string vin)
        //{
        //    throw new NotImplementedException();
        //}
    }
} 