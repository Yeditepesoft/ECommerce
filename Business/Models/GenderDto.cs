using Core.Signatures;

namespace Business.Models
{
    public class GenderDto :IBaseDto
    {
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
    }
}