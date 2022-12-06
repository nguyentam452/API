using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class CtDt
    {
        public CtDt()
        {
            //PcGiangdays = new HashSet<PcGiangday>();
        }

        public int MaHocPhan { get; set; }
        public int? MaKhoaDt { get; set; }
        public int? MaMon { get; set; }
        public int? HocKy { get; set; }
        public int? Nam { get; set; }
        public int? SoTinChi { get; set; }
        public int? Tcll { get; set; }
        public int? Tcth { get; set; }
        public int? TietDatLt { get; set; }
        public int? TietDayTh { get; set; }

    }
}
