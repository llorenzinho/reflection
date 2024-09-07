using Reflection.Attributes;
using Reflection.Base;
using Reflection.Enum;

namespace RestApi.Extensions;

[PersonInfo(PersonType.Elf)]
public class Orc : IPerson
{
    public string Greet()
    {
        return "CARNE, VOGLIAMO CARNEEEE!";
    }
}