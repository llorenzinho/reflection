using App.Base;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Reflection.Base;
using Reflection.Enum;
using Reflection.PersonServices;
using Reflection.Reflect;

namespace App.Controllers;

[Controller]
public class PersonsController(IPersonService personService): ControllerBase
{
    private readonly IPersonService _personService = personService;
    [HttpGet, Route("api/persons")]
    public IActionResult Get() {
        var persons = ReflectiveEnumerator.GetEnumerableOfType<IPerson>();
        Dictionary<string, Dictionary<PersonType, string>> messages = [];
        foreach (var person in persons) {
            var attribute = Person.GetAttribute(person.GetType());
            var m = new Dictionary<PersonType, string>
            {
                { attribute, person.Greet() }
            };
            messages.Add(person.GetType().Name, m);
        }
        // var messages = persons.Select(x => x.Greet());
        return Ok(messages);
    }

    [HttpGet, Route("api/persons/{type}")]
    public IActionResult Enqueue(string type) {
        var result = _personService
            .Enqueue((PersonType)Enum.Parse(typeof(PersonType), type));
        return Ok(result);
    }
}