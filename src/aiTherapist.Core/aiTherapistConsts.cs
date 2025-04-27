using aiTherapist.Debugging;

namespace aiTherapist;

public class aiTherapistConsts
{
    public const string LocalizationSourceName = "aiTherapist";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ddc82cbb443c400dbfd240a65ca956a2";
}
