using System;
using System.Collections.Generic;

namespace Models
{
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
