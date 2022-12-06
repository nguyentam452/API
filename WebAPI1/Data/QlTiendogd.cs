using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class QlTiendogd
    {
        public int MatienDo { get; set; }
        public int? MaGv { get; set; }
        public int? SoTietNghi { get; set; }
        public DateTime? NgayNghi { get; set; }
        public int? SoTietBu { get; set; }
        public DateTime? NgayBu { get; set; }

     //   public virtual HsGiangvien? MaGvNavigation { get; set; }
    }
}
