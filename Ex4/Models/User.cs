using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ex4.Models
{
    public enum Status
    {
        Active,
        Block
    } 

    public class User : IdentityUser
    {
        public User(string userName, string email, string nickName) : base(userName)
        {
            Email = email;
            NickName = nickName;
            DateRegistration = DateTime.Now.Date;
            DateLastLogin = DateTime.Now.Date;
            Status = Status.Active;
        }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Nick")]
        public string NickName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Registration date")]
        public DateTime DateRegistration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of last login")]
        public DateTime DateLastLogin { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
