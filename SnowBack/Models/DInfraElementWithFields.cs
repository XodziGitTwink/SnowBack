using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SnowBack.Models
{
    public class DInfraElementWithFields : DInfraElement
    {
        [JsonProperty]
        [JsonPropertyName("Element")]
        public DInfraElement Element { get; set; }
        public List<DInfraElementsField> DInfraElementsFields { get; set; }
        public DInfraElementWithFields(DInfraElement element) {
            Element = element;
        }
        public DInfraElementWithFields() { }
    }
}
