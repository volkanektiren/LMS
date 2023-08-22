using Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.VisitorManagement
{
    [Table("Visitors", Schema = "VM")]
    public class Visitor : Person
    {

    }
}
