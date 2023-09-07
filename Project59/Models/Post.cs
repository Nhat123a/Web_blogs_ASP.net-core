using System;
using System.Collections.Generic;

namespace Project59.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string? Link { get; set; }

    public bool? Trangthai { get; set; }

    public string? Ten { get; set; }

    public string? Noidung { get; set; }

    public int? Id { get; set; }

    public DateTime? Ngay { get; set; }

    public string? Img { get; set; }

    public string? Loai { get; set; }

    public string? Nguoidang { get; set; }

    public string? Noidungchitiet { get; set; }

    public virtual Danhmuc? IdNavigation { get; set; }
}
