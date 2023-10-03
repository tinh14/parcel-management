using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DAL;
using DTO;

namespace LamThienTinh
{
    public partial class Home : Form
    {
        // Danh sách chứa các phiếu gửi
        private List<PhieuGui> dsPhieuGui;

        // Chứa thông tin nhân viên
        public NhanVien nhanVien;

        public Home()
        {
            InitializeComponent();
            setLoginPanelInfo();
            setTableHeaders();
        }

        private void setLoginPanelInfo()
        {
            // focus vào tên đăng nhập, tiện lợi cho người sử dụng
            usernameTbx.Select();

            // Đặt dangNhapPanel rộng cao đầy 
            dangNhapPanel.Dock = DockStyle.Fill;

            // Hiển thị dangNhapPanel
            dangNhapPanel.Visible = true;
        }

        // Đặt thông tin các controls trong form
        private void setNVPanelInfo()
        {
            // nvControlPanel rộng bằng 30% màn hình
            nvControlPanel.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.3);

            // Các controls trong nvControlPanel cao bằng 15% chiều nvControlPanel;
            foreach (Control ct in nvControlPanel.Controls)
            {
                ct.Height = Convert.ToInt32(nvControlPanel.Width * 0.15);
            }

            // dsPhieuGuiControlPanel cao bằng 10% chiều cao màn hình
            dsPhieuGuiControlPanel.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.1);

