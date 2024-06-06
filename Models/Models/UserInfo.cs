using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPwd { get; set; } = null!;

    public string UserRealPwd { get; set; } = null!;

    public bool UserState { get; set; }

    public string? UserPhone { get; set; }

    public string? LastLoginIp { get; set; }

    public DateTime? LastLoginTime { get; set; }

    public int LoginCount { get; set; }

    public DateTime CreateTime { get; set; }

    public int IsDeleted { get; set; }
}
