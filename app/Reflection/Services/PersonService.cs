using App.Base;
using Hangfire;
using Microsoft.Extensions.Logging;
using Reflection.Base;
using Reflection.Enum;
using Reflection.Reflect;

namespace Reflection.PersonServices;

public interface IPersonService
{
    public List<string> Enqueue(PersonType type);
}
public class PersonService(ILogger<PersonService> logger) : IPersonService
{
    private readonly ILogger<PersonService> _logger = logger;
    private static Dictionary<PersonType, List<IPerson>> Persons { get; set; } = [];

    public static void Reflect()
    {
        var persons = ReflectiveEnumerator.GetEnumerableOfType<IPerson>();
        var attrPers = persons.Select(x => (Person.GetAttribute(x.GetType()), x));
        Dictionary<PersonType, List<IPerson>> final = [];
        foreach (var (attribute, person) in attrPers)
        {
            if (!final.TryGetValue(attribute, out List<IPerson>? value))
            {
                final.Add(attribute, []);
            }

            final[attribute].Add(person);
        }

        Persons = final;
    }

    public List<string> Enqueue(PersonType type)
    {
        var p = Persons[type];
        foreach (var person in p) {
            string toPrint = $"{person.GetType().Name} with attribute {type} says: {person.Greet()}";
            BackgroundJob.Enqueue(() => Console.WriteLine(toPrint));
        };
        return p.Select(x => x.Greet()).ToList();
    }
}