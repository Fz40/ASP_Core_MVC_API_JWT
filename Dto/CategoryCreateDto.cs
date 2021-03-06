using System.ComponentModel.DataAnnotations;

namespace JWTApi.Dto
{
    public partial class CategoryCreateDto
    {
        [Required]
        public string CategoryName { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
    }
}