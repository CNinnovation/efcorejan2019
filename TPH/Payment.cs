using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPHWithConventions
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }
    }
}
