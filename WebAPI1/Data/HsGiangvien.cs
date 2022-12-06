using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class HsGiangvien
    {
        public HsGiangvien()
        {
            //CtPcGiangdays = new HashSet<CtPcGiangday>();
            //Khoas = new HashSet<Khoa>();
            //Lops = new HashSet<Lop>();
            //QlTiendogds = new HashSet<QlTiendogd>();
        }

        public int MaGv { get; set; }
        public string? HoTen { get; set; }
        public string? HocVi { get; set; }
        public string? HocHam { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? Ngsinh { get; set; }
        public string? SDt { get; set; }
        public string? Email { get; set; }
        public DateTime? Ngvl { get; set; }
        public int? MaKhoa { get; set; }

        //public virtual Khoa? MaKhoaNavigation { get; set; }
        //public virtual ICollection<CtPcGiangday> CtPcGiangdays { get; set; }
        //public virtual ICollection<Khoa> Khoas { get; set; }
        //public virtual ICollection<Lop> Lops { get; set; }
        //public virtual ICollection<QlTiendogd> QlTiendogds { get; set; }
    }
}
