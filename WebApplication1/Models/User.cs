using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication1.OutModels;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { set; get; }
        [Required (ErrorMessage = "Please fill FirstName!")]
        public string FirstName { set; get; }
        [Required (ErrorMessage = "Please fill LastName!")]
        public string LastName { set; get; }
        [Required (ErrorMessage = "Please fill Login!")]
        [DataType(DataType.EmailAddress)]
        public string Login { set; get; }
        [Required (ErrorMessage = "Please fill password!")]
        public string Password { set; get; }
    }
}
