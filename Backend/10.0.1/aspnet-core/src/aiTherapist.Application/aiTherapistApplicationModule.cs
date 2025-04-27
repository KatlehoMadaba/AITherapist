using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using aiTherapist.Authorization;

namespace aiTherapist;

[DependsOn(
    typeof(aiTherapistCoreModule),
    typeof(AbpAutoMapperModule))]
public class aiTherapistApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<aiTherapistAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(aiTherapistApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
