
using System.ComponentModel.DataAnnotations;
using Backend.Api.Utils.Validation;

namespace Backend.Api.dto
{
    public class CreatePersonDto
    {

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        [CpfValidation]
        public string? Cpf { get; set; }
        [Required]
        // [DataType(DataType.Date)]
        public DateOnly? BirthDate { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public List<CreatePhoneDto>? Phones { get; set; }
    }
}