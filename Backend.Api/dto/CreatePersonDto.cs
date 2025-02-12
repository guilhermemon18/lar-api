
namespace Backend.Api.dto
{
    public class CreatePersonDto
    {

        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public DateOnly BirthDate { get; set; }
        public bool IsActive { get; set; }
        public List<CreatePhoneDto>? Phones { get; set; }
    }
}