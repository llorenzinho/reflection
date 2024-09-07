using Reflection.Base;

namespace App.Extension;

public class Human : IPerson
{
    public string Greet()
    {
        return "Ciao";
    }
}