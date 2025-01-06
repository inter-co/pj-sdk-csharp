using System.Security.Cryptography.X509Certificates;

namespace inter_sdk_library;

public class InterSdk {
    private Config config;
    List<string> Warnings;
    private BankingSdk banking;
    private BillingSdk billing;
    private PixSdk pix;
    private static StreamWriter log;

    public static string GetVersion() {
        return "inter-sdk-csharp v1.0.2";
    }

    public InterSdk(string environment, string clientId, string clientSecret, string certificate, string certificatePassword) {
        config = new Config((EnvironmentEnum)Enum.Parse(typeof(EnvironmentEnum), environment), clientId, clientSecret, certificate, certificatePassword);
        Warnings = new List<string>();
        OpenLog();
        DateTime notAfter = DateTime.Now;
        bool ok = CheckCertificate(certificate, certificatePassword, ref notAfter);
        if (!ok) {
            Warnings.Add(String.Format("Certificate near do expire. Less then {0} days. Expire in {1}.", Constants.DAYS_TO_EXPIRE, notAfter));
        }
    }

    public void SetDebug(bool debug) {
        config.Debug = debug;
    }

    public void SetEnvironment(string ambiente) {
        config.Environment = EnvironmentEnum.UAT;
    }

    public void SetAccount(string contaCorrente) {
        config.Account = contaCorrente;
    }

    public string GetAccount() {
        return config.Account;
    }

    public void SetRateLimitControl(bool controle) {
        config.RateLimitControl = controle;
    }

    public bool IsControleRateLimit() {
        return config.RateLimitControl;
    }

    public BillingSdk Billing() {
        if (billing == null) {
            billing = new BillingSdk(config);
        }
        return billing;
    }

    public BankingSdk Banking() {
        if (banking == null) {
            banking = new BankingSdk(config);
        }
        return banking;
    }

    public PixSdk Pix() {
        if (pix == null) {
            pix = new PixSdk(config);
        }
        return pix;
    }

    public List<string> ListaAvisos() {
        return Warnings;
    }

    private void OpenLog() {
        if (!File.Exists("logs")) {
            Directory.CreateDirectory("logs");
        } 
        string tomorrow = DateTime.Now.AddDays(1).DayOfWeek.ToString();
        string path = "logs/inter-sdk-" + tomorrow + ".log";
        if (File.Exists(path)) {
            File.Delete(path);
        }
        string today = DateTime.Now.DayOfWeek.ToString();
        path = "logs/inter-sdk-" + today + ".log";
        FileStream fileStream = null;
        if (File.Exists(path)) {
            fileStream = new FileStream(path, FileMode.Append);
        } else {
            fileStream = new FileStream(path, FileMode.Create);
        }
        log = new StreamWriter(fileStream);
        InterSdk.LogInfo("{0}", GetVersion());
    }

    public static void LogInfo(string format, params string[] prms) {
        string text = string.Format(format, prms);
        log.Write(DateTime.Now.ToString());
        log.WriteLine(" " + text);
        log.Flush();
    }

    private bool CheckCertificate(string certificado, string senha, ref DateTime notAfter) {
        X509Certificate2Collection certificates = new X509Certificate2Collection();
        certificates.Import(certificado, senha, X509KeyStorageFlags.PersistKeySet);
        X509Certificate2 cert = certificates[0];
        TimeSpan diff = cert.NotAfter.Subtract(DateTime.Now);
        if (diff.Days < Constants.DAYS_TO_EXPIRE) {
            notAfter = cert.NotAfter;
            return false;
        }
        return true;
    }
}
