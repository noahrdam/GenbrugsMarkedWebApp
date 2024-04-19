using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Classroom
    {
        public ObjectId Id { get; set; }

		public string ClassroomId { get; set; }

		public string OpenHours { get; set; }
	}
}
