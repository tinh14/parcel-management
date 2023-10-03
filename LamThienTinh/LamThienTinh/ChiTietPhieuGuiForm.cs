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
    public partial class ChiTietPhieuGuiForm : Form
    {
        private DSHangGuiForm dsHangGuiForm;

        // Danh sách các dịch vụ
        public List<DichVu> dsDichVu;
        // Danh sách các phương thức vận chuyển
        public List<PTVC> dsPTVC;
        // Danh sách các loại hàng
        public List<Loai> dsLoai;
        // Danh sách các chỉ dẫn không phát được
        public List<ChiDanKhongPhatDuoc> dsCDKPD;
        // Danh sách dịch vụ giá trị gia tăng
        public List<DichVuGTGT> dsDVGTGT;
        // Danh sách các bảng giá
        public List<BangGia> bangGia;
        // Danh sách các bưu cục
        public List<BuuCuc> dsBuuCuc;
        public int CuocChinh;
        public int VAT;
        public int CuocGTGT;
        public int Tong;

        // Các biến dùng để lưu dữ liệu sau khi chọn/nhập
        // để làm tham số cho object phiếu gửi
        public DichVu U_DichVu;
        public PTVC U_PTVC;
        public List<Loai> U_DSLoai;
        public PhieuGui phieuGui;
        public BuuCuc buuCucGui;
        public BuuCuc buuCucNhan;
        public KhachHang khachHangGui;
        public KhachHang khachHangNhan;
        public DateTime ngayChapNhan;
        public ChiDanKhongPhatDuoc U_CDKPD;
        public List<HangGui> U_HangGui;
        public List<DichVuGTGT> U_GTGT;
        public string tinhTrang = "Chưa Phát";
        public int khoiLuongQuyDoi;
        public int khoiLuongCanThuc;

        // Nhận vào 1 phiếu gửi, nếu phiếu gửi đó = null thì có nghĩa là
        // người dùng muốn lập phiếu gửi mới, ngược lại hiển thị phiếu gửi
        // đã nhận để cập nhật thông tin mới
        public ChiTietPhieuGuiForm(PhieuGui phieuGui, BuuCuc buuCucGui)
        {
            InitializeComponent();
            
            setControlsInfo();
            setData(phieuGui, buuCucGui);
            renderData();
        }

        // Đặt các thông tin của các controls trong form
        public void setControlsInfo()
        {
            // Chiều dài rộng của form = 90% dài rộng của màn hình
            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.9);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.9);

            // Chiều cao tableLayoutPanel1 = 10% chiều cao của form
            tableLayoutPanel1.Height = Convert.ToInt32(this.Height * 0.1);

            // Đặt tên nút cho chính xác
            string text;
            if (phieuGui == null)
            {
                text = "LẬP";
            }
            else
            {
                text = "CẬP NHẬT";
            }
            createUpdateBtn.Text = text;
        }

        // Đọc dữ liệu từ tham số và csdl 
        public void setData(PhieuGui phieuGui, BuuCuc buuCucGui)
        {
            this.phieuGui = phieuGui;
            this.buuCucGui = buuCucGui;

            bangGia = NhanVienGiaoDichDAL.getAllBangGia();
        }

        // Hiển thị các thông tin Controls
        public void renderData(){
            renderDichVu();
            renderSH();
            renderPTVC();
            renderKhachHangGui();
            renderKhachHangNhan();
            renderBuuCuc();
            renderLoai();
            renderNgayChapNhan();
            renderCDKPD();
            renderHangGui_KhoiLuong();
            renderGTGT();
            renderCuoc();
            renderCuocGTGT();
            renderVAT_Tong();
        }

        // Hiển thị dịch vụ
        public void renderDichVu()
        {
            dsDichVu = NhanVienGiaoDichDAL.getAllDichVu();
            foreach (DichVu dv in dsDichVu)
            {
                dichVuCb.Items.Add(dv.Ten);
            }
            dichVuCb.SelectedIndex = 0;
            
            if (phieuGui == null)
            {
                return;
            }
            U_DichVu = phieuGui.dichVu;
            for (int i = 0; i < dsDichVu.Count; i++)
            {
                if (dsDichVu[i].SH == U_DichVu.SH)
                {
                    dichVuCb.SelectedIndex = i;
                    break;
                }
            }
        }

        // Hiển thị số hiệu
        public void renderSH()
        {
            if (phieuGui == null){
                return;
            }
            soHieuPhieuGui.Text = phieuGui.SH.ToString();
        }

        // Hiển thị phương thức vận chuyển
        public void renderPTVC()
        {
            dsPTVC = NhanVienGiaoDichDAL.getAllPTVC();
            foreach (PTVC pt in dsPTVC)
            {
                ptvcCb.Items.Add(pt.Ten);
            }
            ptvcCb.SelectedIndex = 0;

            if (phieuGui == null)
            {
                return;
            }
            U_PTVC = phieuGui.ptvc;
            for (int i = 0; i < dsPTVC.Count; i++)
            {
                if (dsPTVC[i].SH == U_PTVC.SH)
                {
                    ptvcCb.SelectedIndex = i;
                    break;
                }
            }
        }

        // Hiển thị khách hàng gửi
        public void renderKhachHangGui()
        {
            if (phieuGui == null)
            {
                return;
            }
            this.khachHangGui = phieuGui.khachHangGui;
            soHieuKHGui.Text = khachHangGui.SH.ToString();
            hoKHGui.Text = khachHangGui.Ho;
            tenKHGui.Text = khachHangGui.Ten;
            emailKHGui.Text = khachHangGui.Email;
            sdtKHGui.Text = khachHangGui.SDT;
            diaChiKHGui.Text = khachHangGui.DiaChi;
        }

        // Hiển thị khách hàng nhận
        public void renderKhachHangNhan()
        {
            if (phieuGui == null)
            {
                return;
            }
            this.khachHangNhan = phieuGui.khachHangNhan;
            soHieuKHNhan.Text = khachHangNhan.SH.ToString();
            hoKHNhan.Text = khachHangNhan.Ho;
            tenKHNhan.Text = khachHangNhan.Ten;
            emailKHNhan.Text = khachHangNhan.Email;
            sdtKHNhan.Text = khachHangNhan.SDT;
            diaChiKHNhan.Text = khachHangNhan.DiaChi;
        }

        // Hiển thị bưu cục
        public void renderBuuCuc()
        {
            this.dsBuuCuc = NhanVienGiaoDichDAL.getAllBuuCuc();
            foreach (BuuCuc asdasd in dsBuuCuc)
            {
                buuCucNhanCb.Items.Add(asdasd.Ten);
            }
            buuCucNhanCb.SelectedIndex = 0;
            buuCucGuiTb.Text = buuCucGui.Ten;
            if (phieuGui == null)
            {
                return;
            }

            this.buuCucNhan = phieuGui.buuCucNhan;
            for (int i = 0; i < dsBuuCuc.Count; i++){
                if (buuCucNhan.SH == dsBuuCuc[i].SH){
                    buuCucNhanCb.SelectedIndex = i;
                    break;
                }
            }
        }

        // Hiển thị loại bưu gửi
        public void renderLoai()
        {
            dsLoai = NhanVienGiaoDichDAL.getAllLoai();
            foreach (Loai l in dsLoai)
            {
                loaiHangClb.Items.Add(l.Ten);
            }

            if (phieuGui == null)
            {
                return;
            }

            U_DSLoai = phieuGui.loai;
            for (int i = 0; i < dsLoai.Count; i++)
            {
                for (int j = 0; j < phieuGui.loai.Count; j++)
                {
                    if (dsLoai[i].SH == U_DSLoai[j].SH)
                    {
                        loaiHangClb.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        // Hiển thị ngày chấp nhận bưu gửi
        public void renderNgayChapNhan()
        {
            ngayChapNhanDTPicker.CustomFormat = "dd-MM-yyyy";
            if (phieuGui == null)
            {
                return;
            }
            ngayChapNhan = phieuGui.NgayChapNhan;
            ngayChapNhanDTPicker.Value = ngayChapNhan;
        }

        // Hiển thị chỉ dẫn không phát được
        public void renderCDKPD()
        {
            dsCDKPD = NhanVienGiaoDichDAL.getAllCDKPD();
            foreach (ChiDanKhongPhatDuoc cd in dsCDKPD)
            {
                chiDanCb.Items.Add(cd.Ten);
            }
            chiDanCb.SelectedIndex = 0;

            if (phieuGui == null)
            {
                return;
            }
            U_CDKPD = phieuGui.cdkpd;
            for (int i = 0; i < dsCDKPD.Count; i++)
            {
                if (dsCDKPD[i].SH == U_CDKPD.SH)
                {
                    chiDanCb.SelectedIndex = i;
                    break;
                }
            }
        }

        // Hiển thị hàng gửi và khổi lượng hàng gửi
        public void renderHangGui_KhoiLuong()
        {
            if (phieuGui == null)
            {
                return;
            }
            U_HangGui = phieuGui.hangGui;
            khoiLuongCanThuc = phieuGui.KhoiLuongCanThuc;
            khoiLuongThucTeTb.Text = khoiLuongCanThuc.ToString();

            khoiLuongQuyDoi = phieuGui.KhoiLuongQuyDoi;
            khoiLuongQuyDoiTb.Text = khoiLuongQuyDoi.ToString();


        }

        // Hiển thị các dịch vụ giá trị gia tăng
        public void renderGTGT()
        {
            dsDVGTGT = NhanVienGiaoDichDAL.getAllDVGTGT();
            foreach (DichVuGTGT dv in dsDVGTGT)
            {
                gtgtClb.Items.Add(dv.Ten);
            }
            if (phieuGui == null)
            {
                return;
            }
            U_GTGT = phieuGui.gtgt;
            for (int i = 0; i < dsDVGTGT.Count; i++)
            {
                for (int j = 0; j < U_GTGT.Count; j++)
                {
                    if (dsDVGTGT[i].SH == U_GTGT[j].SH)
                    {
                        gtgtClb.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        // Hiển thị cước chính
        public void renderCuoc()
        {
            try
            {
                khoiLuongCanThuc = Convert.ToInt32(khoiLuongThucTeTb.Text);
                int khoiLuongTinhCuoc = (khoiLuongCanThuc > khoiLuongQuyDoi) ? khoiLuongCanThuc : khoiLuongQuyDoi;
                int pos = bangGia.Count - 1;

                for (int i = 0; i < bangGia.Count - 1; i++)
                {
                    if (khoiLuongTinhCuoc <= bangGia[i].NacKhoiLuong)
                    {
                        pos = i;
                        break;
                    }
                }

                if (pos == bangGia.Count - 1)
                {
                    double rem = (double)(khoiLuongTinhCuoc - bangGia[pos - 1].NacKhoiLuong) / 1000;
                    CuocChinh = (int)Math.Ceiling(rem) * bangGia[pos].Cuoc + bangGia[pos - 1].Cuoc;
                }
                else
                {
                    CuocChinh = bangGia[pos].Cuoc;
                }
                cuocChinhTb.Text = CuocChinh.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                khoiLuongThucTeTb.Text = "";
                cuocChinhTb.Text = "";
            }
        }

        // Hiển thị cước dịch vụ giá trị gia tăng
        public void renderCuocGTGT()
        {
            if (phieuGui == null)
            {
                return;
            }
            CuocGTGT = 0;
            foreach (DichVuGTGT gt in U_GTGT)
            {
                CuocGTGT += gt.Cuoc;
            }
            cuocGTGTTb.Text = CuocGTGT.ToString();
        }

        // Hiển thị phí VAT và tổng các cước phí
        public void renderVAT_Tong()
        {
            VAT = (int)((double)(CuocChinh + CuocGTGT) * 0.1);
            vatTb.Text = VAT.ToString();
            Tong = CuocChinh + CuocGTGT + VAT;
            tong1Tb.Text = Tong.ToString();
        }

        // Bắt sự kiện thoát
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Bắt sự kiện tạo/cập nhật phiếu gửi
        private void createUpdateBtn_Click(object sender, EventArgs e)
        {
            string type = "Create";
            if (phieuGui != null)
            {
                type = "Update";
            }
            try
            {
                U_DichVu = dsDichVu[dichVuCb.SelectedIndex];
                U_PTVC = dsPTVC[ptvcCb.SelectedIndex];
                U_DSLoai = new List<Loai>();
                for (int i = 0; i < loaiHangClb.Items.Count; i++)
                {
                    if (loaiHangClb.GetItemChecked(i))
                    {
                        U_DSLoai.Add(dsLoai[i]);
                    }
                }
                ngayChapNhan = ngayChapNhanDTPicker.Value;
                U_CDKPD = dsCDKPD[chiDanCb.SelectedIndex];
                U_GTGT = new List<DichVuGTGT>();
                for (int i = 0; i < gtgtClb.Items.Count; i++)
                {
                    if (gtgtClb.GetItemChecked(i))
                    {
                        U_GTGT.Add(dsDVGTGT[i]);
                    }
                }

                buuCucNhan = dsBuuCuc[buuCucNhanCb.SelectedIndex];

                if (U_HangGui == null || khachHangGui == null || buuCucNhan == null || khoiLuongQuyDoiTb.Text == "" || khoiLuongQuyDoiTb.Text == "")
                {
                    new MessageDialog("Nhập đủ thông tin cần thiết");
                    return;
                }

                int SHPhieuGui = (phieuGui == null) ? -1 : phieuGui.SH;
                phieuGui = new PhieuGui(SHPhieuGui, khoiLuongCanThuc, khoiLuongQuyDoi, ngayChapNhan, tinhTrang, buuCucGui, buuCucNhan, khachHangGui, khachHangNhan, U_DichVu, U_PTVC, U_CDKPD, U_DSLoai, U_HangGui, U_GTGT);

                string message = "";
                if (type.CompareTo("Create") == 0)
                {
                    NhanVienGiaoDichDAL.lapPhieuGui(phieuGui);
                    message = "Lập phiếu gửi thành công";
                }
                else
                {
                    NhanVienGiaoDichDAL.suaPhieuGui(phieuGui);
                    message = "Sửa phiếu gửi thành công";
                }
                new MessageDialog(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Bắt sự kiện chọn khác hàng nhận
        private void soHieuKHNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                var dsKhachHangForm = new DSKhachHangForm(this, 2);
                dsKhachHangForm.ShowDialog();
                if (khachHangNhan != null)
                {
                    soHieuKHNhan.Text = khachHangNhan.SH.ToString();
                    hoKHNhan.Text = khachHangNhan.Ho;
                    tenKHNhan.Text = khachHangNhan.Ten;
                    emailKHNhan.Text = khachHangNhan.Email;
                    sdtKHNhan.Text = khachHangNhan.SDT;
                    diaChiKHNhan.Text = khachHangNhan.DiaChi;
                }
            }
        }

        // Bắt sự kiện chọn khác hàng gửi
        private void hangGuiTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (phieuGui == null)
                {
                    U_HangGui = new List<HangGui>();
                }
                
                if (dsHangGuiForm == null)
                {
                    dsHangGuiForm = new DSHangGuiForm(this, U_HangGui);
                }
                dsHangGuiForm.ShowDialog();
                if (U_HangGui.Count == 0)
                {
                    khoiLuongThucTeTb.Text = "";
                    return;
                }
                khoiLuongCanThuc = 0;
                for (int i = 0; i < U_HangGui.Count; i++)
                {
                    khoiLuongCanThuc += (U_HangGui[i].KhoiLuong * U_HangGui[i].SoLuong);
                }
                khoiLuongThucTeTb.Text = khoiLuongCanThuc.ToString();
            }
        }

        // Bắt sự kiện nhập chiều dài, rộng, cao
        // để hiển thị cước dịch vụ GTGT
        private void daiTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int d = Convert.ToInt32(daiTb.Text);
                int r = Convert.ToInt32(rongTb.Text);
                int c = Convert.ToInt32(caoTb.Text);

                khoiLuongQuyDoi = (d * r * c) / 5;
                khoiLuongQuyDoiTb.Text = khoiLuongQuyDoi.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                khoiLuongQuyDoiTb.Text = "";
            }
        }

        // Bắt sự kiện textbox khối lượng thực tế thay đổi
        private void khoiLuongThucTeTb_TextChanged(object sender, EventArgs e)
        {
            renderCuoc();
        }

        // Bắt sự kiện chọn dịch vụ giá trị gia tăng
        private void gtgtClb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (gtgtClb.GetItemCheckState(e.Index) == CheckState.Unchecked)
            {
                CuocGTGT += dsDVGTGT[e.Index].Cuoc;
            }
            else
            {
                CuocGTGT -= dsDVGTGT[e.Index].Cuoc;
            }
            cuocGTGTTb.Text = CuocGTGT.ToString();
        }

        // Bắt sự kiện cước chính thay đổi
        private void cuocChinhTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                renderVAT_Tong();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                tong1Tb.Text = "";
            }
        }

        // Bắt sự kiện chọn khách hàng gửi/nhận
        private void soHieuKHGui_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                var dsKhachHangForm = new DSKhachHangForm(this, 1);
                dsKhachHangForm.ShowDialog();
                if (khachHangGui != null)
                {
                    soHieuKHGui.Text = khachHangGui.SH.ToString();
                    hoKHGui.Text = khachHangGui.Ho;
                    tenKHGui.Text = khachHangGui.Ten;
                    emailKHGui.Text = khachHangGui.Email;
                    sdtKHGui.Text = khachHangGui.SDT;
                    diaChiKHGui.Text = khachHangGui.DiaChi;
                }
            }
        }

    }
}
