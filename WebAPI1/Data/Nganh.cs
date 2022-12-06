using System;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public partial class Nganh
    {
        public Nganh()
        {
         //   Khoadts = new HashSet<Khoadt>();
        }

        public int MaNganh { get; set; }
        public int? MaKhoa { get; set; }
        public string? TenNganh { get; set; }

        //public virtual Khoa? MaKhoaNavigation { get; set; }
        //public virtual ICollection<Khoadt> Khoadts { get; set; }
    }
}
