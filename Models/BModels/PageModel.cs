using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BModels
{
    public class PageModel<T>
    {
        public int All { get; set; }
        public List<T> reslist {get;set;}
    }
}
