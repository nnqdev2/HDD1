﻿using HDD.ApplicationCore.Entities;
using HDD.Infrastructure.Identity;
using HDD.Web.ViewModels;

namespace HDD.Web.Interfaces
{
    public interface IVinOwnershipService
    {
        Task<ApReturnCodeMessage> ValidatePrimaryOwnerAtRegistrationAsync(string vin, string plate, string zip);
        Task<bool> IsSecondaryOwnerEmailAsync(string email);
        Task<bool> IsIncomingSecondaryOwner(string email);
        Task<bool> IsIncomingPrimaryOwner(string vin, string plate, string registeredZip);
        Task AssignVinsToSecondaryOwnerAsync(ApplicationUser secondaryOwner);
        Task<ApReturnCodeMessage> AssignVinToPrimaryOwnerAsync(ApplicationUser primaryOwner);
        Task AssignOwnershipToVin(string userId, string vin, bool isPrimary);
        Task<IEnumerable<VinOwnership>> GetPrimaryOwnershipVins(string ownerId);
        Task<IList<VinSecondaryOwnerAction>> GetVinsForSecondaryOwnershipAssignment(string ownerId, string secondaryOwnerId);
        Task<IList<EmailInfo>> GetSecondaryOwners(string ownerId);
        public void SendRequestPermissionEmail(string primaryEmail, string requestEmail, string vin);
        public void SendPermissionNotificationEmail(string requestEmail, string vin, bool isApproved);

    }
}