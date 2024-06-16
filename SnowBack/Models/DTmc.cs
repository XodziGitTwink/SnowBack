using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBack.Models
{
    public class DTMC
    {
        public int Id { get; set; }

        public Guid? Guid { get; set; }
        
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        public string? Code { get; set; }

        public string? Inventorycode { get; set; }

        public int TypeId { get; set; }

        public int FunctId { get; set; }

        public int ShelfId { get; set; }

        public int? UserId { get; set; }
        
        public int? TaskId { get; set; }

        public bool IsRederved { get; set; } = false;

        public bool IsUsed { get; set; } = false;
    }
}
