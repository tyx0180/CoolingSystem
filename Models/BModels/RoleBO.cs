using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BModels
{
    public class RoleBO
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } = null!;

        public string? Remark { get; set; }

        public bool IsAdmin { get; set; }=false;

        public int IsDeleted { get; set; } = 0;
        public DateTime CreateTime { get; set; }=DateTime.Now;
    }
}
