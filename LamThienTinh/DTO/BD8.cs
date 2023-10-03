using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class BD8
    {
        public int SH { get; set; }
        public DateTime NgayDong { get; set; }
        public List<PhieuGui> PhieuGui { get; set; }

        public BD8()
        {
        }

        public BD8(int SH, DateTime NgayDong, List<PhieuGui> PhieuGui)
        {
            this.SH = SH;
            this.NgayDong = NgayDong;
            this.PhieuGui = PhieuGui;
        }
    }
}
