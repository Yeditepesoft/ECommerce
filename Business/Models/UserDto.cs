using Core.Signatures;

namespace Business.Models
{
    public class UserDto  :IBaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsSuperVisor { get; set; }
        public int UserGroupId { get; set; }
        public int? GenderId { get; set; }
        
    }
}