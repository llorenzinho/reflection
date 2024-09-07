using Reflection.Base;

namespace RestApi.Extensions;

public class Hobbit: IPerson
{
    public string Greet()
    {
        return "Fuma con me";
    }
}