using System.Text.Json.Serialization;

namespace SnowBack.Models
{
    public class ElementWithFieldsAndType
    {
        public DInfraElement? Element { get; set; }
        public List<DInfraElementsField> DInfraElementsFields { get; set; }
        public DInfraElementsType? DInfraElementsType { get; set; }
    }
}
