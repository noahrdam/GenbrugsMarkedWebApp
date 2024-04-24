using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Core.Model
{
    public class Advertisement
    {
        public ObjectId Id {  get; set; }

        public int AdvertisementId {  get; set; }

		public string Name { get; set; }

		public double Price { get; set; }

		public string Category { get; set; }

		public string Description { get; set; }

		public string Status { get; set; }

		public string Image { get; set; }


		public User User { get; set; }

		//public Classroom Classroom { get; set; }
	}
}
