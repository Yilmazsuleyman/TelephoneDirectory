using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TelephoneDirectory.Models
{
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("Rapor Talep Tarihi")]
        public DateTime RequestTime { get; set; }
        
        [BsonElement("Rapor Durumu")]
        public string Statu { get; set; }
        [BsonIgnore]
        public List<SelectListItem> Status { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Preparing", Text = "Hazırlanıyor" },
            new SelectListItem { Value = "Completed", Text = "Tamamlandı" }
        };
    }
}
