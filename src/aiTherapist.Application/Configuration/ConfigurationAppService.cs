using Abp.Authorization;
using Abp.Runtime.Session;
using aiTherapist.Configuration.Dto;
using System.Threading.Tasks;

namespace aiTherapist.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : aiTherapistAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
