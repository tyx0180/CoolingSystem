using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class AlarmTypeInfo
{
    public int AtypeId { get; set; }

    public string AtypeName { get; set; } = null!;

    public int IsDeleted { get; set; }
}
