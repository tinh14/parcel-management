using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class NhanVienGiaoDichDAL : NhanVienDAL
    {
        public static List<DichVu> getAllDichVu()
        {
            dbc.con.Open();
            string query = "select * from DichVu";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            SqlDataReader reader = cm.ExecuteReader();
            List<DichVu> dsDichVu = new List<DichVu>();
            while (reader.Read())
            {
                dsDichVu.Add(new DichVu(reader.GetInt32(0), reader.GetString(1)));
            }
            dbc.con.Close();
            return dsDichVu;
        }

        public static List<PTVC> getAllPTVC()
        {
            dbc.con.Open();
            string query = "select * from PTVC";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            SqlDataReader reader = cm.ExecuteReader();
            List<PTVC> dsPTVC = new List<PTVC>();
            while (reader.Read())
            {
                dsPTVC.Add(new PTVC(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }
            dbc.con.Close();
            return dsPTVC;
        }

        public static List<ChiDanKhongPhatDuoc> getAllCDKPD()
        {
            dbc.con.Open();
            string query = "select * from ChiDanKhongPhatDuoc";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            SqlDataReader reader = cm.ExecuteReader();
            List<ChiDanKhongPhatDuoc> dsCDKPD = new List<ChiDanKhongPhatDuoc>();
            while (reader.Read())
            {
                dsCDKPD.Add(new ChiDanKhongPhatDuoc(reader.GetInt32(0), reader.GetString(1)));
            }
            dbc.con.Close();
            return dsCDKPD;
        }

        public static List<DichVuGTGT> getAllDVGTGT()
        {
            dbc.con.Open();
            string query = "select * from DichVuGTGT";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            SqlDataReader reader = cm.ExecuteReader();
            List<DichVuGTGT> dsDVGTGT = new List<DichVuGTGT>();
            while (reader.Read())
            {
                dsDVGTGT.Add(new DichVuGTGT(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }
            dbc.con.Close();
            return dsDVGTGT;
        }

        public static List<BuuCuc> getAllBuuCuc()
        {
            dbc.con.Open();
            string query = "select * from BuuCuc";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            SqlDataReader reader = cm.ExecuteReader();
            List<BuuCuc> dsBuuCuc = new List<BuuCuc>();
            while (reader.Read())
            {
                dsBuuCuc.Add(new BuuCuc(reader.GetInt32(0), reader.GetString(1)));
            }
            dbc.con.Close();
            return dsBuuCuc;
        }

        public static List<KhachHang> getAllKhachHang()
        {
            dbc.con.Open();
            string query = "select * from ConNguoi where SH in (select SH from KhachHang)";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            SqlDataReader reader = cm.ExecuteReader();
            List<KhachHang> dsKhachHang = new List<KhachHang>();
            while (reader.Read())
            {
                dsKhachHang.Add(new KhachHang(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
            }
            dbc.con.Close();
            return dsKhachHang;
        }

        public static List<Loai> getAllLoai()
        {
            dbc.con.Open();
            string query = "select * from Loai";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            SqlDataReader reader = cm.ExecuteReader();
            List<Loai> dsLoai = new List<Loai>();
            while (reader.Read())
            {
                dsLoai.Add(new Loai(reader.GetInt32(0), reader.GetString(1)));
            }
            dbc.con.Close();
            return dsLoai;
        }

        public static List<HangGui> getAllHangGui(int SHPhieuGui)
        {
            dbc.con.Open();
            string query = "select * from HangGui where SHPhieuGui = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHPhieuGui;
            SqlDataReader reader = cm.ExecuteReader();
            List<HangGui> dsHangGui = new List<HangGui>();
            while (reader.Read())
            {
                dsHangGui.Add(new HangGui(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)));
            }
            dbc.con.Close();
            return dsHangGui;
        }

        public static List<BangGia> getAllBangGia()
        {
            dbc.con.Open();
            string query = "select * from BangGia";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            SqlDataReader reader = cm.ExecuteReader();
            List<BangGia> dsBangGia = new List<BangGia>();
            while (reader.Read())
            {
                dsBangGia.Add(new BangGia(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
            }
            dbc.con.Close();
            return dsBangGia;
        }

        public static bool insertHangGui(int SHPhieuGui, HangGui hangGui)
        {
            dbc.con.Open();
            string query = "insert into HangGui(Ten, TenTiengAnh, SoLuong, DonViTinh, GiaTri, KhoiLuong, SHPhieuGui)" 
            + "values(@1, @2, @3, @4, @5, @6, @7)";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.NVarChar);
            cm.Parameters.Add("@2", SqlDbType.VarChar);
            cm.Parameters.Add("@3", SqlDbType.Int);
            cm.Parameters.Add("@4", SqlDbType.NVarChar);
            cm.Parameters.Add("@5", SqlDbType.Int);
            cm.Parameters.Add("@6", SqlDbType.Int);
            cm.Parameters.Add("@7", SqlDbType.Int);

            cm.Parameters["@1"].Value = hangGui.Ten;
            cm.Parameters["@2"].Value = hangGui.TenTiengAnh;
            cm.Parameters["@3"].Value = hangGui.SoLuong;
            cm.Parameters["@4"].Value = hangGui.DonViTinh;
            cm.Parameters["@5"].Value = hangGui.GiaTri;
            cm.Parameters["@6"].Value = hangGui.KhoiLuong;
            cm.Parameters["@7"].Value = SHPhieuGui;
            bool result = cm.ExecuteNonQuery() != 0;
            dbc.con.Close();
            return result;
        }

        public static bool removeAllHangGui(int SHPhieuGui)
        {
            dbc.con.Open();
            string query = "delete from HangGui where SHPHieuGui = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHPhieuGui;
            bool result = cm.ExecuteNonQuery() != 0;
            dbc.con.Close();
            return result;
        }

        public static void lapPhieuGui(PhieuGui phieuGui)
        {
            dbc.con.Open();
            string query = "insert into PhieuGui (NgayChapNhan, KhoiLuongCanThuc, KhoiLuongQuyDoi, TinhTrang, SHBuuCucGui, SHBuuCucNhan, SHKhachHangGui, SHKhachHangNhan, SHPTVC, SHDichVu, SHChiDanKhongPhatDuoc)"
                + "values (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11) SELECT SCOPE_IDENTITY()";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.DateTime);
            cm.Parameters.Add("@2", SqlDbType.Int);
            cm.Parameters.Add("@3", SqlDbType.Int);
            cm.Parameters.Add("@4", SqlDbType.NVarChar);
            cm.Parameters.Add("@5", SqlDbType.Int);
            cm.Parameters.Add("@6", SqlDbType.Int);
            cm.Parameters.Add("@7", SqlDbType.Int);
            cm.Parameters.Add("@8", SqlDbType.Int);
            cm.Parameters.Add("@9", SqlDbType.Int);
            cm.Parameters.Add("@10", SqlDbType.Int);
            cm.Parameters.Add("@11", SqlDbType.Int);

            cm.Parameters["@1"].Value = phieuGui.NgayChapNhan;
            cm.Parameters["@2"].Value = phieuGui.KhoiLuongCanThuc;
            cm.Parameters["@3"].Value = phieuGui.KhoiLuongQuyDoi;
            cm.Parameters["@4"].Value = phieuGui.TinhTrang;
            cm.Parameters["@5"].Value = phieuGui.buuCucGui.SH;
            cm.Parameters["@6"].Value = phieuGui.buuCucNhan.SH;
            cm.Parameters["@7"].Value = phieuGui.khachHangGui.SH;
            cm.Parameters["@8"].Value = phieuGui.khachHangNhan.SH;
            cm.Parameters["@9"].Value = phieuGui.ptvc.SH;
            cm.Parameters["@10"].Value = phieuGui.dichVu.SH;
            cm.Parameters["@11"].Value = phieuGui.cdkpd.SH;
            phieuGui.SH = Convert.ToInt32(cm.ExecuteScalar());

            query = "insert into PhieuGui_Loai values (@1, @2)";
            foreach (Loai l in phieuGui.loai)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters.Add("@2", SqlDbType.Int);

                cm.Parameters["@1"].Value = phieuGui.SH;
                cm.Parameters["@2"].Value = l.SH;
                cm.ExecuteNonQuery();
            }

            query = "insert into HangGui (Ten, TenTiengAnh, SoLuong, DonViTinh, GiaTri, KhoiLuong, SHPhieuGui)"
                + "values (@1, @2, @3, @4, @5, @6, @7) ";
            foreach (HangGui hg in phieuGui.hangGui)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.NVarChar);
                cm.Parameters.Add("@2", SqlDbType.VarChar);
                cm.Parameters.Add("@3", SqlDbType.Int);
                cm.Parameters.Add("@4", SqlDbType.NVarChar);
                cm.Parameters.Add("@5", SqlDbType.Int);
                cm.Parameters.Add("@6", SqlDbType.Int);
                cm.Parameters.Add("@7", SqlDbType.Int);

                cm.Parameters["@1"].Value = hg.Ten;
                cm.Parameters["@2"].Value = hg.TenTiengAnh;
                cm.Parameters["@3"].Value = hg.SoLuong;
                cm.Parameters["@4"].Value = hg.DonViTinh;
                cm.Parameters["@5"].Value = hg.GiaTri;
                cm.Parameters["@6"].Value = hg.KhoiLuong;
                cm.Parameters["@7"].Value = phieuGui.SH;
                cm.ExecuteNonQuery();
            }

            query = "insert into PhieuGui_DVGTGT values (@1, @2)";
            foreach (DichVuGTGT gt in phieuGui.gtgt)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters.Add("@2", SqlDbType.Int);

                cm.Parameters["@1"].Value = phieuGui.SH;
                cm.Parameters["@2"].Value = gt.SH;
                cm.ExecuteNonQuery();
            }
            dbc.con.Close();
        }

        
        public static void suaPhieuGui(PhieuGui phieuGui)
        {
            dbc.con.Open();
            string query = "update PhieuGui set NgayChapNhan = @1, KhoiLuongCanThuc = @2, "
                + "KhoiLuongQuyDoi = @3, TinhTrang = @4, SHBuuCucGui = @5, SHBuuCucNhan = @6, "
                +"SHKhachHangGui = @7, SHKhachHangNhan = @8, SHPTVC = @9, SHDichVu = @10, SHChiDanKhongPhatDuoc = @11 where SH = @12";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.DateTime);
            cm.Parameters.Add("@2", SqlDbType.Int);
            cm.Parameters.Add("@3", SqlDbType.Int);
            cm.Parameters.Add("@4", SqlDbType.NVarChar);
            cm.Parameters.Add("@5", SqlDbType.Int);
            cm.Parameters.Add("@6", SqlDbType.Int);
            cm.Parameters.Add("@7", SqlDbType.Int);
            cm.Parameters.Add("@8", SqlDbType.Int);
            cm.Parameters.Add("@9", SqlDbType.Int);
            cm.Parameters.Add("@10", SqlDbType.Int);
            cm.Parameters.Add("@11", SqlDbType.Int);
            cm.Parameters.Add("@12", SqlDbType.Int);

            cm.Parameters["@1"].Value = phieuGui.NgayChapNhan;
            cm.Parameters["@2"].Value = phieuGui.KhoiLuongCanThuc;
            cm.Parameters["@3"].Value = phieuGui.KhoiLuongQuyDoi;
            cm.Parameters["@4"].Value = phieuGui.TinhTrang;
            cm.Parameters["@5"].Value = phieuGui.buuCucGui.SH;
            cm.Parameters["@6"].Value = phieuGui.buuCucNhan.SH;
            cm.Parameters["@7"].Value = phieuGui.khachHangGui.SH;
            cm.Parameters["@8"].Value = phieuGui.khachHangNhan.SH;
            cm.Parameters["@9"].Value = phieuGui.ptvc.SH;
            cm.Parameters["@10"].Value = phieuGui.dichVu.SH;
            cm.Parameters["@11"].Value = phieuGui.cdkpd.SH;
            cm.Parameters["@12"].Value = phieuGui.SH;
            cm.ExecuteNonQuery();

            query = "delete from PhieuGui_Loai where SHPhieuGui = @1";
            cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = phieuGui.SH;
            cm.ExecuteNonQuery();

            query = "insert into PhieuGui_Loai values (@1, @2)";
            foreach (Loai l in phieuGui.loai)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters.Add("@2", SqlDbType.Int);

                cm.Parameters["@1"].Value = phieuGui.SH;
                cm.Parameters["@2"].Value = l.SH;
                cm.ExecuteNonQuery();
            }

            query = "delete from HangGui where SHPhieuGui = @1";
            cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = phieuGui.SH;
            cm.ExecuteNonQuery();

            query = "insert into HangGui (Ten, TenTiengAnh, SoLuong, DonViTinh, GiaTri, KhoiLuong, SHPhieuGui)"
                    + "values (@1, @2, @3, @4, @5, @6, @7)";
            foreach (HangGui hg in phieuGui.hangGui)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.NVarChar);
                cm.Parameters.Add("@2", SqlDbType.VarChar);
                cm.Parameters.Add("@3", SqlDbType.Int);
                cm.Parameters.Add("@4", SqlDbType.NVarChar);
                cm.Parameters.Add("@5", SqlDbType.Int);
                cm.Parameters.Add("@6", SqlDbType.Int);
                cm.Parameters.Add("@7", SqlDbType.Int);

                cm.Parameters["@1"].Value = hg.Ten;
                cm.Parameters["@2"].Value = hg.TenTiengAnh;
                cm.Parameters["@3"].Value = hg.SoLuong;
                cm.Parameters["@4"].Value = hg.DonViTinh;
                cm.Parameters["@5"].Value = hg.GiaTri;
                cm.Parameters["@6"].Value = hg.KhoiLuong;
                cm.Parameters["@7"].Value = phieuGui.SH;
                cm.ExecuteNonQuery();
            }

            query = "delete from PhieuGui_DVGTGT where SHPhieuGui = @1";
            cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = phieuGui.SH;
            cm.ExecuteNonQuery();

            query = "insert into PhieuGui_DVGTGT values (@1, @2)";
            foreach (DichVuGTGT gt in phieuGui.gtgt)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters.Add("@2", SqlDbType.Int);

                cm.Parameters["@1"].Value = phieuGui.SH;
                cm.Parameters["@2"].Value = gt.SH;
                cm.ExecuteNonQuery();
            }

            dbc.con.Close();
        }


        public static void xoaPhieuGui(int SHPhieuGui)
        {
            dbc.con.Open();
            string query = "delete from PhieuGui_Loai where SHPhieuGui = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHPhieuGui;
            cm.ExecuteNonQuery();

            query = "delete from HangGui where SHPhieuGui = @1";
            cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHPhieuGui;
            cm.ExecuteNonQuery();

            query = "delete from PhieuGui_DVGTGT where SHPhieuGui = @1";
            cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHPhieuGui;
            cm.ExecuteNonQuery();

            query = "delete from PhieuGui where SH = @1";
            cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHPhieuGui;
            cm.ExecuteNonQuery();

            dbc.con.Close();
        }

        public static List<PhieuGui> danhSachPhieuGui(int SHBuuCuc)
        {
            dbc.con.Open();
            string query = "select * from PhieuGui where SHBuuCucGui = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHBuuCuc;
            SqlDataReader reader = cm.ExecuteReader();
            
            List<PhieuGui> dsPhieuGui = new List<PhieuGui>();

            while (reader.Read()){
                PhieuGui phieuGui = new PhieuGui();
                phieuGui.buuCucGui = new BuuCuc();
                phieuGui.buuCucNhan = new BuuCuc();
                phieuGui.khachHangGui = new KhachHang();
                phieuGui.khachHangNhan = new KhachHang();
                phieuGui.ptvc = new PTVC();
                phieuGui.dichVu = new DichVu();
                phieuGui.cdkpd = new ChiDanKhongPhatDuoc();

                phieuGui.SH = reader.GetInt32(0);
                phieuGui.NgayChapNhan = reader.GetDateTime(1);
                phieuGui.KhoiLuongCanThuc = reader.GetInt32(2);
                phieuGui.KhoiLuongQuyDoi = reader.GetInt32(3);
                phieuGui.TinhTrang = reader.GetString(4);
                phieuGui.buuCucGui.SH = reader.GetInt32(5);
                phieuGui.buuCucNhan.SH = reader.GetInt32(6);
                phieuGui.khachHangGui.SH = reader.GetInt32(7);
                phieuGui.khachHangNhan.SH = reader.GetInt32(8);
                phieuGui.ptvc.SH = reader.GetInt32(9);
                phieuGui.dichVu.SH = reader.GetInt32(10);
                phieuGui.cdkpd.SH = reader.GetInt32(11);
                dsPhieuGui.Add(phieuGui);
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.buuCucGui = getBuuCucBySH(pg.buuCucGui.SH);
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.buuCucNhan= getBuuCucBySH(pg.buuCucNhan.SH);
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.khachHangGui = getKhachHangBySH(pg.khachHangGui.SH);
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.khachHangNhan = getKhachHangBySH(pg.khachHangNhan.SH);
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.ptvc = getPTVCBySH(pg.ptvc.SH);
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.dichVu = getDichVuBySH(pg.dichVu.SH);
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.cdkpd = getCDKPDBySH(pg.cdkpd.SH);   
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.loai = getDSLoaiBySHPhieuGui(pg.SH);
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.hangGui = getDSHangGuiBySHPhieuGui(pg.SH);
            }

            foreach (PhieuGui pg in dsPhieuGui)
            {
                pg.gtgt = getDichVuGTGTBySHPhieuGui(pg.SH);
            }

            dbc.con.Close();
            return dsPhieuGui;
        }
    }
}
