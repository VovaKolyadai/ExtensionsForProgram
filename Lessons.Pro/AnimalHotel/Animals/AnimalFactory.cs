namespace AnimalHotel.Animals;

// https://refactoring.guru/design-patterns/abstract-factory
public class AnimalFactory : IAnimalFactory
{
    public Dog CreateDog(string name, Owner owner)
    {
        // business rules
        return Dog.CreateDog(name, owner);
    }
    
    public Cat CreateCat(string name, Owner owner)
    {
        // business rules
        return Cat.CreateCat(name, owner);
    }
}

public interface IAnimalFactory
{
    Dog CreateDog(string name, Owner owner);
    
    Cat CreateCat(string name, Owner owner);
}