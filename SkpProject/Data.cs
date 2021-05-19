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
                LastName = "Hansen"

            });

            students.Add(new Student()
            {
                CPRNR = "2009884869",
                FirstName = "Alfa ",
                LastName = "Hansen"

            });
            students.Add(new Student()
            {
                CPRNR = "2009884869",
                FirstName = "Alfa ",
                LastName = "Hansen"

            });
            students.Add(new Student()
            {
                CPRNR = "2009884869",
                FirstName = "Alfa ",
                LastName = "Hansen"

            });
            students.Add(new Student()
            {
                CPRNR = "2005994869",
                FirstName = "Alfa ",
                LastName = "Hansen"

            });
            students.Add(new Student()
            {
                CPRNR = "2009884869",
                FirstName = "Alfa ",
                LastName = "Hansen"

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
