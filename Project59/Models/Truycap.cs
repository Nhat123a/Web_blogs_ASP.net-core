using System;
using System.Collections.Generic;

namespace Project59.Models;

public partial class Truycap
{
    public int RoleId { get; set; }

    public bool? Trangthai { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}
