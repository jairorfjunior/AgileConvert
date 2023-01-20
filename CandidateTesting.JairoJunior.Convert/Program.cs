using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using System.Xml.Linq;
using CandidateTesting.JairoJunior.Convert.Services;
using static System.Net.Mime.MediaTypeNames;

namespace CandidateTesting.JairoJunior.Convert
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
           
            string origem, destino;
           
            Console.WriteLine("Informe a url origem: ");
            origem = Console.ReadLine();

            Console.WriteLine("Informe a url destino (Ex. C:\\temp\\teste.txt): ");
            destino = Console.ReadLine();
             
            LogProgramBase logexec = new LogProgramBase();

            await logexec.ConvertToAgora( origem, destino);
  
            
        }
      
    }
}
