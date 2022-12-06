using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class CtPcGiangday
    {
        public int MaCtpcgd { get; set; }
        public int? MaPcgd { get; set; }
        public int? MaGv { get; set; }
        public int? MaPhong { get; set; }
        public DateTime? NgayBd { get; set; }
        public DateTime? NgayKt { get; set; }

        //public virtual HsGiangvien? MaGvNavigation { get; set; }
        //public virtual PcGiangday? MaPcgdNavigation { get; set; }
        //public virtual Phong? MaPhongNavigation { get; set; }
    }
}
