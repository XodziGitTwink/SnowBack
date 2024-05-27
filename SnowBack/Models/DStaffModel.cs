using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBack.Models
{
    public partial class DStaffModel : DStaff
    {
        public string FullInfo => $"{Name} {Surename} {Lastname} ({Id})";
    }
}
