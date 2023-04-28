namespace Services.Contracts
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string? Status { get; set; }
        public string? Created { get; set; }

        public ICollection<LineItemDTO> Lines { get; set; }

    }
}