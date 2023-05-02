using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Services.Contracts
{
    public class LineItemDTO
    {
        [Required]
        [NotNull]
        public Guid Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Значение Qty должно быть больше 0!")]
        public int Qty { get; set; }
    }
}
