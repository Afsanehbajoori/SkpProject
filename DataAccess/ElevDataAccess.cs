using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using DataAccess.Models;



namespace DataAccess
{
    public class ElevDataAccess
    {
       // private string path = @"./DemoDBElev.csv";

        //public ObservableCollection<Elev> elevs { get; set; } = new ObservableCollection<Elev>();

        //public ElevDataAccess()
        //{
        //    ReadElevs();
        //}

        //private void ReadElevs()
        //{
            //Elev el1 = new Elev()
            //{
            //    Id = 1,
            //    ENavn = "Jan Hansen",
            //    CPRNr = "010221-4258",
            //    SkoleId = 1
            //};

            //Elev el2 = new Elev()
            //{
            //    Id = 2,
            //    ENavn = "Ella Jensen",
            //    CPRNr = "010220-5542",
            //    SkoleId = 2
            //};
            //elevs.Add(el1);
            //elevs.Add(el2);

            //using(var reader= new StreamReader(path))
            //{
            //    elevs.Clear();
            //    while (!reader.EndOfStream)
            //    {
            //        string line = reader.ReadLine();
            //        string[] values = line.Split(';');


            //        Elev elev = new Elev()
            //        {
            //            Id = Convert.ToInt32(values[0]),
            //            Navn=values[1],
            //            CPRNr=values[2],
            //            SkoleId=Convert.ToInt32(values[3])

            //        };
            //        elevs.Add(elev);
            //    }
            //}


        //}

        //public void AddElev(Elev elev)
        //{
        //    elevs.Add(elev);
        //}

        //public int GetNextId()
        //{
        //    int index = elevs.Any() ? elevs.Max(x => x.Id) + 1 : 1;
        //    return index;
        //}


    }
}
