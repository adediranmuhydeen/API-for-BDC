using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOModels
{
    public class WalletDto
    {
        public string Fullname { get; set; }
        public string WalletAddress { get; set; }
        public Double WalletBalance { get; set; }
    }
}
