using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using DAL;

namespace LamThienTinh
{
    public partial class ChonItemsForm : Form
    {
        // Danh sách phiếu gửi được BD8From
        // tham chiếu đến
        private List<PhieuGui> PhieuGuiBD8;
        private List<BD8> BD10_BD8;
        private List<PhieuGui> PhieuGuiPhat;

        // Danh sách chứa các phiếu gửi
        public List<PhieuGui> dsPhieuGui;

        public List<BD8> dsBD8;

        public int tabIndex;

        // Dùng để xác định các bd8 từ bưu cục hiện tại
        public int SHBuuCuc;

        public ChonItemsForm(int SHBuuCuc, List<PhieuGui> parentList, BD8_BD10Form form)
        {
            InitializeComponent();
            setControlsInfo();
            setTableHeaders();
            setData(SHBuuCuc, parentList);
            renderTableData();
            this.ShowDialog();
        }

        public ChonItemsForm(int SHBuuCuc, List<BD8> parentList, BD8_BD10Form form)
        {
            InitializeComponent();
            setControlsInfo();
            setTableHeaders();
            setData(SHBuuCuc, parentList);
            renderTableData();
            this.ShowDialog();
        }

        public ChonItemsForm(int SHBuuCuc, List<PhieuGui> parentList, LenTuyenPhatForm form)
        {
            InitializeComponent();
            setControlsInfo();
            setTableHeaders();
            setData(SHBuuCuc, parentList, form);
            renderTableData();
            this.ShowDialog();
        }


        // Đặt các thông tin về các controls trong form
        public void setControlsInfo()
        {
            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.8);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.8);
        }

        // Đặt tên cột cho các bảng và xử lý việc chỉ đọc
        public void setTableHeaders()
        {
            // Đặt cột đầu tiên là checkbox
            DataGridViewCheckBoxColumn cb = new DataGridViewCheckBoxColumn();
            cb.HeaderText = "CHỌN";
            dsItemsDataGridView.Columns.Add(cb);
            dsItemsDataGridView.Columns.Add("", "SỐ HIỆU");

            // Đặt cột thứ 2 chỉ được đọc
            dsItemsDataGridView.Columns[1].ReadOnly = true;

            foreach (DataGridViewColumn column in dsItemsDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // Đặt tham chiếu và nhận dữ liệu từ csdl
        public void setData(int SHBuuCuc, List<PhieuGui> parentList)
        {
            this.SHBuuCuc = SHBuuCuc;
            this.PhieuGuiBD8 = parentList;
            this.dsPhieuGui = NhanVienKhaiThacDAL.danhSachPhieuGuiChuaLapBD8(SHBuuCuc);
            tabIndex = 0;
        }

        public void setData(int SHBuuCuc, List<BD8> parentList)
        {
            this.SHBuuCuc = SHBuuCuc;
            this.BD10_BD8 = parentList;
            this.dsBD8 = NhanVienKhaiThacDAL.danhSachBD8ChuaLapBD10(SHBuuCuc);
            tabIndex = 1;
        }

        public void setData(int SHBuuCuc, List<PhieuGui> parentList, LenTuyenPhatForm form)
        {
            this.SHBuuCuc = SHBuuCuc;
            this.PhieuGuiPhat = parentList;
            this.dsPhieuGui = NhanVienVanChuyenDAL.danhSachPhieuGuiChuaPhat(SHBuuCuc);
            tabIndex = 2;
        }

        // Hiển thị danh sách phiếu gửi
        public void renderTableData()
        {
            if (tabIndex == 0)
            {
                if (dsPhieuGui == null)
                {
                    return;
                }
                foreach (PhieuGui pg in dsPhieuGui)
                {
                    dsItemsDataGridView.Rows.Add(new object[] { CheckState.Unchecked, pg.SH });
                }
            }
            else if (tabIndex == 1)
            {
                if (dsBD8 == null)
                {
                    return;
                }
                foreach (BD8 b in dsBD8)
                {
                    dsItemsDataGridView.Rows.Add(new object[] { CheckState.Unchecked, b.SH });
                }
            }
            else
            {
                if (dsPhieuGui == null)
                {
                    return;
                }
                foreach (PhieuGui pg in dsPhieuGui)
                {
                    dsItemsDataGridView.Rows.Add(new object[] { CheckState.Unchecked, pg.SH });
                }
            }
        }

        // Kiểm tra phiếu gửi nào được chọn để đưa vào danh sách được tham chiếu 
        private void closeBtn_Click(object sender, EventArgs e)
        {
            int len = dsItemsDataGridView.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                bool isChecked = Convert.ToBoolean(dsItemsDataGridView.Rows[i].Cells[0].Value);
                if (isChecked)
                {
                    if (tabIndex == 0)
                    {
                        PhieuGuiBD8.Add(dsPhieuGui[i]);
                    }
                    else if (tabIndex == 1)
                    {
                        BD10_BD8.Add(dsBD8[i]);
                    }
                    else
                    {
                        PhieuGuiPhat.Add(dsPhieuGui[i]);
                    }
                }
            }
            this.Close();
        }
    }
}
