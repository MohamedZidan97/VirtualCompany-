using _VC.Domain.Contents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance.Helper
{
    public class SendListRepo
    {


        public async Task<IList<string>> ListRolesAsync()
        {
            var list = new List<string>();  
            list.Add(ERoles.StokeHolder.ToString());  
            list.Add(ERoles.User.ToString());  


            return list;
        }
    }
}
