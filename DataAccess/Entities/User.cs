using Core.Signatures;

namespace DataAccess.Entities
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsSuperVisor { get; set; }
        public int UserGroupId { get; set; }
        public int? GenderId { get; set; }
        public byte[] PasswordSalt { get; set; } 
        public byte[] PasswordHash { get; set; }
        
        public UserGroup UserGroup { get; set; }
        public Gender Gender { get; set; }
    }
}