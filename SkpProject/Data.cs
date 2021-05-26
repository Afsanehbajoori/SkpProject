using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SkpProject
{
    public class Data
    {
        //public static ObservableCollection<Student> students = new ObservableCollection<Student>();
        public List<Student> students = new List<Student>();

        public void CreateStudentsData()
        {
            
            students.Add(new Student()
            {
                CPRNR= "2009884258",
                FirstName= "Jan ",
                LastName= "Hansen",
               
                

            });

            students.Add(new Student()
            {
                CPRNR = "0805965542",
                FirstName = "Ella ",
                LastName = "Jensen"

            });

            students.Add(new Student()
            {
                CPRNR = "2005994869",
                FirstName = "Alfa ",
                LastName = "Nilsen"

            });

            students.Add(new Student()
            {
                CPRNR = "2005884869",
                FirstName = "Oscar ",
                LastName = "Petersen"

            });

            students.Add(new Student()
            {
                CPRNR = "2005784869",
                FirstName = "Alfred ",
                LastName = "Larsen"

            });





        }

        public List<Student> GetStudents()
        {
            students.Clear();
            CreateStudentsData();
            return students;
        }


        

    }


}
