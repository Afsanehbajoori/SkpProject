using DataAccess;
using DataAccess.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
//using Microsoft.Office.Interop.Excel;

namespace SkpProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		ElevDataAccess elevDataAccess = new ElevDataAccess();

		ObservableCollection<Elev> elevs = new ObservableCollection<Elev>();

		//public Elev currentElev { get; set; } = new Elev();

		public MainWindow()
		{
			InitializeComponent();
			fillData();

		}

		private void fillData()
		{
			elevs = elevDataAccess.elevs;
		}


		private void btnHome_Click(object sender, RoutedEventArgs e)
		{
			HomePanel.Visibility = Visibility.Visible;
			UnderviserPanel.Visibility = Visibility.Collapsed;
			LederPanel.Visibility = Visibility.Collapsed;
		}

		private void btnUnderviser_Click(object sender, RoutedEventArgs e)
		{
			UnderviserPanel.Visibility = Visibility.Visible;
			HomePanel.Visibility = Visibility.Collapsed;
			LederPanel.Visibility = Visibility.Collapsed;
		}

		private void btnLeder_Click(object sender, RoutedEventArgs e)
		{
			LederPanel.Visibility = Visibility.Visible;
			HomePanel.Visibility = Visibility.Collapsed;
			UnderviserPanel.Visibility = Visibility.Collapsed;
		}

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{

		}

		private void signinButton_Click(object sender, RoutedEventArgs e)
		{
			ViewElevsList viewelevslist = new ViewElevsList();
			viewelevslist.Show();
			this.Close();
		}

		private void søgeElevText_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void btnChosseFile_Click(object sender, RoutedEventArgs e)
		{
			//OpenFileDialog openFileDialog1 = new OpenFileDialog();
			//if (openFileDialog1.ShowDialog() == DialogResult.HasValue)
			//         {
			//	this.txtBox_path.Text = openFileDialog1.FileName;
			//         }
		}

		private void btnLoadExcel_Click(object sender, RoutedEventArgs e)
		{


			//string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtBox_path.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
			//System.Data.OleDb.OleDbConnection conn = new OleDbConnection(PathConn);

			//OleDbDataAdapter myDataAdapter = new OleDbDataAdapter()





		}

		private void btnOpen_Click(object sender, RoutedEventArgs e)
		{
            //{ Filter = "Excel Workbook|*.xlsx", Multiselect = false }

            ////OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Elev-liste til test|*.xlsx", Multiselect = false };
            ////         if (openFileDialog1.ShowDialog() == DialogResult.HasValue)
            ////         {
            ////             DataTable dt = new DataTable();
            ////             using (XLWorkbook workbook = new XLWorkbook(openFileDialog1.FileName))
            ////             {
            ////                 bool isFirstRow = true;
            ////                 var rows = workbook.Worksheet(1).RowsUsed();
            ////                 foreach (var row in rows)
            ////                 {
            ////                     if (isFirstRow)
            ////                     {
            ////                         foreach (IXLCell cell in row.Cells())


            ////                             dt.Columns.Add(cell.Value.ToString());
            ////                         isFirstRow = false;
            ////                     }
            ////                     else

            ////                     {
            ////                         dt.Rows.Add();
            ////                         int i = 0;
            ////                         foreach (IXLCell cell in row.Cells())
            ////                             dt.Rows[dt.Rows.Count - 1][i++] = cell.Value.ToString();

            ////                     }
            ////                 }
            ////                 dataGridView.DataContext = dt.DefaultView;

            ////             }

            ////}






            //Microsoft.Office.Interop.Excel.Application xlApp;
            //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            //Microsoft.Office.Interop.Excel.Range xlRang;


            //int xlRow;
            //string strfilName;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.Filter = "Excel Workbook|*.xlsx; *.xlsx";
            //openFileDialog1.ShowDialog();
            //strfilName = openFileDialog1.FileName;

            //if (strfilName != string.Empty)
            //{
            //    xlApp = new Microsoft.Office.Interop.Excel.Application();
            //    xlWorkBook = xlApp.Workbooks.Open(strfilName);
            //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets["Sheet1"];
            //    xlRang = xlWorkSheet.UsedRange;
            //    int i;
            //    for (xlRow = 2; xlRow <= xlRang.Rows.Count; xlRow++)
            //    {
            //        i++;

            //    }
            //    xlWorkBook.Close();
            //    xlApp.Quit();

            //}





        }

        private void btnOpen_Click_1(object sender, RoutedEventArgs e)
        {
            //    OpenFileDialog openfile = new OpenFileDialog();
            //    openfile.DefaultExt = ".xlsx";
            //    openfile.Filter = "(.xlsx)|*.xlsx";
            //    //openfile.ShowDialog();

            //    var browsefile = openfile.ShowDialog();

            //    if (browsefile == true)
            //    {
            //        txtFilePath.Text = openfile.FileName;

            //        Excel.Application excelApp = new Excel.Application();
            //        Excel.Workbook excelBook = excelApp.Workbooks.Open(txtFilePath.Text.ToString(), 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //        Excel.Worksheet excelSheet = (Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
            //        Excel.Range excelRange = excelSheet.UsedRange;





            //        string strCellData = "";
            //        double douCellData;
            //        int rowCnt = 0;
            //        int colCnt = 0;

            //        DataTable dt = new DataTable();
            //        for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
            //        {
            //            string strColumn = "";
            //            strColumn = (string)(excelRange.Cells[1, colCnt] as Excel.Range).Value2;
            //            dt.Columns.Add(strColumn, typeof(string));
            //        }

            //        for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
            //        {
            //            string strData = "";
            //            for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
            //            {
            //                try
            //                {
            //                    strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
            //                    strData += strCellData + "|";
            //                }
            //                catch (Exception ex)
            //                {
            //                    douCellData = (double)(excelRange.Cells[rowCnt, colCnt] as Excel.Range).Value2;
            //                    strData += douCellData.ToString() + "|";
            //                }
            //            }
            //            strData = strData.Remove(strData.Length - 1, 1);
            //            dt.Rows.Add(strData.Split('|'));
            //        }

            //        dtGrid.ItemsSource = dt.DefaultView;

            //        excelBook.Close(true, null, null);
            //        excelApp.Quit();
            //    }
        }

        private void btnOpen_Click_2(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel File |*.xls;*.xlsx;*.xlsm";
            Nullable<bool> result = openFile.ShowDialog();
            //if (openFile.ShowDialog() == DialogResult.HasValue)
            if ((bool)result)
            {

                //dataGridView.Rows.Clear();
                txtFilePath.Text = openFile.FileName;

                string name = "Sheet1";
                string constr= "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFilePath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                OleDbConnection Con = new OleDbConnection(constr);
                OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$]", Con);
                //OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$A1:G4]", Con);
                Con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
                DataTable data = new DataTable();
                sda.Fill(data);

                var test = data.Columns;
                foreach (var item in data.Rows)
                {
                    Console.WriteLine(item.ToString());
                    txtIns.Content = item.ToString();
                }
                
                
                //dataGridView.DataSource = data;

                //dataGridView.ReadOnly = true;
                //dataGridView.Columns[0].Width = 320;
                //dataGridView.ClearSelection();
            }

            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

        