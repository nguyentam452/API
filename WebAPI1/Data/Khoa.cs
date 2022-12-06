using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class Khoa
    {
        public Khoa()
        {
            //HsGiangviens = new HashSet<HsGiangvien>();
            //Nganhs = new HashSet<Nganh>();
        }

        public int MaKhoa { get; set; }
        public string? TenKhoa { get; set; }
        public int? TrgKhoa { get; set; }

        //public virtual HsGiangvien? TrgKhoaNavigation { get; set; }
        //public virtual ICollection<HsGiangvien> HsGiangviens { get; set; }
        //public virtual ICollection<Nganh> Nganhs { get; set; }
    }
}
