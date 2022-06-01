using HDD.ApplicationCore.Entities;
using HDD.Web.ViewModels;

namespace HDD.Web.Services
{
    public interface IVinService
    {
        Task<bool> IsVinRegulated(string vin);
        Task<bool> IsPlateRegulated(string plate);
        Task ClaimAVin(string ownerId, string vin, string primaryOwner);

        //bool IsPlateEligibleToClaim(string plate);

        //bool IsVinEligibleToClaim(string vin);

        RetrofitApplicationDmvccddata GetRetrofitApplicationDmvccddata(string vin);

        //IList<DocumentAction> GetDocumentsAction(string vin);
    }
}
