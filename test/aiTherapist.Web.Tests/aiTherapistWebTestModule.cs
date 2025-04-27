using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using aiTherapist.EntityFrameworkCore;
using aiTherapist.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace aiTherapist.Web.Tests;

[DependsOn(
    typeof(aiTherapistWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class aiTherapistWebTestModule : AbpModule
{
    public aiTherapistWebTestModule(aiTherapistEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(aiTherapistWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(aiTherapistWebMvcModule).Assembly);
    }
}