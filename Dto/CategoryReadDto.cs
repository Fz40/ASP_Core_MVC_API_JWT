using System.ComponentModel.DataAnnotations;

namespace JWTApi.Dto
{
    public partial class CategoryReadDto
    {

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}