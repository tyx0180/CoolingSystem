using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class StorageRegionInfo
{
    public int Id { get; set; }

    public int SlaveAddress { get; set; }

    public int FunctionCode { get; set; }

    public int StartAddress { get; set; }

    public int Length { get; set; }

    public string? Remark { get; set; }

    public int IsDeleted { get; set; }
}
