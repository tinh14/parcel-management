using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Loai
    {
        public int SH { get; set; }
        public string Ten { get; set; }
        public List<PhieuGui> PhieuGui { get; set; }

        public Loai()
        {

        }

        public Loai(int SH, string Ten)
        {
            this.SH = SH;
            this.Ten = Ten;
        }

        public Loai(int SH, string Ten, List<PhieuGui> PhieuGui)
        {
            this.SH = SH;
            this.Ten = Ten;
            this.PhieuGui = PhieuGui;
        }
    }
}
