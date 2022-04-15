namespace PermissionAPI.Dto
{
    public class PaginatedObject<T>
    {
        public PaginatedObject()
        {
            Items = new List<T>();
        }

        public int After { get; set; }

        public int Before { get; set; }

        public int TotalCount { get; set; }

        public int CurrentPage { get;set; }

        public int Size { get; set; }

        public int Page { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
