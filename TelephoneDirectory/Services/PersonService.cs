using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _people;

        public PersonService(ITelephoneDirectoryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _people = database.GetCollection<Person>(settings.PersonCollectionName);
        }

        public List<Person> Get() =>
            _people.Find(person => true).ToList();

        public Person Get(Guid id) =>
            _people.Find<Person>(person => person.Id == id).FirstOrDefault();

        public Person Create(Person person)
        {
            _people.InsertOne(person);
            return person;
        }

        public void Update(Guid id, Person personIn) =>
            _people.ReplaceOne(person => person.Id == id, personIn);

        public void Remove(Person personIn) =>
            _people.DeleteOne(person => person.Id == personIn.Id);

        public void Remove(Guid id) =>
            _people.DeleteOne(person => person.Id == id);
    }
}
