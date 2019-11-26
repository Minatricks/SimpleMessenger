using Chat.Db;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Contacts.Mapping;
using Chat.Contacts.Models;
using Chat.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace Chat.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IChatDbContext _chatDbContext;

        public ContactService(IChatDbContext dbContext)
        {
            _chatDbContext = dbContext;
        }

        public async Task<PaginationResponseBase<MyContacstDto>> GetMyContactsAsync(ContactPaginationRequest request)
        {
            var contactListQuery = _chatDbContext.Contacts.Where(x => x.MyId == request.UserId).AsQueryable();

            var totalCount =  contactListQuery.CountAsync();
            var contactList =  contactListQuery.Select(x => x.ToContactDto())
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            await Task.WhenAll(totalCount, contactList);

            return new ContactPaginationResponse()
            {
                Data = await contactList,
                TotalCount = await totalCount
            };
        }
    }
}
