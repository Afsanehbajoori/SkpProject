using SkpProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Elev
    {
        public int Id { get; set; }
        [DataGridColumnName("Efternavn")]
        public string ENavn { get; set; }
        [DataGridColumnName("Fornavn")]
        public string FNavn { get; set; }
        [DataGridColumnName("CPR Nr.")]
        public string CPRNr { get; set; }
        [DataGridColumnName(" Uddannelse Add.")]
        public string UddannelseAdd { get; set; }
        [DataGridColumnName(" Elev Type")]
        public string ElevType { get; set; }
        

   


        public string GetBasicInfo()
        {
            string finalStr = "Elevs Navn:  " + ENavn + "/nCPRNr: " + CPRNr;
            return finalStr;
        }




    }

    
}
