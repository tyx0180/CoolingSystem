using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class AlarmLogInfo
{
    public int AlarmLogId { get; set; }

    public int? AparaId { get; set; }

    public string AparaName { get; set; } = null!;

    public decimal Value { get; set; }

    public string? AlarmState { get; set; }

    public string? AlarmNote { get; set; }

    public DateTime AlarmTime { get; set; }

    public int IsDeleted { get; set; }
}
