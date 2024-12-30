namespace AnimalHotel.Animals;

public class Dog : IAnimal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }
    public int OwnerAge { get; set; }
    
    public Owner Owner { get; private set; }
    
    private Dog(string name, int age, string color, Owner owner, int ownerAge)
    {
        Name = name;
        Age = age;
        Color = color;
        Owner = owner;
        OwnerAge = ownerAge;
    }
    
    public void Bark()
    {
        Console.WriteLine($"{nameof(Dog)} is barking");
    }

    public void Eat()
    {
        Console.WriteLine($"{nameof(Dog)} is eating");
    }
    
    
    // https://refactoring.guru/design-patterns/factory-method
    public static Dog CreateDog(string name, int age, string color, Owner owner, int ownerAge)
    {
        return new Dog(name, age, color, owner, ownerAge);
    }
}