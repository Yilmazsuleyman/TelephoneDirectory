using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TelephoneDirectory.Models
{
    public class Contact
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Bilgi Tipi")]
        public string InformationType { get; set; }
        [BsonIgnore]
        public List<SelectListItem> InformationTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Number", Text = "Telefon Numarası" },
            new SelectListItem { Value = "Email", Text = "E-mail Adresi" },
            new SelectListItem { Value = "Location", Text = "Konum"  },
        };
        [BsonElement("Bilgi İçeriği")]
        public string InformationContent { get; set; }
    }
}
