using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface ITrackingService
    {
        Task<dynamic> GetTrackingValuesByUserId(int userId);

    }
}
