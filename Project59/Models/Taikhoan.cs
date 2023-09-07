using System;
using System.Collections.Generic;

namespace Project59.Models;

public partial class Taikhoan
{
    public int Id { get; set; }

    public string? Hoten { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Diachi { get; set; }

    public string? Email { get; set; }

    public int? Sdt { get; set; }

    public bool? Trangthai { get; set; }

    public string? Mota { get; set; }

    public int? RoleId { get; set; }

    public string? Taikhoan1 { get; set; }

    public string? Matkhau { get; set; }

    public virtual Truycap? Role { get; set; }
}
