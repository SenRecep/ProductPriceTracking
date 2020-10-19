using ProductPriceTracking.Core.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPriceTracking.Dto.PricePositionDtos
{
    public class PricePositionDto:IDto
    {
        public string XPath { get; set; }
        public int Priority { get; set; }
        public int WebsiteId { get; set; }
    }
}
