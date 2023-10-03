using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ChiDanKhongPhatDuoc
    {
        public int SH { get; set; }
        public string Ten { get; set; }

        public ChiDanKhongPhatDuoc()
        {
        }
        public ChiDanKhongPhatDuoc(int SH, string Ten)
        {
            this.SH = SH;
            this.Ten = Ten;
        }
    }
}
