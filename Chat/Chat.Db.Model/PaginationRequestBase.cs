namespace Chat.Db.Model
{
    public abstract class PaginationRequestBase
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 20;
    }
}
