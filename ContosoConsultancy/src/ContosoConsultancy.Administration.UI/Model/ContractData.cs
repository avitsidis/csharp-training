namespace ContosoConsultancy.Administration.UI.Model
{
    public class ContractData
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Customer { get; set; }
        public string Rate { get; set; }
        public string ConsultantName { get; internal set; }
    }
}
