using Logiwa.Entity.Base;

namespace Logiwa.Entity.Shop
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
