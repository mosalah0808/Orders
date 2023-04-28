namespace Entities
{
    public class Order : BaseEntity<Guid>
    {
       
        public string Status { get; set; }
        public string Created { get; set; }
        public ICollection<LineItem> Lines { get; set; }
    }
    
}