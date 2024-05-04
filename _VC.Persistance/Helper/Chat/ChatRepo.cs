using _VC.Application.IHelper.Chat;
using _VC.Domain.Data.Chat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance.Helper.Chat
{
    public class ChatRepo : IChat
    {
        private readonly ApplicationDbContext context;

        public ChatRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<AddMessage>> GetMessagesByVirtualCompanyAsync(int virtualCompanyId)
           => await context.messages.Where(e=>e.VirtualCompanyId.Equals(virtualCompanyId))
                .ToListAsync();
         
    }
}
