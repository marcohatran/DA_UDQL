using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using System.Data.Linq;

namespace WindowsFormsApplication1.Object
{
    public class myExcel
    {
        //System.IO.FileStream fs = new System.IO.FileStream(string path, System.IO.FileMode mode);
        static public void Export(System.Data.DataTable dt)
        {
            //Tạo các đối tượng Excel
            //Tao file
            string path = "Questions.xlsx";
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);
            fs.Close();
            fs.Dispose();
            Excel.Application oExcel = new Excel.Application();
            //lấy tên path của trương trình replace tên file
            string s = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.ToString();
            string s2 = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string s3 = s2.Replace(s, path);
            Excel.Workbook oBook = oExcel.Workbooks.Open(s3);
            Excel.Worksheet oSheet = (Excel.Worksheet)oBook.Sheets.get_Item(1);

            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                System.Data.DataRow dr = dt.Rows[r];
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    arr[r, c] = dr[c];
                }
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 1;
            int columnStart = 1;
            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = dt.Columns.Count;

            // Ô bắt đầu điền dữ liệu
            Excel.Range c1 = (Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu
            Excel.Range c2 = (Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu
            Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            oBook.Save();
            oBook.Close(true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            oExcel.Quit();
        }

        public static void read(string link)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(link);
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
            // Lấy phạm vi dữ liệu
            Excel.Range xlRange = xlWorksheet.UsedRange;
            // Tạo mảng lưu trữ dữ liệu
            object[,] valueArray = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

            // Hiển thị nọi dung
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var qtable = db.Questions;
                for (int row = 1; row <= xlWorksheet.UsedRange.Rows.Count; row++)//đọc row hiện có trong Excel
                {
                    int colum = 1;
                    var q = new Question()
                    {
                        question = valueArray[row, colum++].ToString(),
                        answerA = valueArray[row, colum++].ToString(),
                        answerB = valueArray[row, colum++].ToString(),
                        answerC = valueArray[row, colum++].ToString(),
                        answerD = valueArray[row, colum++].ToString(),
                        answerTrue = valueArray[row, colum++].ToString(),
                        hardlevel = int.Parse(valueArray[row, colum++].ToString()),
                        subject = valueArray[row, colum++].ToString(),
                        grade = int.Parse(valueArray[row, colum].ToString())
                    };
                    if(MyTool.SoCauHoiTrung(q.question)==0 && MyTool.SoCauHoiTrung2(q.question, qtable) == 0) qtable.InsertOnSubmit(q);
                }
                db.SubmitChanges();
            }
            // Đóng Workbook.
            xlWorkbook.Close(false);
            // Đóng application.
            xlApp.Quit();
            //Khử hết đối tượng
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        }
    }
    public class MyTool
    {
        public static int SoCauHoiTrung(string CauHoi)
        {
            int r = 0;
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var p = db.Questions.Where(q => q.question == CauHoi).Select(q => q);
                r = p.Count();
            }
            return r;
        }
        public static int SoCauHoiTrung2(string CauHoi, Table<Question> listqs)
        {
            int r = 0;
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var p = listqs.Where(q => q.question == CauHoi).Select(q => q);
                r = p.Count();
            }
            return r;
        }
        public static string getHashString(string s)
        {
            var sha = SHA1.Create();
            return BitConverter.ToString(sha.ComputeHash(Encoding.ASCII.GetBytes(s))).Replace("-", "");
        }
        public static System.Data.DataTable ConvertToDataTable(List<Question> data)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            foreach(Question q in data)
            {
                dt.Rows.Add(q.question, q.answerA, q.answerB, q.answerC, q.answerD, q.answerTrue, q.hardlevel, q.subject, q.grade);
            }
            return dt;
        }
    }
}
