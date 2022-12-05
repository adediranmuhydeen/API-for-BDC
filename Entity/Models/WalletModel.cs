using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class WalletModel
    {
        [Key]
        public int WalletAddressId { get; set; }
        public string WalletAddress{ get; set; }
        
        public Double WalletBalance { get; set; } 
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public IEnumerable<TransactionModel> transactions { get; set; }
       
    }
}
