using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class DichVu
    {
        public int SH { get; set; }
        public string Ten { get; set; }

        public DichVu()
        {
        }
        public DichVu(int SH, string Ten)
        {
            this.SH = SH;
            this.Ten = Ten;
        }
    }
}
