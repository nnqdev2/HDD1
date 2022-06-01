using HDD.ApplicationCore.Entities;
using HDD.Web.ViewModels;

namespace HDD.Web.Interfaces
{
    public interface IHDDRepository
    {
        Task<bool> IsVinRegulated(string vin);
        Task<bool> IsPlateRegulated(string plate);
        Task<bool> IsVinClaimed(string vin);
        Task<string> GetVin(string plate);
        Task<bool> IsIncomingPrimaryOwner(string vin, string plate, string registeredZip);
        Task<bool> IsIncomingSecondaryOwner(string email);
        Task InsertOwnersVin(OwnersVin ownersVin);

        //Vehicle GetVehicle(string vin, string plate);
        //IEnumerable<EmailCode> GetEmailCode(int vehicleId, string email);
        //Task<EmailCode> GetEmailCode(string vin, string plate, string email);
        Task UpdateVehicle(ApplicationViewModel avm);


        IEnumerable<OwnersVin> GetVins(string ownerId);
        IEnumerable<OwnersVin> GetPrimaryOwnersVins(string ownerId);
        Task<IList<OwnersVin>> GetSecondaryOwnerIds(string ownerId);
        RetrofitApplicationDmvccddata GetRetrofitApplicationDmvccddata(string vin);
        IEnumerable<VehicleDocuments> GetVehicleDocuments(string vin);


        

        
        Task<IList<VinsForSecondaryOwnerAssignment>> GetVinsForSecondaryOwnershipAssignment(string ownerId, string secondaryOwnerId);
    }
}
