using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TelephoneDirectory.Models
{
    public class Person
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Ad")]
        public string Name { get; set; }

        [BsonElement("Soyad")]
        public string Surname { get; set; }

        [BsonElement("Firma")]
        public string Company { get; set; }

        public IList<Contact> Contacts { get; set; }

        [BsonIgnore]
        public IList<Contact> ContactList { get; set; }
    }
}
