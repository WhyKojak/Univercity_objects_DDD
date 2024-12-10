using System.ComponentModel.DataAnnotations;

namespace Univercity_objects.Domain;

public abstract class BaseEntity 
{
    [Key]
    public Guid guid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string inv_number { get; set; }

}
