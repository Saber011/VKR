using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JWT.Core
{
    /// <summary>
    /// Вспомогательнй класс для работы с онлайн компиляторами
    /// </summary>
    public class ApiOnlineCompilations
    {
        const string clientId = "a612afdc8c9bd742ac181cd36a07d7cc";
        const string clientSecret = "3023cece709acd5d59ee104fc668b4b46587dbdb10911a14e6c83f7b668a4294";

        /// <summary>
        /// Проверить выполняемый код
        /// </summary>
        /// <param name="script">исходный код</param>
        /// <param name="language">язык программирования</param>
        /// <param name="versionIndex">версия языка</param>
        public async static Task<dynamic> CallApi(string script, string language, string versionIndex)
        {
            string responceInfo;
            var request = WebRequest.Create("https://api.jdoodle.com/v1/execute");
            request.ContentType = "application/json";
            request.Method = "POST";
            var objectapi = new { clientId, clientSecret, script, language, versionIndex };
            string json = JsonSerializer.Serialize<dynamic>(objectapi);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                responceInfo = await reader.ReadToEndAsync();
            }

            var responceCompile = JsonSerializer.Deserialize<ResponceCompile>(responceInfo);

            return responceCompile;

        }

    }
}
