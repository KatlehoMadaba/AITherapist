using Abp.Application.Services;
using aiTherapist.MultiTenancy.Dto;

namespace aiTherapist.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

