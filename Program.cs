using cat.itb.M6UF2EA3.connections;
using cat.itb.M6UF2EA3.model;

namespace cat.itb.M6UF2EA3;

public class Driver
{
    public static void Main()
    {
        Console.WriteLine(SessionFactoryCloudzt.Open<Departamento>().Get<Departamento>(1));
    }
}