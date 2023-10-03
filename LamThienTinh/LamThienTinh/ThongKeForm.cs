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
    public partial class ThongKeForm : Form
    {
        private List<PhieuGui> dsPhieuGui;
        private List<BangGia> bangGia;
        public ThongKeForm(int SHBuuCuc)
        {
            InitializeComponent();
            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.9);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.9);

            tableLayoutPanel2.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.1);
            tableLayoutPanel1.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.1);

            dsPhieuGui = NhanVienGiaoDichDAL.danhSachPhieuGui(SHBuuCuc);
            bangGia = NhanVienGiaoDichDAL.getAllBangGia();
            renderData();
            renderTableData();
        }

        public void renderData()
        {
            for (int i = 1; i <= 12; i++)
            {
                thangCb.Items.Add(i.ToString());
            }

            for (int i = 2022; i <= DateTime.Now.Year; i++)
            {
                namCb.Items.Add(i.ToString());
            }
            thangCb.SelectedIndex = 0;
            namCb.SelectedIndex = 0;

            dsPhieuGuiDataGridView.Columns.Add("", "Ngày Chấp Nhận");
            dsPhieuGuiDataGridView.Columns.Add("", "Số Lượng Bưu Gửi");
            dsPhieuGuiDataGridView.Columns.Add("", "Số Lượng Bưu Gửi Thành Công");
            dsPhieuGuiDataGridView.Columns.Add("", "Tổng Doanh Thu");
        }

        public void renderTableData()
        {
            try
            {
                dsPhieuGuiDataGridView.Rows.Clear();
                int selectedMonth = Convert.ToInt32(thangCb.Text);
                int selectedYear = Convert.ToInt32(namCb.Text);
                int numDays = DateTime.DaysInMonth(selectedYear, selectedMonth);
                long tong = 0;
                for (int i = 1; i <= numDays; i++)
                {
                    DateTime dt = new DateTime(selectedYear, selectedMonth, i);
                    string ngayChapNhan = dt.ToString("dd/MM/yyyy");

                    int soLuongBuuGui = 0;
                    int soLuongBuuGuiThanhCong = 0;
                    long tongDoanhThu = 0;

                    foreach (PhieuGui pg in dsPhieuGui)
                    {
                        if (pg.NgayChapNhan.CompareTo(dt) == 0)
                        {
                            soLuongBuuGui++;
                            if (pg.TinhTrang.ToLower().CompareTo("đã phát") == 0)
                            {
                                soLuongBuuGuiThanhCong++;
                            }

                            int khoiLuongTinhCuoc = (pg.KhoiLuongCanThuc > pg.KhoiLuongQuyDoi) ? pg.KhoiLuongCanThuc : pg.KhoiLuongQuyDoi;
                            int pos = bangGia.Count - 1;

                            for (int j = 0; j < bangGia.Count - 1; j++)
                            {
                                if (khoiLuongTinhCuoc <= bangGia[j].NacKhoiLuong)
                                {
                                    pos = j;
                                    break;
                                }
                            }

                            int CuocChinh;
                            if (pos == bangGia.Count - 1)
                            {
                                double rem = (double)(khoiLuongTinhCuoc - bangGia[pos - 1].NacKhoiLuong) / 1000;
                                CuocChinh = (int)Math.Ceiling(rem) * bangGia[pos].Cuoc + bangGia[pos - 1].Cuoc;
                            }
                            else
                            {
                                CuocChinh = bangGia[pos].Cuoc;
                            }

                            int CuocGTGT = 0;
                            foreach (DichVuGTGT gt in pg.gtgt)
                            {
                                CuocGTGT += gt.Cuoc;
                            }

                            int VAT = (int)((double)(CuocChinh + CuocGTGT) * 0.1);
                            tongDoanhThu += (CuocChinh + CuocGTGT + VAT);
                        }
                    }
                    if (soLuongBuuGui == 0)
                    {
                        continue;
                    }
                    tong += tongDoanhThu;
                    dsPhieuGuiDataGridView.Rows.Add(new object[] { ngayChapNhan, soLuongBuuGui, soLuongBuuGuiThanhCong, tongDoanhThu });
                }
                if (tong != 0)
                {
                    dsPhieuGuiDataGridView.Rows.Add(new object[] { "Tổng", "", "", tong }); 
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thangCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderTableData();
            dsPhieuGuiDataGridView.Focus();
        }

        private void createUpdateBtn_Click(object sender, EventArgs e)
        {
         
        }
    }
}
