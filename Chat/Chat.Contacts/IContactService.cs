using Chat.Contacts.Models;
using Chat.Db.Model;
using System.Threading.Tasks;

namespace Chat.Contacts
{
    public interface IContactService
    {
        Task<PaginationResponseBase<MyContacstDto>> GetMyContactsAsync(ContactPaginationRequest request);
    }
}
