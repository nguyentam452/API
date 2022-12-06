using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class PcGiangday
    {
        public PcGiangday()
        {
           // CtPcGiangdays = new HashSet<CtPcGiangday>();
        }

        public int MaPcgd { get; set; }
        public int? MaLop { get; set; }
        public int? MaHocPhan { get; set; }
        public string? Ca { get; set; }
        public string? Thu { get; set; }
        public DateOnly? Ngay { get; set; }

        //public virtual CtDt? MaHocPhanNavigation { get; set; }
        //public virtual ICollection<CtPcGiangday> CtPcGiangdays { get; set; }
    }
}
