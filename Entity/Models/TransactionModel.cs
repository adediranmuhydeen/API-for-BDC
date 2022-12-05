using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }
        public int TransactionType { get; set; }
        public string TransactionDate { get; set; } = DateTime.Now.ToString();
        public string Description { get; set; }
        public double TransactionAmount { get; set; }

        [ForeignKey(nameof(WalletAddress))]
        public int WalletAddressId { get; set; }
        public WalletModel WalletAddress { get; set; }

    }
}
