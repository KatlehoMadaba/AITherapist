using Abp.Authorization;
using aiTherapist.Authorization.Roles;
using aiTherapist.Authorization.Users;

namespace aiTherapist.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
