using Chat.Contacts.Models;
using Chat.Db.Model;
using System.Threading.Tasks;

namespace Chat.Contacts.Interfaces
{
    public interface IContactService
    {
        Task<PaginationResponseBase<ContactDto>> GetAsync(ContactPaginationRequest request);

    }
}
