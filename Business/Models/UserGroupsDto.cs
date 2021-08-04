using Core.Signatures;

namespace Business.Models
{
    public class UserGroupsDto:IBaseListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
    }
}