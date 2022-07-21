using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhim
{
    public partial class Form1 : Form
    {
        const bool OFF = false;
        const bool ON = true;
        const string ADD = "ADD";
        const string EDIT = "EDIT";
        string updateType;
        TwooneEntities data = new TwooneEntities(); 
        public Form1()
        {
            InitializeComponent();
        }
        #region DBMethods
        public void LoadData()
        {
            var result = from c in data.Phims 
                         select new
                         {
                             c.MaPhim,
                             c.TenPhim,
                             c.NgaySanXuat,
                             c.NoiDungPhim,
                             c.NoiDungPhimTomTat,
                             c.DiemIMDB,
                             c.LuotXem,
                             c.ThoiLuong,
                             c.HinhBanner,
                             c.LinkPhim,
                             c.LinkPhimVip,
                             c.TrailerPhim
                         };
            dataGridPhim.DataSource = result.ToList();
        }
        public void AddMovie()
        {
            string TenPhim = txtTenPhim.Text;
            DateTime? NgaySanXuat = Convert.ToDateTime(txtNgaySanXuat.Text);
            string NoiDungPhim = txtNoiDung.Text;
            string NoiDungPhimTomTat = txtTomTat.Text;
            double? DiemIMDB = Convert.ToDouble(txtImdb.Text);
            int? LuotXem = Convert.ToInt32(txtLuotXem.Text);
            int? ThoiLuong = Convert.ToInt32(txtThoiLuong.Text);
            string HinhBanner = txtHinh.Text;
            string LinkPhim = txtLink.Text;
            string LinkPhimVip = txtLinkVip.Text;
            string TrailerPhim = txtTrailer.Text;
            Phim phim = new Phim()
            {
                TenPhim = TenPhim,
                NgaySanXuat = NgaySanXuat,
                NoiDungPhim = NoiDungPhim,
                NoiDungPhimTomTat = NoiDungPhimTomTat,
                DiemIMDB = DiemIMDB,
                LuotXem = LuotXem,
                ThoiLuong = ThoiLuong,
                HinhBanner = HinhBanner,
                LinkPhim = LinkPhim,
                LinkPhimVip = LinkPhimVip,
                TrailerPhim = TrailerPhim,
            };
            data.Phims.Add(phim);
            data.SaveChanges();
        }
        public void DeleteMovie()
        {
            int MaPhim = Convert.ToInt32(dataGridPhim.SelectedCells[0].OwningRow.Cells["MaPhim"].Value.ToString());
            Phim phim = data.Phims.Where(p => p.MaPhim == MaPhim).SingleOrDefault();
            data.Phims.Remove(phim);
            data.SaveChanges();
        }
        public void EditMovie()
        {
            int MaPhim = Convert.ToInt32(txtMaPhim.Text);
            string TenPhim = txtTenPhim.Text;
            DateTime? NgaySanXuat = Convert.ToDateTime(txtNgaySanXuat.Text);
            string NoiDungPhim = txtNoiDung.Text;
            string NoiDungPhimTomTat = txtTomTat.Text;
            double? DiemIMDB = Convert.ToDouble(txtImdb.Text);
            int? LuotXem = Convert.ToInt32(txtLuotXem.Text);
            int? ThoiLuong = Convert.ToInt32(txtThoiLuong.Text);
            string HinhBanner = txtHinh.Text;
            string LinkPhim = txtLink.Text;
            string LinkPhimVip = txtLinkVip.Text;
            string TrailerPhim = txtTrailer.Text;
            Phim phim = data.Phims.Where(p => p.MaPhim == MaPhim).FirstOrDefault();
            phim.TenPhim = TenPhim;
            phim.NgaySanXuat = NgaySanXuat;
            phim.NoiDungPhim = NoiDungPhim;
            phim.NoiDungPhimTomTat = NoiDungPhimTomTat;
            phim.DiemIMDB = DiemIMDB;
            phim.LuotXem = LuotXem;
            phim.ThoiLuong = ThoiLuong;
            phim.HinhBanner = HinhBanner;
            phim.LinkPhim = LinkPhim;
            phim.LinkPhimVip = LinkPhimVip;
            phim.TrailerPhim = TrailerPhim;
            //Phim phim = new Phim()
            //{
            //    MaPhim = MaPhim,
            //    TenPhim = TenPhim,
            //    NgaySanXuat = NgaySanXuat,
            //    NoiDungPhim = NoiDungPhim,
            //    NoiDungPhimTomTat = NoiDungPhimTomTat,
            //    DiemIMDB = DiemIMDB,
            //    LuotXem = LuotXem,
            //    ThoiLuong = ThoiLuong,
            //    HinhBanner = HinhBanner,
            //    LinkPhim = LinkPhim,
            //    LinkPhimVip = LinkPhimVip,
            //    TrailerPhim = TrailerPhim,
            //};
            data.Entry(phim).State = System.Data.Entity.EntityState.Modified;
            data.SaveChanges();
        }
        #endregion
        public void LockControl()
        {
            
            btnThem.Enabled = ON;
            btnXoa.Enabled = ON;
            btnSua.Enabled = ON;
            btnLuu.Enabled = OFF;
            btnHuy.Enabled = OFF;

            txtMaPhim.ReadOnly = ON;
            txtTenPhim.ReadOnly = ON;
            txtLuotXem.ReadOnly = ON;
            txtNgaySanXuat.ReadOnly = ON;
            txtImdb.ReadOnly = ON;
            txtThoiLuong.ReadOnly = ON;
            txtHinh.ReadOnly = ON;
            txtLink.ReadOnly = ON;
            txtLinkVip.ReadOnly = ON;
            txtTrailer.ReadOnly = ON;
            txtNoiDung.ReadOnly = ON;
            txtTomTat.ReadOnly = ON;

            txtMaPhim.Focus();
        }
        public void UnlockControl()
        {
            btnThem.Enabled = OFF;
            btnXoa.Enabled = OFF;
            btnSua.Enabled = OFF;
            btnLuu.Enabled = ON;
            btnHuy.Enabled = ON;

            txtMaPhim.ReadOnly = OFF;
            txtTenPhim.ReadOnly = OFF;
            txtLuotXem.ReadOnly = OFF;
            txtNgaySanXuat.ReadOnly = OFF;
            txtImdb.ReadOnly = OFF;
            txtThoiLuong.ReadOnly = OFF;
            txtHinh.ReadOnly = OFF;
            txtLink.ReadOnly = OFF;
            txtLinkVip.ReadOnly = OFF;
            txtTrailer.ReadOnly = OFF;
            txtNoiDung.ReadOnly = OFF;
            txtTomTat.ReadOnly = OFF;

            btnThem.Focus();
        }
        public void ClearInput()
        {
            txtMaPhim.Text = "";
            txtTenPhim.Text = "";
            txtLuotXem.Text = "";
            txtNgaySanXuat.Text = "";
            txtImdb.Text = "";
            txtThoiLuong.Text = "";
            txtHinh.Text = "";
            txtLink.Text = "";
            txtLinkVip.Text = "";
            txtTrailer.Text = "";
            txtNoiDung.Text = "";
            txtTomTat.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LockControl();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnlockControl();
            txtMaPhim.Enabled = OFF;
            updateType = ADD;
            ClearInput();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnlockControl();
            updateType = EDIT;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LockControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!checkData()) return;
            if (updateType == ADD)
            {
                AddMovie();
                    dataGridPhim.RefreshEdit();
            }
            else if (updateType == EDIT)
            {
                    EditMovie();
                    dataGridPhim.RefreshEdit();
            }
            LockControl();
        }
        public bool checkData()
        {
            if (string.IsNullOrWhiteSpace(txtTenPhim.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên phim", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPhim.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLuotXem.Text))
            {
                MessageBox.Show("Bạn chưa nhập lượt xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuotXem.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNgaySanXuat.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgaySanXuat.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtImdb.Text))
            {
                MessageBox.Show("Bạn chưa nhập điểm IMDb", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImdb.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtThoiLuong.Text))
            {
                MessageBox.Show("Bạn chưa nhập thời lượng phim", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThoiLuong.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHinh.Text))
            {
                MessageBox.Show("Bạn chưa nhập hình banner", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHinh.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLink.Text))
            {
                MessageBox.Show("Bạn chưa nhập link phim", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLink.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLinkVip.Text))
            {
                MessageBox.Show("Bạn chưa nhập link VIP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLinkVip.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTrailer.Text))
            {
                MessageBox.Show("Bạn chưa nhập link Trailer", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrailer.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Bạn chưa nhập nội dung phim", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNoiDung.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTomTat.Text))
            {
                MessageBox.Show("Bạn chưa nhập nội dung tóm tắt phim", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTomTat.Focus();
                return false;
            }
            return true;
        }
        private void dataGridPhim_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridPhim.CurrentRow.Index != -1)
            {
                int maPhim = Convert.ToInt32(dataGridPhim.CurrentRow.Cells["MaPhim"].Value);
                Phim phim = data.Phims.Where(p => p.MaPhim == maPhim).SingleOrDefault();
                if (phim == null) return;
                txtMaPhim.Text = phim.MaPhim.ToString();
                txtTenPhim.Text = phim.TenPhim;
                txtNgaySanXuat.Text = phim.NgaySanXuat.ToString();
                txtNoiDung.Text = phim.NoiDungPhim;
                txtTomTat.Text = phim.NoiDungPhimTomTat;
                txtImdb.Text = phim.DiemIMDB.ToString();
                txtLuotXem.Text = phim.NoiDungPhim;
                txtThoiLuong.Text = phim.LuotXem.ToString();
                txtHinh.Text = phim.HinhBanner;
                txtLink.Text = phim.LinkPhim;
                txtLinkVip.Text = phim.LinkPhimVip;
                txtTrailer.Text = phim.TrailerPhim;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa phim này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteMovie();
                dataGridPhim.RefreshEdit();
                ClearInput();
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
