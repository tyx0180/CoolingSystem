using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class AlarmParaInfo
{
    public int AparaId { get; set; }

    public string AparaName { get; set; } = null!;

    public int AlarmType { get; set; }

    public string? AlarmValue { get; set; }

    public string ValueType { get; set; } = null!;

    public string? AlarmNote { get; set; }

    public int IsDeleted { get; set; }
}
