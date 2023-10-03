using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class PTVC
    {
        public int SH { get; set; }
        public int Cuoc { get; set; }
        public string Ten { get; set; }

        public PTVC()
        {
        }
        public PTVC(int SH, string Ten, int Cuoc)
        {
            this.SH = SH;
            this.Ten = Ten;
            this.Cuoc = Cuoc;
        }
    }
}
