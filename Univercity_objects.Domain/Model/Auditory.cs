using System.ComponentModel.DataAnnotations.Schema;

namespace Univercity_objects.Domain;

public class Auditory : BaseEntity
{
    public CafedraEntity cafedra { get; set; }
}
