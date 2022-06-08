using HDD.Infrastructure.Data;
using HDD.ApplicationCore.Entities;
using HDD.Web.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using HDD.Web.ViewModels;
using System.Data;
using HDD.Infrastructure.Identity;

namespace HDD.Web.Services
{
    public class HDDRepository : IHDDRepository
    {

        private HDDDbContext _context;
        private ILogger<HDDRepository> _logger;
        public HDDRepository(ILogger<HDDRepository> logger, HDDDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> IsVinRegulated(string vin)
        {
            var efound = await _context.RetrofitCertifications.Where(a => a.Vin == vin && a.Vinstatus == "A").CountAsync();
            return efound > 0;
        }
        public async Task<bool> IsPlateRegulated(string plate)
        {
            var efound = await (from ra in _context.RetrofitCertifications
                                join d in _context.Dmvccddata on ra.Vin equals d.Vin
                                where d.Plate == plate && d.Vin == ra.Vin && ra.Vinstatus == "A"
                                select new { d.Plate, ra.Vin, ra.Vinstatus }
                          ).CountAsync();
            return efound > 0;
        }
        public async Task<bool> IsVinClaimed(string vin)
        {
            var efound = await _context.OwnersVins.Where(a => a.Vin == vin && a.OwnerStatus == true).CountAsync();
            return efound > 0;
        }
        public async Task<string> GetVin(string plate)
        {
            var vin = await (from a in _context.Dmvccddata
                       where a.Plate == plate
                       select a.Vin.ToString()).FirstOrDefaultAsync();
            return vin;
        }
        public async Task<bool> IsIncomingPrimaryOwner(string vin, string plate, string registeredZip)
        {
            var count = await _context.Dmvccddata.Where(a => a.Vin == vin && a.Plate == plate && a.Zip == registeredZip)
                .CountAsync();
            return count > 0;
        }
        public async Task<bool> IsIncomingSecondaryOwner(string email)
        {
            var efound = await _context.SecondaryOwnerAssignments.Where(a => a.IncomingSecondaryOwnerEmail == email).CountAsync();

            return efound > 0;
        }

        public async Task InsertOwnersVin(OwnersVin ownersVin)
        {
            await _context.AddAsync(ownersVin);
            await _context.SaveChangesAsync();
        }
        public async Task<IList<SecondaryOwnerAssignment>> GetSecondaryOwnerAssignments(string incomingSecondaryOwnerEmail)
        {
            var results = await _context.SecondaryOwnerAssignments.Where(a => a.IncomingSecondaryOwnerEmail == incomingSecondaryOwnerEmail).ToListAsync();
            return results;
        }

        public async Task AssignVinsToSecondaryOwner(ApplicationUser secondaryOwner)
        {
            var emailIdParam = (new SqlParameter("@EmailId", secondaryOwner.UserName));
            var userIdParam = (new SqlParameter("@UserId", secondaryOwner.Id));
            var exeSp = "execute dbo.apAssignVinsToSecondaryOwner  @EmailId, @UserId";
            var result = await _context.Database.ExecuteSqlRawAsync(exeSp, emailIdParam, userIdParam);
        }
        public async Task UpdateVehicle(ApplicationViewModel avm)
        {
            var vehicle = new RetrofitApplication();
            //vehicle.VehicleId = 2;
            vehicle.Vin = avm.Vin;
            //vehicle.Plate = avm.Plate;
            vehicle.LastUpdatedBy = avm.Email;
            //vehicle.Comment = avm.Comment;
            //vehicle.SubmissionStatus = avm.SubmissionStatus;
            //vehicle.Year = avm.Year;
            vehicle.LastUpdatedDate = DateTime.Now;
            _context.RetrofitApplications.Attach(vehicle);
            _context.Update(vehicle);
            await _context.SaveChangesAsync();
          

        }








        public  IEnumerable<OwnersVin> GetVins(string ownerId)
        {
            IEnumerable<OwnersVin> result = _context.OwnersVins.Where(a => a.OwnerId == ownerId && a.OwnerStatus == true);
            return result;
        }
        public IEnumerable<OwnersVin> GetPrimaryOwnersVins(string ownerId)
        {
            IEnumerable<OwnersVin> result = _context.OwnersVins.Where(a => a.OwnerId == ownerId && a.OwnerStatus == true && a.PrimaryOwner == "Y");
            return result;
        }
        public RetrofitApplicationDmvccddata GetRetrofitApplicationDmvccddata(string vin)
        {
            var retrofitApplicationDmvccddata = from ra in _context.RetrofitApplications
                                                join d in _context.Dmvccddata on ra.Vin equals d.Vin
                                                where ra.Vin == "vin1"
                                                select new RetrofitApplicationDmvccddata
                                                {
                                                    Vin = ra.Vin,
                                                    Plate = d.Plate,
                                                    Gvw = d.Gvw,
                                                    EngineYear = ra.EngineYear,
                                                    ModelYear = d.ModelYear,
                                                    EngineManufacturer = ra.EngineManufacturer,
                                                    EngineFamilyNumber = ra.EngineFamilyNumber,
                                                    EngineDisplacement = ra.EngineDisplacement,
                                                    ArtFamilyName = ra.ArtFamilyName,
                                                    ApplicationDate = ra.ApplicationDate,
                                                    RetrofitType = ra.RetrofitType,
                                                    RetrofitProvider = ra.RetrofitProvider,
                                                    Comments = ra.Comments,
                                                    RegistrationWeight = d.RegistrationWeight,
                                                    WeightRange = d.WeightRange,
                                                    OwnerName = d.OwnerName,
                                                    StreetAddress = d.StreetAddress,
                                                    City = d.City,
                                                    State = d.State,
                                                    Zip = d.Zip,
                                                    County = d.County,
                                                    PubliclyOwned = d.PubliclyOwned,
                                                    RegistrationExpiration = d.RegistrationExpiration,
                                                    RenewalAgency = d.RenewalAgency,
                                                    ChangedOwnership = d.ChangedOwnership,
                                                    DocumentActions = new List<DocumentAction>()
                    };
            return retrofitApplicationDmvccddata.FirstOrDefault();
        }
        //public IEnumerable<VehicleDocuments> GetVehicleDocuments(string vin)
        //{
        //    IEnumerable<VehicleDocuments> result = _context.VehicleDocuments.Where(a => a.Vin == vin);
        //    return result;

        //}

        //public bool IsPlateEligibleToClaim(string plate)
        //{
        //    var vin = GetVin(plate);
        //    return IsVinEligibleToClaim(vin);
        //}

        //public bool IsVinEligibleToClaim(string vin)
        //{
        //    if (IsVinRegulated(vin) && !IsVinClaimed(vin))
        //        return true;
        //    return false;
        //}




        public async Task<IList<OwnersVin>> GetSecondaryOwnerIds(string ownerId)
        {
            var p1 = new SqlParameter("@OwnerId", ownerId);
            var p3 = new SqlParameter("@OwnerStatus", true);
            var p4 = new SqlParameter("@OwnerStatus2", true);
            var secondaryOwnersVins = await _context.OwnersVins.FromSqlInterpolated(
                $@"select ov2.*
                        from (select ov1.vin
                                from  dbo.OwnersVin ov1 where ov1.ownerid = {p1} and  ov1.PrimaryOwner like 'Y%' and ov1.OwnerStatus = {p3}) ov1
                        inner join dbo.OwnersVin ov2 on ov1.vin = ov2.vin and ov2.PrimaryOwner like 'N%' and ov2.OwnerStatus = {p4}")
                .AsNoTracking()
                .ToListAsync();

            //        var x = var parents = await context.Parents
            //.Select(x => new
            //{
            //    x.ParentId,
            //    x.Name,
            //    Children = x.Children.Select(c => new { c.ChildId, c.Name }).ToList(),
            //    ChildCount = x.Children.Count()
            //}).ToListAsync();

            return (IList<OwnersVin>)secondaryOwnersVins;
        }

        public async Task<IList<VinsForSecondaryOwnerAssignment>> GetVinsForSecondaryOwnershipAssignment(string ownerId, string secondaryOwnerId)
        {
            var p1 = new SqlParameter("@OwnerId", ownerId);
            //var p2 = new SqlParameter("@SecondaryOwnerId", secondaryOwnerId);
            var p3 = new SqlParameter("@OwnerStatus", true);

            //var p1 = new SqlParameter("@OwnerId", ownerId);
            //var p3 = new SqlParameter("@OwnerStatus", true);
            //var p4 = new SqlParameter("@OwnerStatus2", true);

            var vins = await _context.OwnersVins.FromSqlInterpolated(
            $@"                with v1 as (
                            select ov1.vin, ov1.OwnerID
                            from  dbo.OwnersVin ov1 where ov1.OwnerID = {p1}
                            and ov1.OwnerStatus = {p3} and ov1.PrimaryOwner like 'Y%'
                            )
                            select ov1.*
                            from v1
                            inner join dbo.OwnersVin ov1 on ov1.vin = v1.vin
                            order by ov1.VIN, ov1.PrimaryOwner")
            .AsNoTracking()
            .ToListAsync();

            IList<VinsForSecondaryOwnerAssignment> objectList = vins.Select(o =>
            new VinsForSecondaryOwnerAssignment
            {
                OwnerId = o.OwnerId,
                Vin = o.Vin,
                PrimaryOwner = o.PrimaryOwner
            }).ToList();

            //var vins = await _context.OwnersVin.FromSqlInterpolated(
            //    $@"
            //        select vin from dbo.OwnersVIN ov
            //        where ov.OwnerID = {p1} and ov.OwnerStatus = {p3}
            //        and ov.vin not in (select vin from dbo.OwnersVIN where  OwnerID = {p2})")

            //var vins = await _context.OwnersVin.FromSqlInterpolated(
            //    $@"

            //        select ov1.*
            //        from  dbo.OwnersVin ov1 where ov1.OwnerID = {p1}
            //        and ov1.OwnerStatus = {p3} and ov1.PrimaryOwner like 'Y%')")



            //    .AsNoTracking()
            //    .ToListAsync();

            //var secondaryOwnerVins = (from a in _context.OwnersVin
            //              where a.OwnerId == ownerId && a.PrimaryOwner == "N" && a.OwnerStatus == true 
            //              select new { a.Vin }).ToList();

            //var ownerVins = (from a in _context.OwnersVin
            //                         where a.OwnerId == ownerId && a.PrimaryOwner == "Y" && a.OwnerStatus == true
            //                         select new { a.Vin }).ToList();

            return (IList<VinsForSecondaryOwnerAssignment>)objectList;
        }
        public IEnumerable<VehicleDocuments> GetVehicleDocuments(string vin)
        {
            IEnumerable<VehicleDocuments> result = (IEnumerable<VehicleDocuments>)_context.VehicleDocuments.Where(a => a.Vin == vin);
            return result;

        }
        public IEnumerable<DocumentAction> GetDocumentsAction(string vin)
        {
            throw new NotImplementedException();
        }




        //IEnumerable<EmailCode> IHDDRepository.GetEmailCode(int vehicleId, string email)
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerable<EmailCode> IHDDRepository.GetEmailCode(string vin, string plate, string email)
        //{
        //    throw new NotImplementedException();
        //}

        //Vehicle IHDDRepository.GetVehicle(string vin, string plate)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<EmailCode> IHDDRepository.SendEmailCode(string vin, string plate, string email)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
