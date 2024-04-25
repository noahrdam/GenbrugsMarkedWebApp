using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Model
{
    public class Advertisement
    {
        public Advertisement()
        {
            
            Date = DateTime.UtcNow;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id {  get; set; }

        public int AdvertisementId {  get; set; }

		public string Name { get; set; }

		public double Price { get; set; }

		public string? Category { get; set; }

		public string? Description { get; set; }

		public string? Status { get; set; }

		public string? Image { get; set; }

		public bool? IsAtEAA { get; set; }

		public User User { get; set; }

		public string? Classroom { get; set; }

		public DateTime Date { get; set; }
	}
}
