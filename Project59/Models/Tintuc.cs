using System;
using System.Collections.Generic;

namespace Project59.Models;

public partial class Tintuc
{
    public int Id { get; set; }

    public DateTime? Ngay { get; set; }

    public string? Ten { get; set; }

    public string? Tieude { get; set; }

    public string? Noidung { get; set; }

    public bool? Trangthai { get; set; }

    public string? Img { get; set; }

    public int? Tim { get; set; }

    public int? Cmt { get; set; }

    public int? Share { get; set; }

    public string? Loai { get; set; }
}
