using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace aiTherapist.Controllers
{
    public abstract class aiTherapistControllerBase : AbpController
    {
        protected aiTherapistControllerBase()
        {
            LocalizationSourceName = aiTherapistConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
