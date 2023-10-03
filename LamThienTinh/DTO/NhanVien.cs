using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhanVien : ConNguoi
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Loai { get; set; }
        public DateTime NgaySinh { get; set; }
        public BuuCuc buuCuc { get; set; }
        public List<PhieuGui> dsPhieuGui { get; set; }

        public NhanVien()
        {
        }

        public NhanVien(int SH, string Ten, string Ho, string DiaChi, string Email, string SDT, string TenDangNhap, string MatKhau, string Loai, DateTime NgaySinh, BuuCuc buuCuc) 
            : base(SH, Ten, Ho, DiaChi, Email, SDT)
        {
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.Loai = Loai;
            this.NgaySinh = NgaySinh;
            this.buuCuc = buuCuc;
        }

        public static new List<string> getAllProperties()
        {
            List<string> props = ConNguoi.getAllProperties();
            props.AddRange(new List<string>() {"Ngày Sinh"});
            return props;
        }
    }
}
