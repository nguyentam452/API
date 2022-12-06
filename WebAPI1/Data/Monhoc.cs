using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class Monhoc
    {
        public Monhoc()
        {
          //  CtDts = new HashSet<CtDt>();
        }

        public int MaMon { get; set; }
        public string? TenMon { get; set; }

       // public virtual ICollection<CtDt> CtDts { get; set; }
    }
}
