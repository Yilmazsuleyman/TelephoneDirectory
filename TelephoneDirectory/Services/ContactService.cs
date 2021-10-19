using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Services
{
    public class ContactService
    {
        private readonly IMongoCollection<Contact> _contact;

        public ContactService(ITelephoneDirectoryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _contact = database.GetCollection<Contact>(settings.ContactCollectionName);
        }

        public List<Contact> Get() =>
            _contact.Find(contact => true).ToList();

        public Contact Get(Guid id) =>
            _contact.Find<Contact>(contact => contact.Id == id).FirstOrDefault();

        public Contact Create(Contact contact)
        {
            _contact.InsertOne(contact);
            return contact;
        }

        public void Update(Guid id, Contact contactIn) =>
            _contact.ReplaceOne(contact => contact.Id == id, contactIn);

        public void Remove(Contact contactIn) =>
            _contact.DeleteOne(contact => contact.Id == contactIn.Id);

        public void Remove(Guid id) =>
            _contact.DeleteOne(contact => contact.Id == id);
    }
}
