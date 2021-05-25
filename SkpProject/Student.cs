using System;
using System.Collections.Generic;
using System.Text;

namespace SkpProject
{
    public class Student
    {

        private string cprNr = string.Empty;
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        //private string intStudentAge;




        public string FullInfo
        {
            get { return this.ToString(); }
            set { ; }
        }


        public string CPRNR
        {
            get { return cprNr; }
            set
            {
                if (cprNr != value)
                {
                    cprNr = value;
                }

            }
        }


        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                }

            }

        }


        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                }

            }
        }

        public override string ToString()
        {
            return $"{CPRNR} - {lastName}, {firstName}. ";
        }

        //public string IntStudentAge
        //{
        //    get { return intStudentAge.ToString() ; }
        //    set
        //    {
        //        DateTime dtToday = DateTime.Today;
        //        //string cprNr = "2005994525";

        //        string strBirthDate = cprNr.Substring(0, 6);


        //        string strDD = strBirthDate.Substring(0, 2);
        //        string strMM = strBirthDate.Substring(2, 2);
        //        string strYY = strBirthDate.Substring(4, 2);
        //        int intYY = Convert.ToInt32(strYY);
        //        string strYYYY;
        //        if (intYY <= 0)
        //        {
        //            strYYYY = "20" + strYY;
        //        }
        //        else
        //        {
        //            strYYYY = "19" + strYY;
        //        }

        //        string strAllBirth = strDD + "/" + strMM + "/" + strYYYY;

        //        DateTime dtBirthDate = Convert.ToDateTime(strAllBirth);
        //        int years = dtToday.Year - dtBirthDate.Year;
        //        if (dtToday.Month < dtBirthDate.Month || (dtToday.Month == dtBirthDate.Month && dtToday.Day < dtBirthDate.Day))
        //            years = years - 1;

        //        int intStudentAge = years;
        //        //return intStudentAge.ToString();

        //    }
        //}


       
    }
}
