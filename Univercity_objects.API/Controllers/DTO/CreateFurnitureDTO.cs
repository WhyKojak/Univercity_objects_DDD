namespace Univercity_objects.API.Controllers.DTO
{
    public class CreateFurnitureDTO
    {
        public Guid AuditoryGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string inv_number { get; set; }
    }
}
