namespace AnimalHotel.Animals;

// https://refactoring.guru/design-patterns/abstract-factory
public class AnimalFactory : IAnimalFactory
{
    public Dog CreateDog(string name, int age, string color, Owner owner, int ownerAge)
    {
        // business rules
        return Dog.CreateDog(name, age, color, owner, ownerAge);
    }
    
    public Cat CreateCat(string name, int age, string color, Owner owner, int ownerAge)
    {
        // business rules
        return Cat.CreateCat(name, age, color, owner, ownerAge);
    }
}

public interface IAnimalFactory
{
    Dog CreateDog(string name, int age, string color, Owner owner, int ownerAge);
    
    Cat CreateCat(string name, int age, string color, Owner owner, int ownerAge);
}