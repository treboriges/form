using System;
using Form;
using System.ComponentModel.DataAnnotations;
using DbConnection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;



namespace Form.Models
{
    public abstract class BaseEntity { }

    public class User : BaseEntity
    {
        [Required]
        [MinLength(4, ErrorMessage = "Your name must be at least 4 characters")]
        public string first_name { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Your name must be at least 4 characters")]
        public string last_name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "You're not a negative age")]
        public int age { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Your email must be valid")]
        [EmailAddress]
        public string email_address { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Your password must be at least 8 characters")]
        public string password { get; set; }

    }
}




