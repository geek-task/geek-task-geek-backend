using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Utils
{
    public class LoginUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Login { set; get; }

        [Required]
        public string Password { set; get; }
    }
}
