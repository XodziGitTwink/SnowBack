using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SnowBack.Models
{
    public class DInfraElementWithFields
    {
        public DInfraElement Element { get; set; }
        public List<DInfraElementsField> DInfraElementsFields { get; set; }
    }
}
