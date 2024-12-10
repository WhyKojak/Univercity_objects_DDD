using System.ComponentModel.DataAnnotations;

namespace Univercity_objects.Domain;

public class CafedraEntity
{
    [Key]
    public Guid guid { get; set; }
    public string name { get; set; }
    public string description { get; set; }

}
