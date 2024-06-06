using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Models.Context;

public partial class JkidwpdbaseContext : DbContext
{
    public JkidwpdbaseContext()
    {
    }

    public JkidwpdbaseContext(DbContextOptions<JkidwpdbaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlarmLogInfo> AlarmLogInfos { get; set; }

    public virtual DbSet<AlarmParaInfo> AlarmParaInfos { get; set; }

    public virtual DbSet<AlarmTypeInfo> AlarmTypeInfos { get; set; }

    public virtual DbSet<MenuInfo> MenuInfos { get; set; }

    public virtual DbSet<ModbusParaSetInfo> ModbusParaSetInfos { get; set; }

    public virtual DbSet<ParaDataInfo> ParaDataInfos { get; set; }

    public virtual DbSet<RoleInfo> RoleInfos { get; set; }

    public virtual DbSet<RoleMenuInfo> RoleMenuInfos { get; set; }

    public virtual DbSet<StorageRegionInfo> StorageRegionInfos { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserRoleInfo> UserRoleInfos { get; set; }

    public virtual DbSet<ViewAlarmLogInfo> ViewAlarmLogInfos { get; set; }

    public virtual DbSet<ViewMenuInfo> ViewMenuInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=JKIDWPDBase;Persist Security Info=True;User ID=sa;PWD=sa;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlarmLogInfo>(entity =>
        {
            entity.HasKey(e => e.AlarmLogId);

            entity.Property(e => e.AlarmNote).HasMaxLength(100);
            entity.Property(e => e.AlarmState)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AlarmTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AparaId).HasColumnName("AParaId");
            entity.Property(e => e.AparaName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("男")
                .HasColumnName("AParaName");
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<AlarmParaInfo>(entity =>
        {
            entity.HasKey(e => e.AparaId);

            entity.Property(e => e.AparaId).HasColumnName("AParaId");
            entity.Property(e => e.AlarmNote).HasMaxLength(100);
            entity.Property(e => e.AlarmValue)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AparaName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AParaName");
            entity.Property(e => e.ValueType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AlarmTypeInfo>(entity =>
        {
            entity.HasKey(e => e.AtypeId);

            entity.Property(e => e.AtypeId).HasColumnName("ATypeId");
            entity.Property(e => e.AtypeName)
                .HasMaxLength(50)
                .HasColumnName("ATypeName");
        });

        modelBuilder.Entity<MenuInfo>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FrmName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MenuCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MenuImg)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MenuName).HasMaxLength(50);
            entity.Property(e => e.Morder).HasColumnName("MOrder");
        });

        modelBuilder.Entity<ModbusParaSetInfo>(entity =>
        {
            entity.HasKey(e => e.ParaId);

            entity.Property(e => e.DataType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Note).HasMaxLength(50);
            entity.Property(e => e.ParaName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SlaveAddress).HasDefaultValue(1);
            entity.Property(e => e.StoreFunction)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ParaDataInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ColdWaterCrewInfos");

            entity.Property(e => e.ColdPump1Ec).HasColumnName("ColdPump1EC");
            entity.Property(e => e.ColdPump2Ec).HasColumnName("ColdPump2EC");
            entity.Property(e => e.ColdPump3Ec).HasColumnName("ColdPump3EC");
            entity.Property(e => e.CoolPump1Ec).HasColumnName("CoolPump1EC");
            entity.Property(e => e.CoolPump2Ec).HasColumnName("CoolPump2EC");
            entity.Property(e => e.CoolPump3Ec).HasColumnName("CoolPump3EC");
            entity.Property(e => e.CurRoomTemperature).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Cwcrew01Ec).HasColumnName("CWCrew01EC");
            entity.Property(e => e.Cwcrew01InTemperHigh)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew01InTemperHigh");
            entity.Property(e => e.Cwcrew01InTemperLow)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew01InTemperLow");
            entity.Property(e => e.Cwcrew01OutTemperHigh)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew01OutTemperHigh");
            entity.Property(e => e.Cwcrew01OutTemperLow)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew01OutTemperLow");
            entity.Property(e => e.Cwcrew01Power).HasColumnName("CWCrew01Power");
            entity.Property(e => e.Cwcrew02Ec).HasColumnName("CWCrew02EC");
            entity.Property(e => e.Cwcrew02InTemperHigh)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew02InTemperHigh");
            entity.Property(e => e.Cwcrew02InTemperLow)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew02InTemperLow");
            entity.Property(e => e.Cwcrew02OutTemperHigh)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew02OutTemperHigh");
            entity.Property(e => e.Cwcrew02OutTemperLow)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew02OutTemperLow");
            entity.Property(e => e.Cwcrew02Power).HasColumnName("CWCrew02Power");
            entity.Property(e => e.Cwcrew03Ec).HasColumnName("CWCrew03EC");
            entity.Property(e => e.Cwcrew03InTemperHigh)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew03InTemperHigh");
            entity.Property(e => e.Cwcrew03InTemperLow)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew03InTemperLow");
            entity.Property(e => e.Cwcrew03OutTemperHigh)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew03OutTemperHigh");
            entity.Property(e => e.Cwcrew03OutTemperLow)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWCrew03OutTemperLow");
            entity.Property(e => e.Cwcrew03Power).HasColumnName("CWCrew03Power");
            entity.Property(e => e.CwinPressure)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWInPressure");
            entity.Property(e => e.CwinTemperature)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWInTemperature");
            entity.Property(e => e.CwoutPressure)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWOutPressure");
            entity.Property(e => e.CwoutTemperature)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWOutTemperature");
            entity.Property(e => e.Cwt01frequency).HasColumnName("CWT01Frequency");
            entity.Property(e => e.Cwt01inPressure)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWT01InPressure");
            entity.Property(e => e.Cwt01inTemperature)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWT01InTemperature");
            entity.Property(e => e.Cwt01outPressure)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWT01OutPressure");
            entity.Property(e => e.Cwt01outTemperature)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWT01OutTemperature");
            entity.Property(e => e.Cwt01power).HasColumnName("CWT01Power");
            entity.Property(e => e.Cwt02frequency).HasColumnName("CWT02Frequency");
            entity.Property(e => e.Cwt02inPressure)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWT02InPressure");
            entity.Property(e => e.Cwt02inTemperature)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWT02InTemperature");
            entity.Property(e => e.Cwt02outPressure)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWT02OutPressure");
            entity.Property(e => e.Cwt02outTemperature)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CWT02OutTemperature");
            entity.Property(e => e.Cwt02power).HasColumnName("CWT02Power");
            entity.Property(e => e.FreezeInPressure)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FreezeInTemperature)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FreezeOutPressure)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FreezeOutTemperature)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InsertTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<RoleInfo>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<RoleMenuInfo>(entity =>
        {
            entity.HasKey(e => e.Rmid).HasName("PK_RoleMennuInfos");

            entity.Property(e => e.Rmid).HasColumnName("RMId");
        });

        modelBuilder.Entity<StorageRegionInfo>(entity =>
        {
            entity.Property(e => e.Remark).HasMaxLength(500);
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastLoginIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastLoginTime).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserPwd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserRealPwd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserState).HasDefaultValue(true);
        });

        modelBuilder.Entity<UserRoleInfo>(entity =>
        {
            entity.HasKey(e => e.Urid);

            entity.Property(e => e.Urid).HasColumnName("URId");
        });

        modelBuilder.Entity<ViewAlarmLogInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewAlarmLogInfos");

            entity.Property(e => e.AlarmNote).HasMaxLength(100);
            entity.Property(e => e.AlarmState)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AlarmTime).HasColumnType("datetime");
            entity.Property(e => e.AlarmValue)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AparaId).HasColumnName("AParaId");
            entity.Property(e => e.AparaName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AParaName");
            entity.Property(e => e.AtypeName)
                .HasMaxLength(50)
                .HasColumnName("ATypeName");
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ViewMenuInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewMenuInfos");

            entity.Property(e => e.FrmName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MenuCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MenuName).HasMaxLength(50);
            entity.Property(e => e.Morder).HasColumnName("MOrder");
            entity.Property(e => e.PmenuName)
                .HasMaxLength(50)
                .HasColumnName("PMenuName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
