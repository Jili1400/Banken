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
        public int questionId { get; set; }
        public string collectedAnswer { get; set; }
        public int personId { get; set; }
 
        public List<CollectedAnswer> ListCollectedAnswers { get; set; }

       // public List<string> ListChoosenAnswers { get; set; }
        //public List<Question> ListQuestion { get; set; }//ev stäng med id nummer på question borde vi ha här...
       

        
       
    }
}