using HDD.ApplicationCore.Entities;
using HDD.Infrastructure.Identity;
using HDD.Web.ViewModels;

namespace HDD.Web.Interfaces
{
    public interface IHDDRepository
    {
        Task<bool> IsVinRegulatedAsync(string vin);
        Task<bool> IsPlateRegulatedAsync(string plate);
        Task<IEnumerable<ApGetVinsByOwnerId>> GetVinsByOwnerIdAsync(string ownerId);
        Task<ApIsVinClaimable> IsVinClaimableAsync(string vin, string userId);
        Task<ApReturnCodeMessage> ValidatePrimaryOwnerAtRegistrationAsync(string vin, string plate, string zip);
        Task<ApReturnCodeMessage> ValidateSecondaryOwnerAtRegistrationAsync(string email);
        Task<ApReturnCodeMessage> AssignVinToPrimaryOwnerAsync(string vin, string userId);
        Task<bool> IsVinClaimed(string vin);
        Task<string> GetVin(string plate);
        Task<bool> IsIncomingPrimaryOwner(string vin, string plate, string registeredZip);
        Task<bool> IsIncomingSecondaryOwner(string email);
        Task InsertOwnersVin(OwnersVin ownersVin);
        Task<IList<SecondaryOwnerAssignment>> GetSecondaryOwnerAssignments(string incomingSecondaryOwnerEmail);
        Task AssignVinsToSecondaryOwnerAsync (ApplicationUser secondaryOwner);
        IEnumerable<OwnersVin> GetVins(string ownerId);







        //Vehicle GetVehicle(string vin, string plate);
        //IEnumerable<EmailCode> GetEmailCode(int vehicleId, string email);
        //Task<EmailCode> GetEmailCode(string vin, string plate, string email);
        Task UpdateVehicle(ApplicationViewModel avm);


        
        IEnumerable<OwnersVin> GetPrimaryOwnersVins(string ownerId);
        Task<IList<OwnersVin>> GetSecondaryOwnerIds(string ownerId);
        RetrofitApplicationDmvccddata GetRetrofitApplicationDmvccddata(string vin);
        IEnumerable<VehicleDocuments> GetVehicleDocuments(string vin);


        

        
        Task<IList<VinsForSecondaryOwnerAssignment>> GetVinsForSecondaryOwnershipAssignment(string ownerId, string secondaryOwnerId);
    }
}
