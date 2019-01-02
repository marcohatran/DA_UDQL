using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.GUI
{
    public partial class frmTracNghiem : Form
    {
        Student my;
        int k = 0;
        List<string> AllDapAn = new List<string>();//lưu đáp án ban đầu của tất cả câu hỏi
        List<string> dsCauHoiCheck = new List<string>();
        int[] arr = new int[] { 1, 11, 21, 31, 41, 51 };
        Random rd = new Random();
        Timer BoDemTime;

        struct thongtin
        {
            public static bool active;
            public static bool x;//cờ hiệu
            public static int SoLuongHoanTat;//số lượng câu đã làm
            public static int time;
            public static int idKiThi;//id của kì thi
            public static int SoDiem;
            public static string monhoc;

            public static int idCauHoiDau;//giữ id idQuesttion đầu
            public static int idCauHoiCuoi;//giữ id idQuestion cuối
            public static int idCauHoiHienTai;//id của question hiện tại
            public static int sttCauHoi;//số thứ tự của label câu hỏi
        }

        private void InitThongTin()
        {            
            thongtin.sttCauHoi = 1;
            thongtin.active = false;
            thongtin.x = true;//cờ hiệu
        }       
             
        public frmTracNghiem(int id, int idexam)
        {
            InitializeComponent();
            thongtin.idKiThi = idexam;
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                my = db.Students.Where(s => s.idAccount == id).SingleOrDefault();
                var loaiKiThi = (from k in db.Examinations where k.idExamination == thongtin.idKiThi select k.type).ToArray();
                if (loaiKiThi[0].ToString() == "thi thử")
                {
                    btnGoiY.Visible = true;
                }
            }
            
            loadTracNghiem();
        }       

        public void ResetText_TracNghiem()
        {
            lblSttCau.ResetText();
            lblCauA.ResetText();
            lblCauB.ResetText();
            lblCauC.ResetText();
            lblCauD.ResetText();
        }

        private void runtimer(object sender, EventArgs e)
        {
            if (thongtin.time > 0)
            {
                lblTime.Text = thongtin.time.ToString();
                thongtin.time--;
            }
            else
            {
                //xử lý kết thúc khi hết thời gian
                lblTime.Text = "0";
                thongtin.active = false;               
                BoDemTime.Dispose();
                MessageBox.Show("Đã  thời gian làm bài");
                btnNopBai_Click_1(sender, e);
            }
        }

        //frm gọi đầu tiên
        public void loadTracNghiem()
        {
            BoDemTime = new Timer();
            BoDemTime.Tick += new EventHandler(runtimer);
            BoDemTime.Interval = 1000;

            InitThongTin();//khởi tạo biến thông tin            
            var font = new Font("Wingdings 3", 14f);
            btnVeDau.Font = font;
            btnVeDau.Text = ((char)0x29).ToString();

            btnVeCuoi.Font = font;
            btnVeCuoi.Text = ((char)0x2A).ToString();

            btnTruoc.Font = font;
            btnTruoc.Text = ((char)0x21).ToString();

            btnSau.Font = font;
            btnSau.Text = ((char)0x22).ToString();

            int tmp_rand = rd.Next(0, 5);//random gói câu hỏi
            thongtin.idCauHoiDau = arr[tmp_rand];
            thongtin.idCauHoiHienTai = thongtin.idCauHoiDau;
            thongtin.idCauHoiCuoi = thongtin.idCauHoiDau + 9;

            loadDataTracNghiem(thongtin.idCauHoiHienTai);//load form            
            foreach (Control c in grbTraLoi.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control c1 in c.Controls)
                    {
                        if (c1 is RadioButton)
                        {
                            RadioButton radio = c1 as RadioButton;
                            radio.Click += Radio_Click;
                        }
                    }
                }
            }
            if (!thongtin.active)
            {
                BoDemTime.Start();
                thongtin.active = true;
            }
            else
            {
                BoDemTime.Stop();
                thongtin.active = false;
            }
        }
        public void loadDataTracNghiem(int idCauHoiHienTai)
        {
            //khởi tạo bindingSource
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                Table<Question> ques = db.GetTable<Question>();
                //đổ dữ liệu vô combobox
                var khoi = (from k in db.Classes where k.className == my.@class select k.grade).SingleOrDefault();
                var subject = (from q in db.Tests where q.grade == khoi select q.subject).Distinct().ToList();
                cbbMon.DataSource = subject;

                //số lượng tất cả câu hỏi
                var arr_dapAn = (from q in ques select q.answerTrue).ToArray();
                if (thongtin.x == true)
                {
                    foreach (string str in arr_dapAn)
                    {
                        AllDapAn.Add(str);//có được mảng các đáp án đúng của bộ câu các câu hỏi
                    }
                    thongtin.x = false;
                }
            }
        }

        //đếm số câu đã làm
        private void Radio_Click(object sender, EventArgs e)
        {
            var r = sender as RadioButton;
            if (dsCauHoiCheck.Count == 0)
            {
                dsCauHoiCheck.Add(r.Parent.Name);//r.Parent.Name lấy Name của groupBox chứa radio đang click
                thongtin.SoLuongHoanTat++;
            }
            else
            {
                int len = dsCauHoiCheck.Count;
                if (!dsCauHoiCheck.Contains(r.Parent.Name))
                {
                    thongtin.SoLuongHoanTat++;
                    dsCauHoiCheck.Add(r.Parent.Name);
                }
            }
            this.lblSoCauHoanThanh.Text = "Hoàn thành: " + thongtin.SoLuongHoanTat + "/10";
        }

        private void loadCauHoiTracNghiem(string monhoc)
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var tmp = (from t in db.Test_Examinations from f in db.Question_Tests from q in db.Questions where t.idExamination == thongtin.idKiThi && t.idTest == f.idTest && f.idQuestion == q.idQuestion select q).Distinct().ToArray();
                //var Question_idQuesCurrent = (from q in db.Questions where q.idQuestion == thongtin.idCauHoiHienTai && q.subject == monhoc select q).ToArray();
                var CauHoi = new Question();

                CauHoi.question = tmp[k].question.ToString();
                CauHoi.answerA = tmp[k].answerA.ToString();
                CauHoi.answerB = tmp[k].answerB.ToString();
                CauHoi.answerC = tmp[k].answerC.ToString();
                CauHoi.answerD = tmp[k].answerD.ToString();
                CauHoi.answerTrue = tmp[k].answerTrue.ToString();

                //CauHoi.question = Question_idQuesCurrent[0].question.ToString();
                //CauHoi.answerA = Question_idQuesCurrent[0].answerA.ToString();
                //CauHoi.answerB = Question_idQuesCurrent[0].answerB.ToString();
                //CauHoi.answerC = Question_idQuesCurrent[0].answerC.ToString();
                //CauHoi.answerD = Question_idQuesCurrent[0].answerD.ToString();
                //CauHoi.answerTrue = Question_idQuesCurrent[0].answerTrue.ToString();

                lblSttCau.Text = "CÂU " + thongtin.sttCauHoi.ToString() + ": " + CauHoi.question;
                lblCauA.Text = "A) " + CauHoi.answerA;
                lblCauB.Text = "B) " + CauHoi.answerB;
                lblCauC.Text = "C) " + CauHoi.answerC;
                lblCauD.Text = "D) " + CauHoi.answerD;
            }
            k++;
        }

        private List<string> layPhieuTraLoi()
        {
            string result1 = "";
            List<string> da = new List<string>();//lưu đáp án trả lời
            //tìm radio đã check trong grbCau1
            foreach (Control control in this.grbCau1.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);//Lấy kí tự đầu của radio đáp án chọn
                        da.Add(result1);
                    }
                }
            }
            foreach (Control control in this.grbCau2.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);
                        da.Add(result1);
                    }
                }
            }
            foreach (Control control in this.grbCau3.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);
                        da.Add(result1);
                    }
                }
            }
            foreach (Control control in this.grbCau4.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);
                        da.Add(result1);
                    }
                }
            }
            foreach (Control control in this.grbCau5.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);
                        da.Add(result1);
                    }
                }
            }
            foreach (Control control in this.grbCau6.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);
                        da.Add(result1);
                    }
                }
            }
            foreach (Control control in this.grbCau7.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);
                        da.Add(result1);
                    }
                }
            }

            foreach (Control control in this.grbCau8.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);
                        da.Add(result1);
                    }
                }
            }
            foreach (Control control in this.grbCau9.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);
                        da.Add(result1);
                    }
                }
            }

            foreach (Control control in this.grbCau10.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked)
                    {
                        result1 = (radio.Name).Substring(0, 1);
                        da.Add(result1);
                    }
                }
            }
            return da;
        }      
            
        //lưu kết quả
        private void luuKetQuaThi(int diem)
        {
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                Result r = new Result();
                try
                {
                    r.idExamination = thongtin.idKiThi;
                    r.idStudent = my.idStudent;
                    r.subject = thongtin.monhoc;
                    r.score = thongtin.SoDiem;

                    db.Results.InsertOnSubmit(r);
                    db.SubmitChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Học sinh đã thi môn học này tại học kì này, Không ghi nhận kết quả", "Không Lưu Được Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
              
        private void btnVeDau_Click_1(object sender, EventArgs e)
        {
            thongtin.idCauHoiHienTai = thongtin.idCauHoiDau;
            thongtin.sttCauHoi = 1;
            ResetText_TracNghiem();
            loadDataTracNghiem(thongtin.idCauHoiHienTai);
        }

        private void btnTruoc_Click_1(object sender, EventArgs e)
        {
            if (thongtin.idCauHoiHienTai == thongtin.idCauHoiDau)
            {
                thongtin.idCauHoiHienTai = thongtin.idCauHoiCuoi;
                thongtin.sttCauHoi = 10;
            }
            else
            {
                thongtin.idCauHoiHienTai -= 1;
                thongtin.sttCauHoi -= 1;
            }
            ResetText_TracNghiem();
            loadDataTracNghiem(thongtin.idCauHoiHienTai);
        }

        private void btnSau_Click_1(object sender, EventArgs e)
        {
            if (thongtin.idCauHoiHienTai == thongtin.idCauHoiCuoi)
            {
                thongtin.idCauHoiHienTai = thongtin.idCauHoiDau;
                thongtin.sttCauHoi = 1;
            }
            else
            {
                thongtin.idCauHoiHienTai += 1;
                thongtin.sttCauHoi += 1;
            }
            ResetText_TracNghiem();
            loadDataTracNghiem(thongtin.idCauHoiHienTai);
        }

        private void btnVeCuoi_Click_1(object sender, EventArgs e)
        {
            thongtin.idCauHoiHienTai = thongtin.idCauHoiCuoi;
            thongtin.sttCauHoi = 10;
            ResetText_TracNghiem();
            loadDataTracNghiem(thongtin.idCauHoiHienTai);
        }

        private void btnNopBai_Click_1(object sender, EventArgs e)
        {           
            List<string> da = new List<string>();//lưu câu trả lời của phiếu đáp án
            da = layPhieuTraLoi();
            if (da.Count > 0 || thongtin.active != true)
            {
                BoDemTime.Dispose();
                for (int i = 0; i < thongtin.SoLuongHoanTat; i++)
                {
                    if (da[i] == AllDapAn[i + thongtin.idCauHoiDau - 1])
                    {
                        thongtin.SoDiem++;
                    }
                }
                MessageBox.Show("Đúng:"+thongtin.SoDiem.ToString()+"   Sai:"+(10 - thongtin.SoDiem).ToString() + "    Điểm:" +thongtin.SoDiem.ToString());
                //Lưu kết quả
                using (var db = new dbQLThiTracNghiemDataContext())
                {
                    var loaiKiThi = (from k in db.Examinations where k.idExamination == thongtin.idKiThi select k.type).ToArray();
                    if (loaiKiThi[0].ToString() == "thi thật")
                    {
                        luuKetQuaThi(thongtin.SoDiem);
                    }
                }
                thongtin.SoLuongHoanTat = 0;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Chưa hoàn thành bài làm", "Chưa Hoàn Thành", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                      
        }

        private void cbbMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            thongtin.monhoc = cbbMon.SelectedItem.ToString();
            using (var db = new dbQLThiTracNghiemDataContext())
            {
                var khoi = (from k in db.Classes where k.className == my.@class select k.grade).First();
                var thoigian = (from t in db.Tests where t.grade == khoi && t.subject == thongtin.monhoc select t.time);
                if (thoigian.Count() > 0 && thongtin.active == false)
                {
                    thongtin.time = (int)thoigian.First();
                }
            }
            loadCauHoiTracNghiem(thongtin.monhoc);
        }

        private void btnGoiY_Click(object sender, EventArgs e)
        {
            frmGoiYDapAn gy = new frmGoiYDapAn(AllDapAn);
            gy.ShowDialog();
        }
    }
}
