using Core.Signatures;

namespace Business.Models
{
    public class UserGroupDto :IBaseDto
    {
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
    }
}