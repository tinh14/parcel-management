using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class NhanVienDAL
    {
        protected static DatabaseConnection dbc = new DatabaseConnection();

        public static NhanVien dangNhap(string tenDangNhap, string matKhau)
        {
            dbc.con.Open();
            string query = "Select * From NhanVien where TenDangNhap = @1 and MatKhau = @2";
            SqlCommand cm = new SqlCommand(query, dbc.con);

            cm.Parameters.Add("@1", SqlDbType.VarChar);
            cm.Parameters.Add("@2", SqlDbType.VarChar);

            cm.Parameters["@1"].Value = tenDangNhap;
            cm.Parameters["@2"].Value = matKhau;

            SqlDataReader reader = cm.ExecuteReader();
            if (!reader.HasRows)
            {
                dbc.con.Close();
                return null;
            }
            reader.Read();

            query = "select * from ConNguoi where SH = @1";
            SqlCommand cm2 = new SqlCommand(query, dbc.con);
            cm2.Parameters.Add("@1", SqlDbType.Int);
            cm2.Parameters["@1"].Value = reader[0];
            SqlDataReader reader2 = cm2.ExecuteReader();
            reader2.Read();

            query = "select * from BuuCuc where SH = @1";
            SqlCommand cm3 = new SqlCommand(query, dbc.con);
            cm3.Parameters.Add("@1", SqlDbType.Int);
            cm3.Parameters["@1"].Value = reader[5];
            SqlDataReader reader3 = cm3.ExecuteReader();
            reader3.Read();

            BuuCuc buuCuc = new BuuCuc(reader3.GetInt32(0), reader3.GetString(1));
            NhanVien nhanVien = new NhanVien(reader2.GetInt32(0), reader2.GetString(1), reader2.GetString(2), reader2.GetString(3), reader2.GetString(4), reader2.GetString(5), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), buuCuc);
            dbc.con.Close();
            return nhanVien;            
        }

        public static DichVu getDichVuBySH(int SH)
        {
            string query = "select * from DichVu where SH = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SH;
            SqlDataReader reader = cm.ExecuteReader();
            reader.Read();
            return new DichVu(reader.GetInt32(0), reader.GetString(1));
        }

        public static KhachHang getKhachHangBySH(int SH)
        {
            string query = "select * from ConNguoi where SH = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SH;
            SqlDataReader reader = cm.ExecuteReader();
            reader.Read();

            KhachHang khachHang = new KhachHang();
            khachHang.SH = reader.GetInt32(0);
            khachHang.Ten = reader.GetString(1);
            khachHang.Ho = reader.GetString(2);
            khachHang.DiaChi = reader.GetString(3);
            khachHang.Email = reader.GetString(4);
            khachHang.SDT = reader.GetString(5);
            return khachHang;
        }

        public static BuuCuc getBuuCucBySH(int SH)
        {
            string query = "select * from BuuCuc where SH = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SH;
            SqlDataReader reader = cm.ExecuteReader();
            reader.Read();
            BuuCuc buuCuc = new BuuCuc();
            buuCuc.SH = reader.GetInt32(0);
            buuCuc.Ten = reader.GetString(1);
            return buuCuc;
        }

        public static PTVC getPTVCBySH(int SH)
        {
            string query = "select * from PTVC where SH = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SH;
            SqlDataReader reader = cm.ExecuteReader();
            reader.Read();

            PTVC ptvc = new PTVC();
            ptvc.SH = reader.GetInt32(0);
            ptvc.Ten = reader.GetString(1);
            ptvc.Cuoc = reader.GetInt32(2);

            return ptvc;
        }

        public static ChiDanKhongPhatDuoc getCDKPDBySH(int SH)
        {
            string query = "select * from ChiDanKhongPhatDuoc where SH = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SH;
            SqlDataReader reader = cm.ExecuteReader();
            reader.Read();

            ChiDanKhongPhatDuoc cd = new ChiDanKhongPhatDuoc();
            cd.SH = reader.GetInt32(0);
            cd.Ten = reader.GetString(1);
            return cd;
        }

        public static List<Loai> getDSLoaiBySHPhieuGui(int SHPhieuGui)
        {
            string query = "select * from Loai where SH in (select SHLoai from PhieuGui_Loai where SHPhieuGui = @1)";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHPhieuGui;
            SqlDataReader reader = cm.ExecuteReader();
            List<Loai> loai = new List<Loai>();
            while (reader.Read())
            {
                Loai l = new Loai();
                l.SH = reader.GetInt32(0);
                l.Ten = reader.GetString(1);
                loai.Add(l);
            }
            return loai;
        }

        public static List<HangGui> getDSHangGuiBySHPhieuGui(int SHPhieuGui)
        {
            string query = "select * from HangGui where SHPhieuGui = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHPhieuGui;
            SqlDataReader reader = cm.ExecuteReader();
            List<HangGui> hangGui = new List<HangGui>();
            while (reader.Read())
            {
                HangGui hg = new HangGui();
                hg.SH = reader.GetInt32(0);
                hg.Ten = reader.GetString(1);
                hg.TenTiengAnh = reader.GetString(2);
                hg.SoLuong = reader.GetInt32(3);
                hg.DonViTinh = reader.GetString(4);
                hg.GiaTri = reader.GetInt32(5);
                hg.KhoiLuong = reader.GetInt32(6);
                hangGui.Add(hg);
            }
            return hangGui;
        }

        public static List<DichVuGTGT> getDichVuGTGTBySHPhieuGui(int SHPhieuGui)
        {
            string query = "select * from DichVuGTGT where SH in (select SHDichVuGTGT from PhieuGui_DVGTGT where SHPhieuGui = @1)";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHPhieuGui;
            SqlDataReader reader = cm.ExecuteReader();
            List<DichVuGTGT> gtgt = new List<DichVuGTGT>();
            while (reader.Read())
            {
                DichVuGTGT gt = new DichVuGTGT();
                gt.SH = reader.GetInt32(0);
                gt.Ten = reader.GetString(1);
                gt.Cuoc = reader.GetInt32(2);
                gtgt.Add(gt);
            }
            return gtgt;
        }
    }
}
