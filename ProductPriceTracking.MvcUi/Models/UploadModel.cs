using ProductPriceTracking.MvcUi.Enums;

namespace ProductPriceTracking.MvcUi.Models
{
    public class UploadModel
    {
        public string NewName { get; set; }
        public string ErrorMessage { get; set; }
        public UploadState UploadState { get; set; }
    }
}
