using aiTherapist.Configuration.Dto;
using System.Threading.Tasks;

namespace aiTherapist.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
