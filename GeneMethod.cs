// See https://aka.ms/new-console-template for more information



using System.Text.Json;

var a = (IEnumerable<object>)typeof(Helper).GetMethod("GetSth").MakeGenericMethod(typeof(Animal)).Invoke(null, new object[] { });

foreach (var item in a)
{
    Console.WriteLine(JsonSerializer.Serialize(item));
}
static class Helper
{
    static IEnumerable<object> _products = new List<Product> { new (1), new (2), new (3) };
    static IEnumerable<object> _animals = new List<Animal> { new (4), new (5), new (6) };

    public static IEnumerable<object> GetSth<T>()
    {
        if (typeof(T) == typeof(Product))
        {
            return _products;
        }
        else if (typeof(T) == typeof(Animal))
        {
            return _animals;

        }
        return null;

    }
}

class Product
{
    public int Id { get; set; }
    public string Name => $"Product: {Id}";
    public Product(int id)
    {
        Id = id;
    }
}



class Animal
{
    public int Id { get; set; }
    public string Name => $"Animal: {Id}";
    public Animal(int id)
    {
        Id = id;
    }
}
