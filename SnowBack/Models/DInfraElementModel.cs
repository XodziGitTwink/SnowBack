using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnowBack.Models
{
    public partial class DInfraElementModel : DInfraElement
    {
        public string FullInfo => $"{Name} {Code} {Type} ({Id})";
    }
}
