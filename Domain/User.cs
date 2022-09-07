using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; } 

    }
}