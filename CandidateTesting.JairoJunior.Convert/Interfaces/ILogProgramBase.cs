using System.Net.Http;
using System.Threading.Tasks;
using CandidateTesting.JairoJunior.Convert.Entidade;

namespace CandidateTesting.JairoJunior.Convert.Interfaces
{
    public interface ILogProgramBase
    {
        Task<HttpClient> ConvertToAgora(string origem, string destino);
        void CriarFileLog(Log log, string destino);
        void ExibeLog(string destino);
    }
}