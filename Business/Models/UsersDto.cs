using Core.Signatures;

namespace Business.Models
{
    public class UsersDto :IBaseListDto 
    {
        public string FullName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsSuperVisor { get; set; }
        public string UserGroup { get; set; }
        public string Gender { get; set; }
    }
}