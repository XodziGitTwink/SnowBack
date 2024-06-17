using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnowBack.Models
{
    public class DTMCModel : DTMC
    {
        public string FullInfo => $"{Name} ({Id})";

        //public string? StockName { get; set; }

        //public string? RoomName { get; set; }

        //public string? RackName { get; set; }

        //public string? ShelfName { get; set; }
    }
}
