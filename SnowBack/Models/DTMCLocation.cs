using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBack.Models
{
    public class DTMCLocation
    {
        public int TMCId { get; set; }
        
        public string? StockName { get; set; }

        public string? RoomName { get; set; }
        
        public string? RackName { get; set; }

        public string? ShelfName { get; set; }

    }
}
