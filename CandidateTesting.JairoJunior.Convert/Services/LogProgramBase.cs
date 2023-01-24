using CandidateTesting.JairoJunior.Convert.Entidade;
using CandidateTesting.JairoJunior.Convert.Interfaces;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandidateTesting.JairoJunior.Convert.Services
{
    public class LogProgramBase : ILogProgramBase
    { 
        public async Task<HttpResponseMessage> ConvertToAgora(string origem, string destino)
        {
            Log log = new Log();

            var client = new HttpClient();

            var result = await client.GetAsync(origem);

            if (result.IsSuccessStatusCode)
            {

                var data = result.Content.ReadAsStringAsync();


                log.Version = "1.0";
                log.Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                string[] lines = data.Result.Split(Environment.NewLine);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (!string.IsNullOrEmpty(lines[i]))
                    {
                        LogContent conteudo = new LogContent();
                        var strSplited = lines[i].ToString().Split("|");
                        var strColSplited = strSplited[3].Replace("\"", "").Split(" ");

                        var provider = "MINHA CDN";
                        var timetaken = strSplited[4];
                        var uri_path = strColSplited[1];
                        var status_code = strSplited[1];
                        var http_method = strColSplited[0];
                        var response_size = strSplited[0];
                        var cache_status = strSplited[2];

                        conteudo.provider = provider;
                        conteudo.http_method = http_method;
                        conteudo.status_code = status_code;
                        conteudo.uri_path = uri_path;
                        conteudo.time_taken = timetaken;
                        conteudo.response_size = response_size;
                        conteudo.cache_status = cache_status;

                        log.Contents.Add(conteudo);
                    }
                }

                CriarFileLog(log, destino);

                ExibeLog(destino);

            }

            return result;
        }

        public void CriarFileLog(Log log, string destino)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destino));

            if (!File.Exists(destino))
            {
                using (StreamWriter sw = File.CreateText(destino))
                {
                    sw.WriteLine($"# Version: {log.Version}");
                    sw.WriteLine($"# Date: {log.Date}");
                    sw.WriteLine("# Fields: provider http-method status-code uri-path time-taken response-size cache-status");

                    foreach (var item in log.Contents)
                    {
                        sw.WriteLine($"\"{item.provider}\" {item.http_method} {item.status_code} {item.uri_path} {item.time_taken} {item.response_size} {item.cache_status}");
                    }

                }
            }
        }

        public void ExibeLog(string destino)
        {
            using (StreamReader sr = File.OpenText(destino))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}