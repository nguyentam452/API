using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class Lop
    {
        public string MaLop { get; set; } = null!;
        public string? TenLop { get; set; }
        public int? SiSo { get; set; }
        public int? MaGvcn { get; set; }

       // public virtual HsGiangvien? MaGvcnNavigation { get; set; }
    }
}
