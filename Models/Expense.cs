using System.ComponentModel.DataAnnotations;

namespace SpendingTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
