
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Services.Contracts
{
    public class OrderDTOCreate
    {
        [Required]
        [NotNull]
        public Guid Id { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Нельзя создать заказ без полей!")]
        public ICollection<LineItemDTO> Lines { get; set; }

    }
}