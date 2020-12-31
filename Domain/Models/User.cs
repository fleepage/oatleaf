using fleepage.oatleaf.com.Domain.BaseEntities;
using fleepage.oatleaf.com.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class User : BaseEntity
    {

        [Column(TypeName = "nvarchar(64)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string OtherNames { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string TempPassword { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Username { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LoginFailedDate { get; set; }
        public int LoginFailedCount { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }
        public DateTime? EmailConfirmedDate { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string EmailConfirmationCode { get; set; }
        public DateTime? PhoneConfirmedDate { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string PhoneConfirmationCode { get; set; }
        public DateTime? ResetPasswordRequestDate { get; set; }
        public int ResetPasswordCount { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Accounts> Accounts { get; set; }
        public ICollection<SocialMedia> SocialMedia { get; set; }
    }
}
