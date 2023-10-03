using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HangGui
    {
        public int SH {get; set;}
        public string Ten { get; set; }
        public string TenTiengAnh { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public int GiaTri { get; set; }
        public int KhoiLuong { get; set; }

        public HangGui() { }

        public HangGui(int SH, string Ten, string TenTiengAnh, int SoLuong, string DonViTinh, int GiaTri, int KhoiLuong)
        {
            this.SH = SH;
            this.Ten = Ten;
            this.TenTiengAnh = TenTiengAnh;
            this.SoLuong = SoLuong;
            this.DonViTinh = DonViTinh;
            this.GiaTri = GiaTri;
            this.KhoiLuong = KhoiLuong;
        }

        public static List<String> getAllProperties()
        {
            return new List<String> { "Số Hiệu", "Tên", "Tên Tiếng Anh", "Số Lượng", "Đơn Vị Tính", "Giá Trị", "Khối Lượng" };
        }
    }
}
