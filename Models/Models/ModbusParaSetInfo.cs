using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class ModbusParaSetInfo
{
    public int ParaId { get; set; }

    public string ParaName { get; set; } = null!;

    public int SlaveAddress { get; set; }

    public int Address { get; set; }

    public string DataType { get; set; } = null!;

    public int DecimalPlaces { get; set; }

    public string StoreFunction { get; set; } = null!;

    public string? Note { get; set; }

    public bool IsAlarm { get; set; }

    public bool IsReport { get; set; }

    public int IsDeleted { get; set; }
}
