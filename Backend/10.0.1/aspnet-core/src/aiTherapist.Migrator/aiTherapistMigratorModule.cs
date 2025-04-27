using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using aiTherapist.Configuration;
using aiTherapist.EntityFrameworkCore;
using aiTherapist.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace aiTherapist.Migrator;

[DependsOn(typeof(aiTherapistEntityFrameworkModule))]
public class aiTherapistMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public aiTherapistMigratorModule(aiTherapistEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(aiTherapistMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            aiTherapistConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(aiTherapistMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
