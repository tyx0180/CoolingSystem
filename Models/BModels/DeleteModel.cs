using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BModels
{
    public class DeleteModel<T>:SearchFilter
    {
        public List<T> DeleteList { get; set; }
    }
}
