using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace SoSAWebsite.Application.Data
{
    /// <summary>
    /// Permissions that the user has that can be read and updated
    /// </summary>
    /// 
    /// How to use:
    /// 1. Load up a User to manage the permissions for
    /// 2. Create a PermissionManager and provide the initial values for the permissions
    /// 3. Save changes to User object
    /// 4. Save User object to database
    public class PermissionManager
    {
        private Dictionary<PermissionTypes, Permission> Permissions { get; set; }

        /// <summary>
        /// Can be used to set permissions for a certain entity.
        /// Makes provisioning permissions a lot easier.
        /// </summary>
        /// <param name="permissions"></param>
        public PermissionManager(IEnumerable<Permission> permissions)
        {
            this.Permissions = new Dictionary<PermissionTypes, Permission>();
            foreach (Permission p in permissions)
            {
                this.Permissions.Add(p.permissionType, p);
            }
        }

        /// <summary>
        /// Sets Permissions based on a preset. This is also a convenience function.
        /// Does not automatically save into the database. Must call Update database
        /// manually.
        /// </summary>
        /// <param name="preset">The preset to apply</param>
        public void SetPermissionPreset(PermissionPresets preset)
        {
            Permission paymentPermission = new Permission(PermissionTypes.Payments);
            Permission teamsPermission = new Permission(PermissionTypes.TeamManagement);
            Permission projectPermission = new Permission(PermissionTypes.ProjectReview);

            // Create permissions based on an option
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
                default:
                    // This happens when a preset has not been made.
                    throw new Exception("No preset values found for: " + preset.ToString());
            }

            // Makes sure that we don't have any leftover permissions
            // At this point in time, we are confident that the new permissions
            // have been properly set
            this.Permissions.Clear();

            // Add all permissions as new ones
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
        /// Turns the hashmap into an array that is NoSQL friendly
        /// </summary>
        /// <returns>An array of Permissions</returns>
        public Permission[] ToArray()
        {
            List<Permission> permissions = new List<Permission>();
            foreach (KeyValuePair<PermissionTypes, Permission> p in this.Permissions)
            {
                permissions.Add(p.Value);
            }

            return permissions.ToArray();
        }

        /// <summary>
        /// Overwrites the user's permissions
        /// </summary>
        /// <param name="user">The user to change</param>
        /// <returns>The same user reference with new permissions</returns>
        public User SaveToUser(User user)
        {
            user.permissions = this.ToArray();
            return user;
        }
    }
}
