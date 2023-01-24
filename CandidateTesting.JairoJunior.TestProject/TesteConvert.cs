using CandidateTesting.JairoJunior.Convert.Entidade;
using CandidateTesting.JairoJunior.Convert.Interfaces;
using CandidateTesting.JairoJunior.Convert.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandidateTesting.JairoJunior.TestProject
{
    public class TesteConvert
    {
       

        [Test]
        [TestCase("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt", "c:\\temp\\teste1.txt")]
        [TestCase("www.google.com.br", "c:\\temp\\teste2.txt")]
        [TestCase("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt", "c:\\temp\\teste2.txt")]    
        public async Task ConvertToAgora(string origem, string destino)
        {

            LogProgramBase logexc = new LogProgramBase();

            HttpResponseMessage response = await logexc.ConvertToAgora(origem, destino);

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}