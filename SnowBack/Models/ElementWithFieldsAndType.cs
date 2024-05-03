namespace SnowBack.Models
{
    public class ElementWithFieldsAndType
    {
        public DInfraElement Element { get; set; }
        public List<DInfraElementsField> dInfraElementsFields { get; set; }
        public DInfraElementsType DInfraElementsType { get; set; }
    }
}
