using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class AdvertisementStats
    {
        public int TotalAds { get; set; }
        public int ActiveAds { get; set; }
        public int SoldAds { get; set; }
    }
}

