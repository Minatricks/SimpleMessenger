using Chat.Db;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Contacts.Mapping;
using Chat.Contacts.Models;
using Chat.Db.Model;
using Microsoft.EntityFrameworkCore;
using Chat.Exceptions;

namespace Chat.Contacts
{
    public class ContactService
    {
        private readonly IChatDbContext _chatDbContext;

        public ContactService(IChatDbContext dbContext)
        {
            _chatDbContext = dbContext;
        }

        public async Task<PaginationResponseBase<ContactDto>> GetAsync(ContactPaginationRequest request)
        {
            var user = await _chatDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null)
            {
                throw new IncorrectParametersException("Cannot find selected user", new { UserId = request.UserId });
            }

            var contactListQuery = _chatDbContext.Contacts.Where(x => x.UserId == request.UserId).AsQueryable();

            var totalCount = contactListQuery.CountAsync();
            
            var contactList = contactListQuery
                .Select(x => x.ToContactDto())
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