            // Ẩn dangNhapPanel và hiển thị nvPanel
            dangNhapPanel.Visible = false;
            nvPanel.Dock = DockStyle.Fill;
            nvPanel.Visible = true;
        }

        private void setTableHeaders()
        {
            // Lấy tên các cột để hiển thị
            List<String> PropertiesName = PhieuGui.getAllProperties();
            foreach (String name in PropertiesName)
            {
                dsPhieuGuiTable.Columns.Add("", name);
            }
            foreach (DataGridViewColumn column in dsPhieuGuiTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // Đọc danh sách phiếu gửi từ csd;
        private void loadData()
        {
            dsPhieuGui = NhanVienGiaoDichDAL.danhSachPhieuGui(nhanVien.buuCuc.SH);
        }

        // Refresh lại bảng danh sách phiếu gửi
        private void renderTable(List<PhieuGui> dspg)
        {
            dsPhieuGuiTable.Rows.Clear();

            List<String> PropertiesName = PhieuGui.getAllProperties();

            // Nếu danh sách phiếu gửi không rỗng thì mới hiển thị
            if (dsPhieuGui.Count != 0)
            {
                // Dùng Reflection để hiển thị dữ liệu cho nhanh
                PropertyInfo[] props = typeof(PhieuGui).GetProperties();
                foreach (PhieuGui pg in dspg)
                {
                    List<String> vals = new List<String>();
                    for (int i = 0; i < PropertiesName.Count; i++)
                    {
                        // Nếu là cột ngày chấp nhận chỉ hiển thị
                        // ngày tháng năm, không cần hiển thị giờ, phút, giây
                        if (props[i].Name.CompareTo("NgayChapNhan") == 0)
                        {
                            var a = (DateTime)props[i].GetValue(pg, null);
                            vals.Add(a.ToString("dd/MM/yyyy"));
                        }
                        else
                        {
                            vals.Add(props[i].GetValue(pg, null).ToString());
                        }
                    }
                    dsPhieuGuiTable.Rows.Add(vals.ToArray());
                }
            }
        }

        // Hiển thị form của nhân viên giao dịch
        private void nhanVienGiaoDichForm()
        {
            lapBD8Btn.Enabled = false;
            lapBD8Btn.BackColor = SystemColors.ControlLight;

            lenTuyenPhatBtn.Enabled = false;
            lenTuyenPhatBtn.BackColor = SystemColors.ControlLight;

            loadData();
            renderTable(dsPhieuGui);
        }

        // Hiển thị form của nhân viên khai thác
        private void nhanVienKhaiThacForm()
        {
            lapPhieuGuiBtn.Enabled = false;
            lapPhieuGuiBtn.BackColor = SystemColors.ControlLight;

            thongKeBtn.Enabled = false;
            thongKeBtn.BackColor = SystemColors.ControlLight;

            chiTietPhieuGuiBtn.Enabled = false;
            chiTietPhieuGuiBtn.BackColor = SystemColors.ControlLight;

            xoaPhieuGuiBtn.Enabled = false;
            xoaPhieuGuiBtn.BackColor = SystemColors.ControlLight;

            searchTb.Enabled = false;
            xoaPhieuGuiBtn.BackColor = SystemColors.ControlLight;

            dsPhieuGuiTable.Visible = false;

            lenTuyenPhatBtn.Enabled = false;
            lenTuyenPhatBtn.BackColor = SystemColors.ControlLight;

        }

        // Hiển thị form của nhân viên vận chuyển
        private void nhanVienVanChuyenForm()
        {
            lapPhieuGuiBtn.Enabled = false;
            lapPhieuGuiBtn.BackColor = SystemColors.ControlLight;

            thongKeBtn.Enabled = false;
            thongKeBtn.BackColor = SystemColors.ControlLight;

            chiTietPhieuGuiBtn.Enabled = false;
            chiTietPhieuGuiBtn.BackColor = SystemColors.ControlLight;

            xoaPhieuGuiBtn.Enabled = false;
            xoaPhieuGuiBtn.BackColor = SystemColors.ControlLight;

            searchTb.Enabled = false;
            xoaPhieuGuiBtn.BackColor = SystemColors.ControlLight;

            dsPhieuGuiTable.Visible = false;

            lapBD8Btn.Enabled = false;
            lapBD8Btn.BackColor = SystemColors.ControlLight;
        }

        // Bắt sự kiện đăng nhập
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string tenDangNhap = usernameTbx.Text;
            string matKhau = passwordTbx.Text;
            this.nhanVien = NhanVienDAL.dangNhap(tenDangNhap, matKhau);
            if (nhanVien == null)
            {
                new MessageDialog("Tên đăng nhập hoặc mật khẩu không đúng");
                return;
            }

            setNVPanelInfo();

            // Hiển thị form phù hợp
            string loaiNhanVien = nhanVien.Loai.ToLower();
            if (loaiNhanVien.CompareTo("giao dịch") == 0)
            {
                nhanVienGiaoDichForm();
            }
            else if (loaiNhanVien.CompareTo("khai thác") == 0)
            {
                nhanVienKhaiThacForm();
            }
            else
            {
                nhanVienVanChuyenForm();
            }
        }

        // Bắt sự kiện đổi tài khoản
        private void changeAccountBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        // Hiển thị chi tiết phiếu gửi
        private void chiTietPhieuGuiBtn_Click(object sender, EventArgs e)
        {
            if (dsPhieuGui.Count == 0){
                return;
            }

            // Hiển thị form chứ thông tin của bưu gửi được chọn
            int index = dsPhieuGuiTable.CurrentCell.RowIndex;
            var form = new ChiTietPhieuGuiForm(dsPhieuGui[index], nhanVien.buuCuc);
            DialogResult res = form.ShowDialog();
            
            // Nếu người dùng ấn lập/cập nhật thì render lại bảng
            if (res.CompareTo(DialogResult.OK) == 0)
            {
                searchTb.Text = "";
                loadData();
                renderTable(dsPhieuGui);
           } 
        }

        // Bắt sự kiên xóa phiếu gửi
        private void xoaPhieuGuiBtn_Click(object sender, EventArgs e)
        {
            if (dsPhieuGuiTable.RowCount == 0)
            {
                return;
            }

            // Hiển thị form xác nhận
            ConfirmDialog cf = new ConfirmDialog("Xác nhận xóa");

            // Nếu xác nhận xóa thì render lại bảng
            if (cf.confirm)
            {
                int index = dsPhieuGuiTable.CurrentCell.RowIndex;
                int SHPhieuGui = dsPhieuGui[index].SH;
                NhanVienGiaoDichDAL.xoaPhieuGui(SHPhieuGui);
                new MessageDialog("Xóa thành công");
                loadData();
                renderTable(dsPhieuGui);
            }
        }

        // Bắt sự kiện lập phiếu gửi
        private void lapPhieuGuiBtn_Click(object sender, EventArgs e)
        {
            // Hiển thị form chi tiết phiếu gửi của phiếu gửi hiện tại
            // và phiếu gửi hiện tại là null
            var form = new ChiTietPhieuGuiForm(null, nhanVien.buuCuc);
            DialogResult res = form.ShowDialog();
            
            // Nếu lập thành công thì render lại bảng
            if (res.CompareTo(DialogResult.OK) == 0)
            {
                loadData();
                renderTable(dsPhieuGui);
            }
        }

        // Bắt sự kiện tìm kiếm phiếu gửi
        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Danh sách phiếu gửi rỗng thì không thể tìm kiếm
                if (dsPhieuGui.Count == 0){
                    return;
                }

                // Ô tìm kiếm rỗng thì không cần tìm
                if (searchTb.Text == "")
                {
                    renderTable(dsPhieuGui);
                    return;
                }

                // Vì phiếu gửi khi được lấy ra từ csld mặc định
                // đã được sắp xếp không giảm theo số hiệu và số hiệu đó
                // cũng có tính chất là duy nhất. Nên có thể sử
                // dụng tìm kiếm nhị phân đơn giản để tìm phiếu gửi
                // nhanh chóng với trường hợp xấu nhất O(Log(N)) trong
                // đó N là số lượng phiếu gửi trong danh sách
                int SHPhieuGui = Convert.ToInt32(searchTb.Text);
                int index = -1;
                int l = 0;
                int r = dsPhieuGui.Count - 1;
                while (l <= r)
                {
                    int m = (l + r) / 2;
                    if (dsPhieuGui[m].SH == SHPhieuGui)
                    {
                        index = m;
                        break;
                    }
                    else if (dsPhieuGui[m].SH < SHPhieuGui)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }

                // Mặc dù chỉ có 1 phiếu gửi được tìm thấy
                // nhưng hàm refeshTable có tham số là một danh sách
                // nên ta tạo một danh sách để lưu phiếu gửi này vào
                // và gọi hàm renderTable
                List<PhieuGui> temp = new List<PhieuGui>();
                if (index != -1)
                {
                    temp.Add(dsPhieuGui[index]);
                    renderTable(temp);
                }
                else
                {
                    renderTable(temp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // Bắt sự kiện thống kê
        private void thongKeBtn_Click(object sender, EventArgs e)
        {
            // Hiển thị form thống kê
            var thongKeForm = new ThongKeForm(nhanVien.buuCuc.SH);
            thongKeForm.ShowDialog();
        }

        // Bắt sự kiện lập BD8
        private void dongChuyenThuBtn_Click(object sender, EventArgs e)
        {
            // Hiển thị form BD8
            var bd8Form = new BD8_BD10Form(nhanVien.buuCuc.SH);
            bd8Form.ShowDialog();
        }

        // Bắt sự kiện thoát
        private void thoatBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lenTuyenPhatBtn_Click(object sender, EventArgs e)
        {
            var form = new LenTuyenPhatForm(nhanVien.buuCuc.SH);
            form.ShowDialog();
        }
    }
}
