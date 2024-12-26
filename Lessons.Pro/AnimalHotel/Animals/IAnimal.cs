namespace AnimalHotel.Animals;

public interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
    string Color { get; set; }
    int OwnerAge { get; set; }
    
    void Eat();

    void Sleep()
    {
        Console.WriteLine($"{nameof(IAnimal)} is sleeping");   
    }
}