using Reflection.Attributes;
using Reflection.Base;
using Reflection.Enum;

namespace RestApi.Extensions;

[PersonInfo(PersonType.Elf)]
public class Elf : IPerson
{
    public string Greet()
    {
        return "Ciao ma in elfico";
    }
}