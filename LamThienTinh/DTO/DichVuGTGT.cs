using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class DichVuGTGT
    {
        public int SH { get; set; }
        public int Cuoc { get; set; }
        public string Ten { get; set; }
        public List<PhieuGui> DSPhieuGui { get; set; }


        public DichVuGTGT()
        {

        }

        public DichVuGTGT(int SH, string Ten, int Cuoc)
        {
            this.SH = SH;
            this.Ten = Ten;
            this.Cuoc = Cuoc;
        }

        public DichVuGTGT(int SH, string Ten, int Cuoc, List<PhieuGui> DSPhieuGui)
        {
            this.SH = SH;
            this.Ten = Ten;
            this.Cuoc = Cuoc;
            this.DSPhieuGui = DSPhieuGui;
        }
    }
}
