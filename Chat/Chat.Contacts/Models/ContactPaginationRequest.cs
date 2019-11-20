using Chat.Db.Model;

namespace Chat.Contacts.Models
{
    public class ContactPaginationRequest : PaginationRequestBase
    {
        public int UserId { get; set; }
    }
}
