using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Le_Banc
{
    public class TheTest
    {
        public DateTime Date { get; set; }
        public int Testnr { get; set; }

        public List<string> ListChoosenAnswers { get; set; }
        public List<Question> ListQuestion { get; set; }//ev stäng med id nummer på queston borde vi ha här...

        
       
    }
}