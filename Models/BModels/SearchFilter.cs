using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BModels
{
    public class SearchFilter
    {
        public string KeyWords {  get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int IsDelete {  get; set; }
    }
}
