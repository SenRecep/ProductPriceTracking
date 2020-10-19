namespace ProductPriceTracking.MvcUi.Models
{
    public class ModalViewModel
    {
        public ModalViewModel(string name,string submit)
        {
            Name = name;
            Submit = submit;
        }
        public string Name { get; set; }
        public string Submit { get; set; }
    }
}
