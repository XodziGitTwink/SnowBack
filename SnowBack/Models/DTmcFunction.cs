using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBack.Models
{
    public class DTMCFunction
    {
        public int Id { get; set; }

        public Guid? Guid { get; set; }
        
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        public string? Code { get; set; }

        public int TypeId { get; set; }
    }
}
