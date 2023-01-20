using System;
using System.Collections.Generic;
using System.Linq;

namespace CandidateTesting.JairoJunior.Convert.Entidade
{
    public class Log
    {
        public Log()
        {

            Contents = new List<LogContent>();
        }
        public string Version { get; set; }

        public string Date { get; set; }

        public List<LogContent> Contents { get; set; }
    }

}

