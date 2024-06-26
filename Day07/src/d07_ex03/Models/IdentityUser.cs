using System.ComponentModel;
using d07_ex02.Attributes;

namespace d07_ex03.Models;

public class IdentityUser
{
   public IdentityUser()
   {
   }

   public IdentityUser(string userName) : this()
   {
       UserName = userName;
   }

   [Description("User name")]
   [DefaultValue("Me")]
   public virtual string UserName { get; set; }
   [Description("Email address")]
   [DefaultValue("test@test")]
   public virtual string Email { get; set; }
   [Description("Phone number")]
   [DefaultValue("1234567890")]
   public virtual string PhoneNumber { get; set; }
   
   [NoDisplay]
   public virtual string NormalizedUserName { get; set; }
   [NoDisplayAttribute]
   public virtual string NormalizedEmail { get; set; }
   [NoDisplayAttribute]
   public virtual bool EmailConfirmed { get; set; }
   [NoDisplayAttribute]
   public virtual string PasswordHash { get; set; }
   [NoDisplayAttribute]
   public virtual string SecurityStamp { get; set; }
   [NoDisplayAttribute]
   public virtual bool PhoneNumberConfirmed { get; set; }
   [NoDisplayAttribute]
   public virtual bool TwoFactorEnabled { get; set; }
   [NoDisplayAttribute]
   public virtual DateTimeOffset? LockoutEnd { get; set; }
   [NoDisplayAttribute]
   public virtual bool LockoutEnabled { get; set; }
   
   public virtual string ConcurrencyStamp() => Guid.NewGuid().ToString();
   public override string ToString()
       => $"User: {UserName}, {Email}, {PhoneNumber}";
}
