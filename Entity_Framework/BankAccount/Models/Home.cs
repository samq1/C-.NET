using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BankAccount.Models
{
    // private List<Account> Transaction = new List<Account>();
    public abstract class BaseEntity {}
    public class User : BaseEntity
    {

        public int id { get; set; }

        [Required(ErrorMessage = "First name cannot be left blank.")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters in length.")]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Last name cannot be left blank.")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters in length.")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Email address cannot be left blank.")]
        [EmailAddress(ErrorMessage = "Email is not in the correct format.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password cannot be left blank.")]
        [Compare("confirm", ErrorMessage = "Password and confirm password do not match.")]
        [MinLength(3, ErrorMessage = "Password cannot be less than 3 characters.")]
        // [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;&#39;?/&gt;.&lt;,])(?!.*\s).*$", ErrorMessage = "Password must be at least 8 characters and include 1 lowercase letter, 1 uppercase letter, 1 number, and 1 special character.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Confirm Password cannot be left blank.")]
        public string confirm { get; set; }
        public List<Account> Account { get; set; }

        public User()
        {
            Account = new List<Account>();
        }

    }

    
    public class LogUser : BaseEntity
    { 
        [Required(ErrorMessage = "Email address cannot be left blank")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password cannot be left blank")]
        public string password { get; set; }
    }


    public class LoginRegViewModel : BaseEntity
    {
        public LogUser loginVM { get; set; }
        public User registerVM { get; set; }
    }
}