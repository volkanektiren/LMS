using LMS.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.VisitorManagement
{
    [Table("Visitors", Schema = "VM")]
    public class Visitor : Person
    {

    }
}
