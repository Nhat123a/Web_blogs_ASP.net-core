using System;
using System.Collections.Generic;

namespace Project59.Models;

public partial class Chitiet
{
    public int Idchitiet { get; set; }

    public int? PostId { get; set; }

    public string? Nguoidang { get; set; }

    public string? Noidungchitiet { get; set; }

    public int? TagId { get; set; }

    public virtual Post? Post { get; set; }

    public virtual Tag? Tag { get; set; }
}
