namespace SnowBack.Models
{
    public class DInfraElementWithFields : DInfraElement
    {
        public DInfraElement Element { get; set; }
        public List<DInfraElementsField> DInfraElementsFields { get; set; }
        public DInfraElementWithFields(DInfraElement element) {
            Element = element;
        }
        public DInfraElementWithFields() { }
    }
}
