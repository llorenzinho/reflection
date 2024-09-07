using System.Reflection;

namespace Reflection.Reflect;

public static class ReflectiveEnumerator
{
    static ReflectiveEnumerator() { }

    public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
    {
        List<T> objects = [];
        foreach (var type in Assembly.GetEntryAssembly().GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.GetInterfaces().Contains(typeof(T))))
        {
            objects.Add((T)Activator.CreateInstance(type, constructorArgs));
        }

        return objects;
    }

    public static List<T> GetImplementations<T>(params object[] constructorArgs)
    {
        List<T> objects = new List<T>();
        foreach (Type type in Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(mytype => mytype.GetInterfaces().Contains(typeof(T))))
        {
            objects.Add((T)Activator.CreateInstance(type, constructorArgs));
        }
        return objects;
    }
}