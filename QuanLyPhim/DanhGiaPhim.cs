//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyPhim
{
    using System;
    using System.Collections.Generic;
    
    public partial class DanhGiaPhim
    {
        public int MaDanhGia { get; set; }
        public int MaPhim { get; set; }
        public int MaNguoiDung { get; set; }
        public Nullable<System.DateTime> ThoiGianBinhLuan { get; set; }
        public string NoiDungBinhLuan { get; set; }
        public Nullable<int> SoSao { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual Phim Phim { get; set; }
    }
}
