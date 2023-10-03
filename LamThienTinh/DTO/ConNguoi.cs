using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ConNguoi
    {
        public int SH {get; set;}
        public string Ten {get; set;}
        public string Ho {get; set;}
        public string DiaChi {get; set;}
        public string Email {get; set;}
        public string SDT {get; set;}

        public ConNguoi()
        {

        }

        public ConNguoi(int SH, string Ten, string Ho, string DiaChi, string Email, string SDT)
        {
            this.SH = SH;
            this.Ten = Ten;
            this.Ho = Ho;
            this.DiaChi = DiaChi;
            this.Email = Email;
            this.SDT = SDT;
        }

        public static List<String> getAllProperties()
        {
            return new List<String> { "Số Hiệu", "Tên", "Họ", "Địa Chỉ", "Email", "Số Điện Thoại" };
        }
    }
}
