using _VC.Domain.Data.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.IHelper.Chat
{
    public interface IChat
    {
        Task<IEnumerable<AddMessage>> GetMessagesByVirtualCompanyAsync(int virtualCompanyId); 
    }
}
