using Abp.Application.Services;
using aiTherapist.Sessions.Dto;
using System.Threading.Tasks;

namespace aiTherapist.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
