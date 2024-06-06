using Models.Context;
using Models.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    
    public class MenuRepository: IMenuRespository
    {
        private JkidwpdbaseContext _Context;
        public MenuRepository(JkidwpdbaseContext context)
        {
            _Context = context;
        }

        public List<MenuInfo> GetMenuInfos()
        {
            return _Context.MenuInfos.ToList();
        }
    }
}
