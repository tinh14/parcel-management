using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class BangGia
    {
        public int SH { get; set; }
        public int NacKhoiLuong { get; set; }
        public int Cuoc { get; set; }

        public BangGia(int SH, int NacKhoiLuong, int Cuoc){
            this.SH = SH;
            this.NacKhoiLuong = NacKhoiLuong;
            this.Cuoc = Cuoc;
        }
    }
}
