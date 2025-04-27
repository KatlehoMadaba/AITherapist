using Abp.Modules;
using Abp.Reflection.Extensions;
using aiTherapist.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace aiTherapist.Web.Host.Startup
{
    [DependsOn(
       typeof(aiTherapistWebCoreModule))]
    public class aiTherapistWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public aiTherapistWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(aiTherapistWebHostModule).GetAssembly());
        }
    }
}
