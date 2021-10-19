using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDirectory.Models;
using TelephoneDirectory.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelephoneDirectory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly ContactService _contactService;
        public DirectoryController(PersonService pService, ContactService cService)
        {
            _personService = pService;
            _contactService = cService;
        }
        // GET: api/<DirectoryController>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var people = _personService.Get();
            return Ok(people);
        }

        // GET api/<DirectoryController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(Guid id)
        {
            var people = _personService.Get(id);
            if (people == null)
            {
                return NotFound();
            }
            if (people.Contacts.Count > 0)
            {
                var tempList = new List<Contact>();
                foreach (var contactId in people.Contacts)
                {
                    var contact =  _contactService.Get(contactId.Id);
                    if (contact != null)
                        tempList.Add(contact);
                }
                people.ContactList = tempList;
            }
            return Ok(people);
        }
        // POST api/<DirectoryController>
        [HttpPost]
        public ActionResult<Person> Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _personService.Create(person);

            return CreatedAtRoute("GetBook", new { id = Guid.NewGuid() }, person);
        }
        // PUT api/<DirectoryController>/5
        
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Person personIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var person = _personService.Get(id);
            if (person == null)
            {
                return NotFound();
            }
            _personService.Update(id, personIn);
            return NoContent();
        }

        // DELETE api/<DirectoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var person = _personService.Get(id);

            if (person == null)
            {
                return NotFound();
            }

            _personService.Remove(person.Id);

            return NoContent();
        }
    }
}
