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
            TestStr = "Test";
        }

        [Required]
        [MaxLength(100)]
        public string NickName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateLastLogin { get; set; }

        [Required]
        public Status Status { get; set; }
        [Required]
        public string TestStr { get; set; }
    }
}
