namespace AnimalHotel.Animals;

public class Cat : IAnimal, IComparable<Cat>
{
    private Cat(string name, Owner owner)
    {
        Name = name;
        Owner = owner;
    }
    public string Name { get; set; }
    
    public Owner Owner { get; private set; }
    
    public void Meow()
    {
        Console.WriteLine($"{nameof(Cat)} is meowing");
    }
    
    public void Eat()
    {
        Console.WriteLine($"{nameof(Cat)} is eating");
    }

    public void Sleep()
    {
        Console.WriteLine($"{nameof(Cat)} is sleeping");
    }
    
    public static Cat CreateCat(string name, Owner owner)
    {
        return new Cat(name, owner);
    }
    
    // https://refactoring.guru/design-patterns/factory-method
    public int CompareTo(Cat? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}