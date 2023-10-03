using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DTO;
using DAL;

namespace LamThienTinh
{
    public partial class BD8_BD10Form : Form
    {

        // Danh sách chứa các bd8
        public List<BD8> dsBD8;

        // Danh sách chứa các bd10
        public List<BD10> dsBD10;

        // Dùng để đánh dấu chỉ mục của bd8 hiện tại trong danh sách bd8
        public int currentListIndex;

        // Dùng để đánh dấu chỉ mục của phiếu gửi hiện tại trong danh sách phiếu gửi
        public int currentItemsIndex;
        
        // Dùng để xác định các bd8 từ bưu cục hiện tại
        public int SHBuuCuc;

        public int tabIndex = 0;

        public BD8_BD10Form(int SHBuuCuc)
        {
            this.SHBuuCuc = SHBuuCuc;

            InitializeComponent();

            setControlsInfo();
            setTableHeaders();

            loadData();
            renderListTable();
            renderItemsTable();
        }

        // Đặt các thông tin về các controls trong form
        public void setControlsInfo()
        {
            // Chiều dài và rộng của form = 90% dài rộng của màn hình
            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.9);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.9);
            
            // Layout chứa nút thoát có chiều cao = 10% chiều cao của form
            tableLayoutPanel1.Height = Convert.ToInt32(this.Height * 0.1);
            tableLayoutPanel4.Height = Convert.ToInt32(this.Height * 0.1);

            
        }

        // Đọc dữ liệu danh sách bd8 từ cơ sở dữ liệu
        public void loadData()
        {
            if (tabIndex == 0)
            {
                dsBD8 = NhanVienKhaiThacDAL.getAllBD8(SHBuuCuc);
            }
            else
            {
                dsBD10 = NhanVienKhaiThacDAL.getAllBD10(SHBuuCuc);
            }
        }

        // Đặt tên cột cho các bảng
        public void setTableHeaders()
        {
            dsTuiDataGridView.Columns.Add("", "Số Hiệu");
            dsTuiDataGridView.Columns.Add("", "Ngày Đóng");
            dsBuuGuiDataGridView.Columns.Add("", "Số Hiệu");
            dsBuuGuiDataGridView.Columns.Add("", "Dịch Vụ");
            dsBuuGuiDataGridView.Columns.Add("", "BC Gốc");
            dsBuuGuiDataGridView.Columns.Add("", "BC Phát");
            dsBuuGuiDataGridView.Columns.Add("", "KL Cân Thực");
            dsBuuGuiDataGridView.Columns.Add("", "KL Quy Đổi");

            dsBD10DataGridView.Columns.Add("", "Số Hiệu");
            dsBD10DataGridView.Columns.Add("", "Ngày Đóng");
            dsTuiDataGridView2.Columns.Add("", "Số Hiệu");
            dsTuiDataGridView2.Columns.Add("", "Ngày Đóng");

            foreach (DataGridViewColumn column in dsTuiDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dsBuuGuiDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dsBD10DataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dsTuiDataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // Đưa dữ liệu bd8 vào bảng danh sách túi
        public void showListTable()
        {
            if (tabIndex == 0)
            {
                dsTuiDataGridView.Rows.Clear();
                foreach (BD8 b in dsBD8)
                {
                    dsTuiDataGridView.Rows.Add(new object[] { b.SH, b.NgayDong.ToShortDateString() });
                }
            }
            else
            {
                dsBD10DataGridView.Rows.Clear();
                foreach (BD10 b in dsBD10)
                {
                    dsBD10DataGridView.Rows.Add(new object[] { b.SH, b.NgayDong.ToShortDateString() });
                }
            }
        }

        // Kiểm tra trước khi hiển thị dữ liệu bảng danh sách túi
        public void renderListTable()
        {
            if (tabIndex == 0)
            {
                if (dsBD8 == null)
                {
                    dsTuiDataGridView.Rows.Clear();
                    currentListIndex = -1;
                    return;
                }
                currentListIndex = 0;
                showListTable();
                dsTuiDataGridView.Rows[currentListIndex].Cells[0].Selected = true;
            }
            else
            {
                if (dsBD10 == null)
                {
                    dsBD10DataGridView.Rows.Clear();
                    currentListIndex = -1;
                    return;
                }
                currentListIndex = 0;
                showListTable();
                dsBD10DataGridView.Rows[currentListIndex].Cells[0].Selected = true;
            }
        }

        // Đưa dữ liệu phiếu gửi vào bảng danh sách phiếu gửi
        public void showItemsTable()
        {
            if (tabIndex == 0)
            {
                dsBuuGuiDataGridView.Rows.Clear();

                // Biến tạm dùng để lưu tổng khối lượng bưu gửi
                int kl = 0;
                foreach (PhieuGui pg in dsBD8[currentListIndex].PhieuGui)
                {
                    dsBuuGuiDataGridView.Rows.Add(new object[]{pg.SH, pg.dichVu.Ten, pg.buuCucGui.Ten, pg.buuCucNhan.Ten
                        , pg.KhoiLuongCanThuc, pg.KhoiLuongQuyDoi});
                    kl += pg.KhoiLuongCanThuc;
                }
                soBuuGuiLabel.Text = dsBD8[currentListIndex].PhieuGui.Count.ToString();
                tongKhoiLuongBuuGuiLabel.Text = kl.ToString();
            }
            else
            {
                dsTuiDataGridView2.Rows.Clear();
                // Biến tạm dùng để lưu tổng khối lượng bưu gửi
                int kl = 0;
                foreach (BD8 b in dsBD10[currentListIndex].bd8)
                {
                    dsTuiDataGridView2.Rows.Add(new object[]{b.SH, b.NgayDong.ToShortDateString()});
                    foreach (PhieuGui pg in b.PhieuGui)
                    {
                        kl += pg.KhoiLuongCanThuc;
                    }
                }
                soTuiLabel.Text = dsBD10[currentListIndex].bd8.Count.ToString();
                tongKhoiLuongTuiLabel.Text = kl.ToString();
            }
        }

        // Kiểm tra trước khi hiển thị dữ liệu bảng danh sách phiếu gửi
        public void renderItemsTable()
        {
            if (tabIndex == 0)
            {
                if (dsBD8 == null || currentListIndex == -1 || dsBD8[currentListIndex].PhieuGui == null || dsBD8[currentListIndex].PhieuGui.Count == 0)
                {
                    dsBuuGuiDataGridView.Rows.Clear();
                    currentItemsIndex = -1;
                    soBuuGuiLabel.Text = "0";
                    tongKhoiLuongBuuGuiLabel.Text = "0";
                    return;
                }
                currentItemsIndex = 0;
                showItemsTable();
                dsBuuGuiDataGridView.Rows[currentItemsIndex].Cells[0].Selected = true;
            }
            else
            {
                if (dsBD10 == null || currentListIndex == -1 || dsBD10[currentListIndex].bd8 == null || dsBD10[currentListIndex].bd8.Count == 0)
                {
                    dsTuiDataGridView2.Rows.Clear();
                    currentItemsIndex = -1;
                    soTuiLabel.Text = "0";
                    tongKhoiLuongTuiLabel.Text = "0";
                    return;
                }
                currentItemsIndex = 0;
                showItemsTable();
                dsTuiDataGridView2.Rows[currentItemsIndex].Cells[0].Selected = true;
            }
        }

        // Bắt sự kiến thoát khỏi form
        private void thoatBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Bắt sự kiện mở form để chọn phiếu gửi
        private void SHTbx_KeyDown(object sender, KeyEventArgs e)
        {
            // Ấn f4 mới mở được form
            if (e.KeyCode == Keys.F4)
            {
                if (tabIndex == 0)
                {
                    // Không thể bỏ bưu gửi vào túi đã đóng được :))
                    // Vì túi đã đóng có số hiệu nên chỉ việc kiểm tra số hiệu của túi
                    if (dsBD8 == null || dsBD8[currentListIndex].SH != 0)
                    {
                        return;
                    }

                    // Không thể bỏ bưu gửi vào túi khi không có túi được :))
                    if (currentListIndex == -1)
                    {
                        new MessageDialog("Hãy chọn túi đóng");
                        return;
                    }

                    dsBD8[currentListIndex].PhieuGui = new List<PhieuGui>();

                    // Dùng tham chiếu để nhận các bưu gửi từ chonPhieuGuiForm
                    var chonPhieuGuiForm = new ChonItemsForm(SHBuuCuc, dsBD8[currentListIndex].PhieuGui, this);
                    renderItemsTable();                                                                                                                                                                                      
                }
                else
                {
                    // Không thể bỏ bưu gửi vào túi đã đóng được :))
                    // Vì túi đã đóng có số hiệu nên chỉ việc kiểm tra số hiệu của túi
                    if (dsBD10 == null || dsBD10[currentListIndex].SH != 0)
                    {
                        return;
                    }

                    // Không thể bỏ bưu gửi vào túi khi không có túi được :))
                    if (currentListIndex == -1)
                    {
                        new MessageDialog("Hãy chọn bđ10");
                        return;
                    }

                    dsBD10[currentListIndex].bd8= new List<BD8>();

                    // Dùng tham chiếu để nhận các bưu gửi từ chonPhieuGuiForm
                    var chonPhieuGuiForm = new ChonItemsForm(SHBuuCuc, dsBD10[currentListIndex].bd8, this);
                    renderItemsTable();
                }
            }
        }

        // Bắt sự kiện click vào ô trong danh sách túi
        private void listDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            currentListIndex = e.RowIndex;
            renderItemsTable();
            if (tabIndex == 0)
            {
                if (currentListIndex != -1)
                {
                    dsTuiDataGridView.Rows[currentListIndex].Cells[0].Selected = true;
                }
            }
            else
            {
                if (currentListIndex != -1)
                {
                    dsBD10DataGridView.Rows[currentListIndex].Cells[0].Selected = true;
                }
            }
        }

        // Bắt sự kiện xóa túi
        private void xoaBtn_Click(object sender, EventArgs e)
        {
            // currentListIndex == -1 nghĩa là danh sách BD8 rỗng thì không thể xóa
            if (currentListIndex == -1)
            {
                return;
            }
            ConfirmDialog cf = new ConfirmDialog("Xác nhận xóa");
            if (cf.confirm)
            {
                if (tabIndex == 0)
                {
                    // Thực hiện xóa
                    NhanVienKhaiThacDAL.xoaBD8(dsBD8[currentListIndex].SH);
                }
                else
                {
                    NhanVienKhaiThacDAL.xoaBD10(dsBD10[currentListIndex].SH);
                }
                loadData();
                renderListTable();
                renderItemsTable();
                new MessageDialog("Xóa thành công");
            }
            
        }

        // Bắt sự kiên xóa bưu gửi
        private void xoaItemsBtn_Click(object sender, EventArgs e)
        {
            if (tabIndex == 0)
            {
                // Nếu danh sách bưu gửi là rỗng hoặc túi chưa đóng thì không cần xóa
                if (currentItemsIndex == -1 || dsBD8[currentListIndex].SH == 0)
                {
                    return;
                }

                // Để thực hiện xóa túi cần 2 tham số là số hiệu túi và số hiệu phiếu gửi
                int SHBD8 = dsBD8[currentListIndex].SH;
                int SHBuuGui = dsBD8[currentListIndex].PhieuGui[currentItemsIndex].SH;

                ConfirmDialog cf = new ConfirmDialog("Xác nhận xóa");
                if (!cf.confirm)
                {
                    return;
                }

                // Nếu túi hiện tại có số bưu gửi == 1 thì xóa xong bưu gửi thì xóa luôn
                // cái túi
                if (dsBD8[currentListIndex].PhieuGui.Count == 1)
                {
                    NhanVienKhaiThacDAL.xoaBD8(SHBD8);
                    currentItemsIndex = -1;
                    dsBD8 = null;
                    loadData();
                    renderListTable();
                    renderItemsTable();
                }
                // Nếu túi hiện tại vẫn còn > 1 bưu gửi thì không cần xóa túi
                else
                {
                    NhanVienKhaiThacDAL.xoaBuuGuiKhoiBD8(SHBuuGui);
                    dsBD8[currentListIndex].PhieuGui.RemoveAt(currentItemsIndex);
                    currentItemsIndex = 0;
                    renderItemsTable();
                    dsBuuGuiDataGridView.Rows[currentItemsIndex].Cells[0].Selected = true;
                }
            }
            else
            {
                // Nếu danh sách bưu gửi là rỗng hoặc túi chưa đóng thì không cần xóa
                if (currentItemsIndex == -1 || dsBD10[currentListIndex].SH == 0)
                {
                    return;
                }

                // Để thực hiện xóa túi cần 2 tham số là số hiệu túi và số hiệu phiếu gửi
                int SHBD10 = dsBD10[currentListIndex].SH;
                int SHBD8 = dsBD10[currentListIndex].bd8[currentItemsIndex].SH;

                ConfirmDialog cf = new ConfirmDialog("Xác nhận xóa");
                if (!cf.confirm)
                {
                    return;
                }

                // Nếu túi hiện tại có số bưu gửi == 1 thì xóa xong bưu gửi thì xóa luôn
                // cái túi
                if (dsBD10[currentListIndex].bd8.Count == 1)
                {
                    NhanVienKhaiThacDAL.xoaBD10(SHBD10);
                    currentItemsIndex = -1;
                    dsBD10 = null;
                    loadData();
                    renderListTable();
                    renderItemsTable();
                }
                // Nếu túi hiện tại vẫn còn > 1 bưu gửi thì không cần xóa túi
                else
                {
                    NhanVienKhaiThacDAL.xoaBD8KhoiBD10(SHBD8);
                    dsBD10[currentListIndex].bd8.RemoveAt(currentItemsIndex);
                    currentItemsIndex = 0;
                    renderItemsTable();
                    dsTuiDataGridView2.Rows[currentItemsIndex].Cells[0].Selected = true;
                }
            }
            // Đưa ra thông báo xóa thành công
            new MessageDialog("Xóa thành công");
        }

        // Bắt sự kiện click vào ô trong danh sách bưu gửi
        private void itemsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            currentItemsIndex = e.RowIndex;
            if (tabIndex == 0)
            {
                if (currentItemsIndex != -1)
                {
                    dsBuuGuiDataGridView.Rows[currentItemsIndex].Cells[0].Selected = true;
                }
            }
            else
            {
                if (currentItemsIndex != -1)
                {
                    dsTuiDataGridView2.Rows[currentItemsIndex].Cells[0].Selected = true;
                }
            }
        }

        // Bắt sự kiện đóng túi
        private void xacNhanBtn_Click(object sender, EventArgs e)
        {
            // Không có túi làm sao mà đóng
            if (currentListIndex == -1)
            {
                return;
            }

            if (tabIndex == 0)
            {
                // Không có bưu gửi trong túi cũng không đóng được túi
                if (dsBD8[currentListIndex].PhieuGui == null || dsBD8[currentListIndex].PhieuGui.Count == 0)
                {
                    new MessageDialog("Bưu gửi rỗng");
                    return;
                }
                // Chỉ được đóng túi chưa có số hiệu
                if (dsBD8[currentListIndex].SH == 0)
                {
                    NhanVienKhaiThacDAL.lapBD8(dsBD8[currentListIndex]);
                    loadData();
                    renderListTable();
                    renderItemsTable();
                    new MessageDialog("Đóng túi thành công");
                }
            }
            else
            {
                // Không có bưu gửi trong túi cũng không đóng được túi
                if (dsBD10[currentListIndex].bd8 == null || dsBD10[currentListIndex].bd8.Count == 0)
                {
                    new MessageDialog("Túi rỗng");
                    return;
                }
                // Chỉ được đóng túi chưa có số hiệu
                if (dsBD10[currentListIndex].SH == 0)
                {
                    NhanVienKhaiThacDAL.lapBD10(dsBD10[currentListIndex]);
                    loadData();
                    renderListTable();
                    renderItemsTable();
                    new MessageDialog("Lập BĐ10 thành công");
                }
            }
        }

        // Bắt sự kiện thêm túi
        private void themBtn_Click(object sender, EventArgs e)
        {
            if (tabIndex == 0)
            {
                BD8 bd8 = new BD8();
                bd8.NgayDong = DateTime.Now;

                // Nếu danh sách bd8 rỗng thì khởi tạo
                // còn không thì thôi
                if (currentListIndex == -1)
                {
                    dsBD8 = new List<BD8>();
                }
                dsBD8.Add(bd8);

                // Thêm túi vừa tạo vào danh sách túi
                dsTuiDataGridView.Rows.Add(new object[] { "", bd8.NgayDong });
                currentListIndex = dsBD8.Count - 1;
                renderItemsTable();
                currentListIndex = dsBD8.Count - 1;
                dsTuiDataGridView.Rows[currentListIndex].Cells[0].Selected = true;
            }
            else
            {
                BD10 bd10 = new BD10();
                bd10.NgayDong = DateTime.Now;

                // Nếu danh sách bd8 rỗng thì khởi tạo
                // còn không thì thôi
                if (currentListIndex == -1)
                {
                    dsBD10 = new List<BD10>();
                }
                dsBD10.Add(bd10);

                // Thêm túi vừa tạo vào danh sách túi
                dsBD10DataGridView.Rows.Add(new object[] { "", bd10.NgayDong });
                currentListIndex = dsBD10.Count - 1;
                renderItemsTable();
                currentListIndex = dsBD10.Count - 1;
                dsBD10DataGridView.Rows[currentListIndex].Cells[0].Selected = true;
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            tabIndex = e.TabPageIndex;
            loadData();
            currentListIndex = -1;
            currentItemsIndex = -1;
            renderListTable();
            renderItemsTable();
        }
    }
}

