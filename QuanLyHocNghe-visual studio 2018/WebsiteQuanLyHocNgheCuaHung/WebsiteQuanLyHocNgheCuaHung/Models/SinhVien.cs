
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WebsiteQuanLyHocNgheCuaHung.Models
{

using System;
    using System.Collections.Generic;
    
public partial class SinhVien
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public SinhVien()
    {

        this.ChungChiSinhViens = new HashSet<ChungChiSinhVien>();

    }


    public string IDSinhVien { get; set; }

    public int MSSV { get; set; }

    public string HoTen { get; set; }

    public string DiaChi { get; set; }

    public string NgonNguLapTrinh { get; set; }

    public System.DateTime NgaySinh { get; set; }

    public string TrinhDoHocVan { get; set; }

    public Nullable<int> DiemTOEFL { get; set; }

    public string TinhTrangSinhVien { get; set; }

    public Nullable<int> DiemThiTracNghiem { get; set; }



    public virtual AspNetUser AspNetUser { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ChungChiSinhVien> ChungChiSinhViens { get; set; }

    public virtual HopDong HopDong { get; set; }

}

}
