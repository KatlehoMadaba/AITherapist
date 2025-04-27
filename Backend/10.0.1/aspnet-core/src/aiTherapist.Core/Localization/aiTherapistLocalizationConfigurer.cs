using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace aiTherapist.Localization;

public static class aiTherapistLocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(aiTherapistConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(aiTherapistLocalizationConfigurer).GetAssembly(),
                    "aiTherapist.Localization.SourceFiles"
                )
            )
        );
    }
}
