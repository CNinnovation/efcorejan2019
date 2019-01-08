using System.ComponentModel.DataAnnotations.Schema;

namespace TPHWithConventions
{
    public class CreditcardPayment : Payment
    {
        public string CreditcardNumber { get; set; }
    }
}
