﻿using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPriceTracking.Entities.Concrete
{
    public class Product:EntityBase,IProduct
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int WebsiteId { get; set; }
        public Website Website { get; set; }
        public IEnumerable<TrackingRecord> TrackingRecords { get; set; }
    }
}