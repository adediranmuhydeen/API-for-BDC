using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOModels
{
    public class UserRegistionDto
    {
        [Required]
        [MaxLength(25, ErrorMessage = "limit Exceeded")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "limit Exceeded")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "limit Exceeded")]
        public string LastName { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "At least 8 characters")]
        public string Password { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "limit Exceeded")]
        public string Email { get; set; }
    }
}
