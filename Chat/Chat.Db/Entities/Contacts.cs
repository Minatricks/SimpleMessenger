namespace Chat.Db.Entities
{
    public class Contacts
    {
        public int Id { get; set; }

        public int UserId { get; set; }


        public Users User { get; set; }
    }
}
