using Core.Signatures;

namespace Business.Models
{
    public class GendersDto :IBaseListDto
    {
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
    }
}