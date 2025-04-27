using Abp.Application.Services;
using aiTherapist.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace aiTherapist.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
