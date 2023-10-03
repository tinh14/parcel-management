using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;


namespace DAL
{
    public class NhanVienVanChuyenDAL : NhanVienDAL
    {
        public static List<PhieuGui> getAllPhieuGui(int SHBuuCuc)
        {
            dbc.con.Open();
            string query = "select * from PhieuGui where SHBuuCucNhan = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHBuuCuc;
            SqlDataReader reader = cm.ExecuteReader();
            if (!reader.HasRows)
            {
                dbc.con.Close();
                return null;
            }
            
            List<PhieuGui> phieuGui = new List<PhieuGui>();
            while (reader.Read())
            {
                PhieuGui p = new PhieuGui();
                p.SH = reader.GetInt32(0);
                phieuGui.Add(p);
            }

            dbc.con.Close();
            return phieuGui;
        }

        public static List<PhieuGui> danhSachPhieuGuiChuaPhat(int SHBuuCuc)
        {
            dbc.con.Open();
            string query = "select SH from PhieuGui where SHBuuCucNhan = @1 and TinhTrang = @2 and SHNhanVienVanChuyen is null";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters.Add("@2", SqlDbType.NVarChar);
            cm.Parameters["@1"].Value = SHBuuCuc;
            cm.Parameters["@2"].Value = "Chưa Phát";
            SqlDataReader reader = cm.ExecuteReader();
            if (!reader.HasRows)
            {
                dbc.con.Close();
                return null;
            }
            List<PhieuGui> phieuGui = new List<PhieuGui>();
            while (reader.Read()){
                PhieuGui p = new PhieuGui();
                p.SH = reader.GetInt32(0);
                phieuGui.Add(p);
            }
            dbc.con.Close();
            return phieuGui;
        }

        public static List<NhanVien> getAllNhanVienVanChuyen(int SHBuuCuc)
        {
            dbc.con.Open();
            string query = "select * from NhanVien where LoaiNhanVien = @1 and SHBuuCuc = @2";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.NVarChar);
            cm.Parameters.Add("@2", SqlDbType.Int);

            cm.Parameters["@1"].Value = "Vận Chuyển";
            cm.Parameters["@2"].Value = SHBuuCuc;

            SqlDataReader reader = cm.ExecuteReader();

            if (!reader.HasRows)
            {
                dbc.con.Close();
                return null;
            }

            List<NhanVien> nhanVien = new List<NhanVien>();
            while (reader.Read())
            {
                NhanVien nv = new NhanVien();
                nv.SH = reader.GetInt32(0);
                nv.NgaySinh = reader.GetDateTime(4);
                nhanVien.Add(nv);
            }

            query = "select * from ConNguoi where SH = @1";
            foreach (NhanVien nv in nhanVien)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters["@1"].Value = nv.SH;
                reader = cm.ExecuteReader();
                reader.Read();

                nv.Ten = reader.GetString(1);
                nv.Ho = reader.GetString(2);
                nv.DiaChi = reader.GetString(3);
                nv.Email = reader.GetString(4);
                nv.SDT = reader.GetString(5);
            }

            query = "select SH from PhieuGui where SHBuuCucNhan = @1 and SHNhanVienVanChuyen = @2";
            foreach (NhanVien nv in nhanVien)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters.Add("@2", SqlDbType.Int);
                cm.Parameters["@1"].Value = SHBuuCuc;
                cm.Parameters["@2"].Value = nv.SH;
                reader = cm.ExecuteReader();
                if (!reader.HasRows)
                {
                    continue;
                }
                nv.dsPhieuGui = new List<PhieuGui>();
                while (reader.Read())
                {
                    PhieuGui p = new PhieuGui();
                    p.SH = reader.GetInt32(0);
                    nv.dsPhieuGui.Add(p);
                }
            }
            dbc.con.Close();
            return nhanVien;
        }

        public static void lenTuyenPhat(int SHBuuCuc, NhanVien nhanVien)
        {
            dbc.con.Open();
            string query = "update PhieuGui set SHNhanVienVanChuyen = @1 where SH = @2 and SHBuuCucNhan = @3";
            foreach (PhieuGui pg in nhanVien.dsPhieuGui)
            {
                SqlCommand cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters.Add("@2", SqlDbType.Int);
                cm.Parameters.Add("@3", SqlDbType.Int);

                cm.Parameters["@1"].Value = nhanVien.SH;
                cm.Parameters["@2"].Value = pg.SH;
                cm.Parameters["@3"].Value = SHBuuCuc;
                cm.ExecuteNonQuery();
            }
            dbc.con.Close();
        }

        public static void xoaBuuGui(int SHBuuCuc, int SHBuuGui)
        {
            dbc.con.Open();
            string query = "update PhieuGui set SHNhanVienVanChuyen = null where SH = @1 and SHBuuCucNhan = @2";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters.Add("@2", SqlDbType.Int);

            cm.Parameters["@1"].Value = SHBuuGui;
            cm.Parameters["@2"].Value = SHBuuCuc;
            cm.ExecuteNonQuery();
            dbc.con.Close();
        }
    }
}
