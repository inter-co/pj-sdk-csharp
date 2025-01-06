namespace inter_sdk_library;

using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

public class SdkUtils {
    public static string Serialize(object obj) {
        MemoryStream stream1 = new MemoryStream();
        DataContractJsonSerializer ser = new DataContractJsonSerializer(obj.GetType());
        ser.WriteObject(stream1, obj);
        stream1.Position = 0;
        StreamReader sr = new StreamReader(stream1);
        string json = sr.ReadToEnd();
        sr.Close();
        return json;
    }

    public static object Deserialize(Type tp, string json) {
        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        DataContractJsonSerializer ser = new DataContractJsonSerializer(tp);
        object obj = ser.ReadObject(ms);
        ms.Close();
        return obj;
    }

    public static void WritePdf(string data, string fileName) {
        File.WriteAllBytes(fileName, Convert.FromBase64String(data));
    }

    public static string PrmTamanhoPagina(int tamanhoPagina) {
        if (tamanhoPagina == 0) {
            return "";
        }
        return "&tamanhoPagina=" + tamanhoPagina;
    }
}
