using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ProductPriceTracking.Bll.Interfaces;

namespace ProductPriceTracking.Bll.Concrete
{
    public class TrackingManager : ITrackingService
    {
        private readonly IWebsiteService websiteService;

        public TrackingManager(IWebsiteService websiteService)
        {
            this.websiteService = websiteService;
        }
        // Kullaniciya ait websiteleri 
        // kullanicinin sistelerinin urunleri 
        // kullanicini websitelerinin konum bilgileri
        // urunlerinin takipcileri 
        // takipcilerin websitelerinin konum bilgileri
        public Task<dynamic> GetTrackingValuesByUserId(int userId)
        {
            var websites = websiteService.GetWebsitesByUserId(userId);
            return null;
        }
    }
}
