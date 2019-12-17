using System;
using Xunit;
using Models;

namespace SoSAWebsite.Tests
{
    public class UserPermissionsTests
    {
        [Fact]
        public void ShouldCorrectlyAddAndReadPermissions()
        {
            UserPermissions testPermissions = new UserPermissions();
            testPermissions.SetPermissionPreset(PermissionPresets.Admin);

            Assert.Equal(true, testPermissions.HasPermissions(PermissionTypes.Payments, AccessTypes.ReadAccess));
            Assert.Equal(true, testPermissions.HasPermissions(PermissionTypes.Payments, AccessTypes.WriteAccess));
            Assert.Equal(true, testPermissions.HasPermissions(PermissionTypes.ProjectReview, AccessTypes.ReadAccess));
            Assert.Equal(true, testPermissions.HasPermissions(PermissionTypes.ProjectReview, AccessTypes.WriteAccess));
            Assert.Equal(true, testPermissions.HasPermissions(PermissionTypes.TeamManagement, AccessTypes.ReadAccess));
            Assert.Equal(true, testPermissions.HasPermissions(PermissionTypes.TeamManagement, AccessTypes.WriteAccess));
        }
    }
}
