
namespace Services.Contracts
{
    public class OrderDTOCreate
    {
        public Guid Id { get; set; }
        public ICollection<LineItemDTO> Lines { get; set; }

    }
}