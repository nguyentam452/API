using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class Khoadt
    {
        public Khoadt()
        {
          // CtDts = new HashSet<CtDt>();
        }

        public int MaKhoaDt { get; set; }
        public string? TenKhoaDt { get; set; }
        public DateOnly? NamNhap { get; set; }
        public int? SoNamDt { get; set; }
        public int? MaNganh { get; set; }

        //public virtual Nganh? MaNganhNavigation { get; set; }
        //public virtual ICollection<CtDt> CtDts { get; set; }
    }
}
