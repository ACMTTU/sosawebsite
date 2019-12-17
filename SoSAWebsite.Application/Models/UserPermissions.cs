using System;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Permissions that the user has that can be read and updated
    /// </summary>
    public class UserPermissions
    {
        public Dictionary<PermissionTypes, Permission> Permissions { get; private set; }

        public UserPermissions()
        {
            this.Permissions = new Dictionary<PermissionTypes, Permission>();
        }

        /// <summary>
        /// Sets Permissions based on a preset. This is also a convenience function
        /// </summary>
        /// <param name="preset">The preset to apply</param>
        public void SetPermissionPreset(PermissionPresets preset)
        {
            Permission paymentPermission = new Permission(PermissionTypes.Payments);
            Permission teamsPermission = new Permission(PermissionTypes.TeamManagement);
            Permission projectPermission = new Permission(PermissionTypes.ProjectReview);

            switch (preset)
            {
                case (PermissionPresets.Admin):
                    paymentPermission.WriteAccess = true;
                    paymentPermission.ReadAccess = true;
                    teamsPermission.WriteAccess = true;
                    teamsPermission.ReadAccess = true;
                    projectPermission.WriteAccess = true;
                    projectPermission.ReadAccess = true;
                    break;
                case (PermissionPresets.ProjectLead):
                    paymentPermission.WriteAccess = false;
                    paymentPermission.ReadAccess = false;
                    teamsPermission.WriteAccess = true;
                    teamsPermission.ReadAccess = true;
                    projectPermission.WriteAccess = false;
                    projectPermission.ReadAccess = true;
                    break;
                case (PermissionPresets.PaymentsManager):
                    paymentPermission.WriteAccess = true;
                    paymentPermission.ReadAccess = true;
                    teamsPermission.WriteAccess = false;
                    teamsPermission.ReadAccess = true;
                    projectPermission.WriteAccess = false;
                    projectPermission.ReadAccess = false;
                    break;
                case (PermissionPresets.Member):
                    paymentPermission.WriteAccess = false;
                    paymentPermission.ReadAccess = false;
                    teamsPermission.WriteAccess = false;
                    teamsPermission.ReadAccess = true;
                    projectPermission.WriteAccess = false;
                    projectPermission.ReadAccess = false;
                    break;
            }

            AddPermissions(paymentPermission);
            AddPermissions(teamsPermission);
            AddPermissions(projectPermission);
        }

        /// <summary>
        /// Convenience function that allows a user to check if they have some permission
        /// Permissions will always default to false if they do not have any permission saved.
        /// </summary>
        /// <param name="permissionType">The type of permission to look for</param>
        /// <param name="accessType">Read or Write Access</param>
        /// <returns></returns>
        public bool HasPermissions(PermissionTypes permissionType, AccessTypes accessType)
        {
            Permission permissionOfInterest = this.Permissions.GetValueOrDefault(permissionType, null);

            if (permissionOfInterest == null)
            {
                return false;
            }
            else
            {
                switch (accessType)
                {
                    case (AccessTypes.WriteAccess):
                        return permissionOfInterest.WriteAccess;
                    case (AccessTypes.ReadAccess):
                        return permissionOfInterest.ReadAccess;
                    default:
                        throw new Exception("Type Error");
                }
            }
        }

        /// <summary>
        /// Overwrites old permission and replaces it with new one
        /// </summary>
        /// <param name="newPermission"></param>
        private void AddPermissions(Permission newPermission)
        {
            Permissions.Remove(newPermission.permissionType);
            Permissions.Add(newPermission.permissionType, newPermission);
        }

        /// <summary>
        /// Gets all of the current permissions from the database
        /// </summary>
        /// <returns>The permissions the user already has</returns>
        private void GetCurrentSavedPermissions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the information in Permissions into the database
        /// </summary>
        private void Save()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Smallest representation of a permission
    /// </summary>
    public class Permission
    {
        public readonly PermissionTypes permissionType;
        public bool ReadAccess { get; set; }
        public bool WriteAccess { get; set; }

        public Permission(PermissionTypes permisionType)
        {
            this.permissionType = permisionType;
        }
    }

    /// <summary>
    /// Fundamental Permission Types to allow for ganular access management
    /// </summary>
    public enum PermissionTypes
    {
        // Permissions regarding the payments
        Payments,

        // Permissions regarding adding/removing students from teams
        TeamManagement,

        // Permissions regarding review and approving project proposals
        ProjectReview,
    }

    /// <summary>
    /// Permission Presets for ease of use. Each enum should come with
    /// predefined permissions to set.
    /// </summary>
    public enum PermissionPresets
    {
        Admin,
        PaymentsManager,
        ProjectLead,
        Member
    }

    /// <summary>
    /// Option to choose which Access the user would like to read
    /// </summary>
    public enum AccessTypes
    {
        ReadAccess,
        WriteAccess
    }
}
