namespace Chat.Db.Entities
{
    public class UsersProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string ImageUrl { get; set; }

        public string About { get; set; }

        public string Country { get; set; }

        public string City { get; set; }


        public int UserId { get; set; }
        
        public Users User { get; set; }
    }
}
