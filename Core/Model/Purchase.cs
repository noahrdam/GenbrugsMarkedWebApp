using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Purchase
    {
        public ObjectId Id { get; set; }

		public int PurchaseId { get; set; }

		public double TotalPrice { get; set; }

		public Advertisement Advertisement { get; set; }

		public User User { get; set; }

		public Classroom Classroom { get; set; }	
	}
}
