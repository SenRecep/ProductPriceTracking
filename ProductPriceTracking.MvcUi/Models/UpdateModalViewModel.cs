namespace ProductPriceTracking.MvcUi.Models
{
    public class UpdateModalViewModel
    {
        public UpdateModalViewModel(string name, string submit, int id)
        {
            Name = name;
            Submit = submit;
            Id = id;
        }
        public string Name { get; set; }
        public string Submit { get; set; }
        public int Id { get; set; }
    }
}
