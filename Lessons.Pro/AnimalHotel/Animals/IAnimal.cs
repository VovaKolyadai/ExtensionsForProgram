namespace AnimalHotel.Animals;

public interface IAnimal
{
    string Name { get; set; }
    
    void Eat();

    void Sleep()
    {
        Console.WriteLine($"{nameof(IAnimal)} is sleeping");   
    }
}