using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class NhanVienKhaiThacDAL : NhanVienDAL
    {
        public static List<PhieuGui> danhSachPhieuGuiChuaLapBD8(int SHBuuCuc)
        {
            dbc.con.Open();
            string query = "select * from PhieuGui where SHBuuCucGui = @1 and SHBD8 is null";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHBuuCuc;
            SqlDataReader reader = cm.ExecuteReader();

            if (!reader.HasRows)
            {
                dbc.con.Close();
                return null;
            }

            List<PhieuGui> dsPhieuGui = new List<PhieuGui>();

            while (reader.Read())
            {
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
                pg.buuCucNhan = getBuuCucBySH(pg.buuCucNhan.SH);
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

        public static List<BD8> getAllBD8(int SHBuuCuc)
        {
            dbc.con.Open();
            string query = "select * from PhieuGui where SHBuuCucGui = @1 and SHBD8 is not null";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHBuuCuc;
            SqlDataReader reader = cm.ExecuteReader();

            if (!reader.HasRows)
            {
                dbc.con.Close();
                return null;
            }

            Dictionary<int, List<PhieuGui>> map = new Dictionary<int, List<PhieuGui>>();
            while (reader.Read())
            {
                PhieuGui phieuGui = new PhieuGui();
                phieuGui.buuCucGui = new BuuCuc();
                phieuGui.buuCucNhan = new BuuCuc();
                phieuGui.dichVu = new DichVu();

                phieuGui.SH = reader.GetInt32(0);
                phieuGui.KhoiLuongCanThuc = reader.GetInt32(2);
                phieuGui.KhoiLuongQuyDoi = reader.GetInt32(3);
                phieuGui.buuCucGui = getBuuCucBySH(reader.GetInt32(5));
                phieuGui.buuCucNhan = getBuuCucBySH(reader.GetInt32(6));
                phieuGui.dichVu = getDichVuBySH(reader.GetInt32(10));

                int key = reader.GetInt32(12);

                if (!map.ContainsKey(key)){
                    map[key] = new List<PhieuGui>();
                }
                map[key].Add(phieuGui);
            }

            List<BD8> bd8 = new List<BD8>();

            query = "select NgayDong from BD8 where SH = @1";
            foreach (int k in map.Keys)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters["@1"].Value = k;
                reader = cm.ExecuteReader();
                while (reader.Read())
                {
                    bd8.Add(new BD8(k, reader.GetDateTime(0), map[k]));
                }
            }
            dbc.con.Close();
            return bd8;
        }

        public static void lapBD8(BD8 bd8)
        {
            dbc.con.Open();
            string query = "insert into BD8 (NgayDong) values (@1) SELECT SCOPE_IDENTITY()";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Date);
            cm.Parameters["@1"].Value = bd8.NgayDong;
            int SH = Convert.ToInt32(cm.ExecuteScalar());

            query = "update PhieuGui set SHBD8 = @1 where SH = @2";
            foreach (PhieuGui pg in bd8.PhieuGui)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters.Add("@2", SqlDbType.Int);
                cm.Parameters["@1"].Value = SH;
                cm.Parameters["@2"].Value = pg.SH;
                cm.ExecuteNonQuery();
            }
            dbc.con.Close();
        }

        public static void xoaBD8(int SH)
        {
            dbc.con.Open();
            string query = "update PhieuGui set SHBD8 = null where SHBD8 = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SH;
            cm.ExecuteNonQuery();

            query = "delete from BD8 where SH = @1";
            cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SH;
            cm.ExecuteNonQuery();
            dbc.con.Close();
        }

        public static void xoaBuuGuiKhoiBD8(int SHBuuGui)
        {
            dbc.con.Open();
            string query = "update PhieuGui set SHBD8 = null where SH = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHBuuGui;
            cm.ExecuteNonQuery();
            dbc.con.Close();
        }

        public static List<BD8> danhSachBD8ChuaLapBD10(int SHBuuCuc)
        {
            List<BD8> temp = getAllBD8(SHBuuCuc);
            dbc.con.Open();
            List<BD8> bd8 = new List<BD8>();
            string query = "select SH from BD8 where SH = @1 and SHBD10 is null";
            SqlCommand cm;
            SqlDataReader reader;
            foreach (BD8 b in temp)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters["@1"].Value = b.SH;
                reader = cm.ExecuteReader();
                if (reader.HasRows)
                {
                    bd8.Add(b);
                }
            }
            dbc.con.Close();
            return bd8;
        }

        public static List<BD10> getAllBD10(int SHBuuCuc)
        {
            List<BD8> bd8 = getAllBD8(SHBuuCuc);
            if (bd8 == null)
            {
                return null;
            }
            dbc.con.Open();
            Dictionary<int, List<BD8>> map = new Dictionary<int, List<BD8>>();
            SqlCommand cm;
            SqlDataReader reader;

            string query = "select SHBD10 from BD8 where SH = @1 and SHBD10 is not null";
            foreach (BD8 b in bd8)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters["@1"].Value = b.SH;
                reader = cm.ExecuteReader();

                if (!reader.HasRows)
                {
                    continue;
                }

                reader.Read();

                int key = reader.GetInt32(0);

                if (!map.ContainsKey(key))
                {
                    map[key] = new List<BD8>();
                }
                map[key].Add(b);
            }

            if (map.Count == 0)
            {
                dbc.con.Close();
                return null;
            }

            List<BD10> bd10 = new List<BD10>();
            foreach (int k in map.Keys)
            {
                query = "select NgayDong from BD10 where SH = @1";
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters["@1"].Value = k;
                reader = cm.ExecuteReader();
                reader.Read();

                bd10.Add(new BD10(k, reader.GetDateTime(0), map[k]));
            }
            dbc.con.Close();
            return bd10;
        }

        public static void lapBD10(BD10 bd10)
        {
            dbc.con.Open();
            string query = "insert into BD10 (NgayDong) values (@1) SELECT SCOPE_IDENTITY()";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Date);
            cm.Parameters["@1"].Value = bd10.NgayDong;
            int SH = Convert.ToInt32(cm.ExecuteScalar());

            query = "update BD8 set SHBD10 = @1 where SH = @2";
            foreach (BD8 b in bd10.bd8)
            {
                cm = new SqlCommand(query, dbc.con);
                cm.Parameters.Add("@1", SqlDbType.Int);
                cm.Parameters.Add("@2", SqlDbType.Int);
                cm.Parameters["@1"].Value = SH;
                cm.Parameters["@2"].Value = b.SH;
                cm.ExecuteNonQuery();
            }
            dbc.con.Close();
        }

        public static void xoaBD10(int SH)
        {
            dbc.con.Open();
            string query = "update BD8 set SHBD10 = NULL where SHBD10 = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SH;
            cm.ExecuteNonQuery();

            query = "delete from BD10 where SH = @1";
            cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SH;
            cm.ExecuteNonQuery();
            dbc.con.Close();
        }

        public static void xoaBD8KhoiBD10(int SHBD8)
        {
            dbc.con.Open();
            string query = "update BD8 set SHBD10 = null where SH = @1";
            SqlCommand cm = new SqlCommand(query, dbc.con);
            cm.Parameters.Add("@1", SqlDbType.Int);
            cm.Parameters["@1"].Value = SHBD8;
            cm.ExecuteNonQuery();
            dbc.con.Close();
        }
    }
}
