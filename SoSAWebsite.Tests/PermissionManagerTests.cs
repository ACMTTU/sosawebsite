using System;
using Xunit;
using Models;
using SoSAWebsite.Application.Data;

namespace SoSAWebsite.Tests
{
    public class PermissionManagerTests
    {
        [Fact]
        public void ShouldProperlyEditAndReadPermissionsOfAUser()
        {
            // Arrange
            User testUser = new User
            {
                permissions = new Permission[]
                {
                    new Permission(PermissionTypes.TeamManagement)
                    {
                        ReadAccess = true,
                        WriteAccess = true,
                    },
                    new Permission(PermissionTypes.Payments)
                    {
                        ReadAccess = false,
                        WriteAccess = false,
                    },
                }
            };

            PermissionManager pm = new PermissionManager(testUser.permissions);

            // Act
            pm.SetPermissionPreset(PermissionPresets.Admin);
            pm.SaveToUser(testUser);

            // Assert
            Assert.Equal(3, testUser.permissions.Length);
            Assert.True(pm.HasPermissions(PermissionTypes.Payments, AccessTypes.WriteAccess));
            Assert.True(pm.HasPermissions(PermissionTypes.Payments, AccessTypes.ReadAccess));
            Assert.True(pm.HasPermissions(PermissionTypes.ProjectReview, AccessTypes.WriteAccess));
            Assert.True(pm.HasPermissions(PermissionTypes.ProjectReview, AccessTypes.ReadAccess));
            Assert.True(pm.HasPermissions(PermissionTypes.TeamManagement, AccessTypes.WriteAccess));
            Assert.True(pm.HasPermissions(PermissionTypes.TeamManagement, AccessTypes.ReadAccess));
        }
    }
}
