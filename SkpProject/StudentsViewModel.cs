using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SkpProject
{
    public class StudentsViewModel
    {
        Data source = new Data();
        private ObservableCollection<Student> studentsList = new ObservableCollection<Student>();
        public ObservableCollection<Student> StudentsList
        {
            get { return studentsList; }
        }

        public StudentsViewModel()
        {
            foreach (var student in source.GetStudents())
            {
                studentsList.Add(student);
            }
        }

    }
}
