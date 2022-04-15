namespace PermissionAPI.Dto
{
    public class PaginatorPatameersObject
    {
        public PaginatorPatameersObject()
        {
            this.page = 1;
            this.size = 5;
        }

        public int? after { get; set; }
        
        public int? before { get; set; }
        
        public int page { get; set; } 
        
        public int size { get; set; }
    }
}
