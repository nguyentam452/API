using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class Phong
    {
        public Phong()
        {
        //    CtPcGiangdays = new HashSet<CtPcGiangday>();
        }

        public int MaPhong { get; set; }
        public string? TenPhong { get; set; }
        public string? DiaDiem { get; set; }

       // public virtual ICollection<CtPcGiangday> CtPcGiangdays { get; set; }
    }
}
