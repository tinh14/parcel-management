using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class KhachHang : ConNguoi
    {
        public KhachHang()
        {

        }
        public KhachHang(int SH, string Ten, string Ho, string DiaChi, string Email, string SDT) 
            : base(SH, Ten, Ho, DiaChi, Email, SDT)
        {
        }
    }
}
