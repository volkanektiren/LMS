using System;

namespace Common.DTOs.Base
{
    public class PersonDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
