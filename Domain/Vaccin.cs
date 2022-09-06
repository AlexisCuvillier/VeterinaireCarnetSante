using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Vaccin
    {
        public Guid Id { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime NextDate { get; set; }

    }
}