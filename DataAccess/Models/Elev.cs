using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Elev
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string CPRNr { get; set; }
        public int SkoleId { get; set; }
        

        public string GetBasicInfo()
        {
            string finalStr = "Elevs Navn:  " + Navn + "/nCPRNr: " + CPRNr;
            return finalStr;
        }
        

    }

    
}
