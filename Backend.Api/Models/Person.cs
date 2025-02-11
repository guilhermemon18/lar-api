
namespace Backend.Api.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}