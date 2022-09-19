using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Visit
    {
        public Guid Id { get; set; }
        public DateTime LastVisit { get; set; }
        public DateTime NextVisit { get; set; }

    }
}