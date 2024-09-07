using Reflection.Attributes;
using Reflection.Base;
using Reflection.Enum;

namespace App.Base;

[PersonInfo(PersonType.Human)]
public abstract class Person : IPerson
{
    public string Greet()
    {
        PersonType attribute = GetAttribute(GetType());
        return $"{GetType().Name} says: {attribute}!";
    }

    public static PersonType GetAttribute(Type t)
    {
        // Get instance of the attribute.
        PersonInfo attribute =
            (PersonInfo) Attribute.GetCustomAttribute(t, typeof (PersonInfo));

        if (attribute == null)
        {
            return PersonType.Human;
        }
        return attribute.PT;
    }
}