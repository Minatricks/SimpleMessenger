namespace Chat.Db.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public int UserId { get; set; }


        public User User { get; set; }
    }
}
