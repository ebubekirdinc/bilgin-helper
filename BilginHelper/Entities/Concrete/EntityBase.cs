using BilginHelper.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilginHelper.Entities.Concrete
{
    public class EntityBase
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public StatusType Status { get; set; }
    }
}
