using System;
using System.Collections.Generic;

namespace Project59.Models;

public partial class Danhmuc
{
    public int Id { get; set; }

    public string? Link { get; set; }

    public string? Ten { get; set; }

    public bool? Trangthai { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
