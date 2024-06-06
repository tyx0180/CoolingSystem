using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class MenuInfo
{
    public int MenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public int ParentId { get; set; }

    public string? FrmName { get; set; }

    public string? MenuImg { get; set; }

    public bool IsTop { get; set; }

    public int Morder { get; set; }

    public DateTime CreateTime { get; set; }

    public string? MenuCode { get; set; }

    public int IsDeleted { get; set; }
}
