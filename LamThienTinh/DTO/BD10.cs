using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class BD10
    {
        public int SH { get; set; }
        public DateTime NgayDong { get; set; }
        public List<BD8> bd8 { get; set; }

        public BD10()
        {

        }
        public BD10(int SH, DateTime NgayDong, List<BD8> bd8)
        {
            this.SH = SH;
            this.NgayDong = NgayDong;
            this.bd8 = bd8;
        }
    }
}
