using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class ParaDataInfo
{
    public int Id { get; set; }

    public decimal? CwinTemperature { get; set; }

    public decimal? CwoutTemperature { get; set; }

    public decimal? FreezeInTemperature { get; set; }

    public decimal? FreezeOutTemperature { get; set; }

    public decimal? CwinPressure { get; set; }

    public decimal? CwoutPressure { get; set; }

    public decimal? FreezeInPressure { get; set; }

    public decimal? FreezeOutPressure { get; set; }

    public int? CoolPump1Frequency { get; set; }

    public int? CoolPump2Frequency { get; set; }

    public int? CoolPump3Frequency { get; set; }

    public int? ColdPump1Frequency { get; set; }

    public int? ColdPump2Frequency { get; set; }

    public int? ColdPump3Frequency { get; set; }

    public decimal? CurRoomTemperature { get; set; }

    public int? ColdPump1Power { get; set; }

    public int? ColdPump1Ec { get; set; }

    public int? ColdPump2Power { get; set; }

    public int? ColdPump2Ec { get; set; }

    public int? ColdPump3Power { get; set; }

    public int? ColdPump3Ec { get; set; }

    public int? CoolPump1Power { get; set; }

    public int? CoolPump1Ec { get; set; }

    public int? CoolPump2Power { get; set; }

    public int? CoolPump2Ec { get; set; }

    public int? CoolPump3Power { get; set; }

    public int? CoolPump3Ec { get; set; }

    public int? Cwcrew01Power { get; set; }

    public int? Cwcrew01Ec { get; set; }

    public int? Cwcrew02Power { get; set; }

    public int? Cwcrew02Ec { get; set; }

    public int? Cwcrew03Power { get; set; }

    public int? Cwcrew03Ec { get; set; }

    public decimal? Cwcrew01InTemperLow { get; set; }

    public decimal? Cwcrew01OutTemperLow { get; set; }

    public decimal? Cwcrew01InTemperHigh { get; set; }

    public decimal? Cwcrew01OutTemperHigh { get; set; }

    public decimal? Cwcrew02InTemperLow { get; set; }

    public decimal? Cwcrew02OutTemperLow { get; set; }

    public decimal? Cwcrew02InTemperHigh { get; set; }

    public decimal? Cwcrew02OutTemperHigh { get; set; }

    public decimal? Cwcrew03InTemperLow { get; set; }

    public decimal? Cwcrew03OutTemperLow { get; set; }

    public decimal? Cwcrew03InTemperHigh { get; set; }

    public decimal? Cwcrew03OutTemperHigh { get; set; }

    public int? Cwt01power { get; set; }

    public int? Cwt01frequency { get; set; }

    public decimal? Cwt01inPressure { get; set; }

    public decimal? Cwt01outPressure { get; set; }

    public decimal? Cwt01inTemperature { get; set; }

    public decimal? Cwt01outTemperature { get; set; }

    public int? Cwt02power { get; set; }

    public int? Cwt02frequency { get; set; }

    public decimal? Cwt02inPressure { get; set; }

    public decimal? Cwt02outPressure { get; set; }

    public decimal? Cwt02inTemperature { get; set; }

    public decimal? Cwt02outTemperature { get; set; }

    public DateTime InsertTime { get; set; }

    public int IsDeleted { get; set; }
}
