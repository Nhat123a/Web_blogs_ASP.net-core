using System;
using System.Collections.Generic;

namespace Project59.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string? Name { get; set; }

    public bool? Trangthai { get; set; }

    public virtual ICollection<Chitiet> Chitiets { get; set; } = new List<Chitiet>();
}
