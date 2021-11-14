using System;
using System.ComponentModel.DataAnnotations;
using Logiwa.Core.Types;

namespace Logiwa.Entity.Base
{
    public class AuditableEntity : BaseEntity
    {
        public AuditableEntity()
        {
            InsertedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }

        [Required]
        public int InsertedUserId { get; set; }
        [Required]
        public string InsertedUser { get; set; }
        [Required]
        public DateTime InsertedDate { get; set; }

        public int? UpdatedUserId { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
