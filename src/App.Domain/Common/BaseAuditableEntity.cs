using App.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity,IAuditableEntity
    {
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
    }
}
