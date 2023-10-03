using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVienBLL
    {
        public static NhanVien dangNhap(string tenDangNhap, string matKhau)
        {
            return NhanVienDAL.dangNhap(tenDangNhap, matKhau);
        }
    }
}
