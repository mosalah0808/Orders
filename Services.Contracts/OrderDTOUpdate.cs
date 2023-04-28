namespace Services.Contracts
{
    public class OrderDTOUpdate
    {
       public string? Status { get; set; }
       public ICollection<LineItemDTO> Lines { get; set; }

    }
}