using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models.Base
{
    public abstract class Person : BaseEntity
    {
        [Encrypted]
        public string Name { get; set; }
        [Encrypted]
        public string Surname { get; set; }
        [Encrypted]
        public string Email { get; set; }
        [Encrypted]
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
