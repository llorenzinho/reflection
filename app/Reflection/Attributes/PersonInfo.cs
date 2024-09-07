using Reflection.Enum;

namespace Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class PersonInfo(PersonType pt) : Attribute
    {
        public PersonType PT = pt;
    }
}