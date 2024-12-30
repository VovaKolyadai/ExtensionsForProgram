// create abstract factory to create animals

using AnimalHotel;
using AnimalHotel.Animals;
using AnimalHotel.Hotel;

var animalNames = new string[] { "Dog", "Cat", "Parrot", "Horse" };
var ownerNames = new string[] { "John", "Jane", "Jack", "Jill" };
var ownerPhoneNumbers = new string[] { "1234567890", "0987654321", "6789054321", "1234509876" };

var list = new List<int>();

IAnimalFactory animalFactory = new AnimalFactory();
var random = new Random();
var cats = new GenericHotel<Cat>();
var genericHotel = new GenericHotel<IAnimal>();
var kyivHotel = new KyivHotel();
var romashkaHotel = new RomashkaHotel();

for (int i = 0; i < 10; i++)
{
    var animalName = animalNames[random.Next(animalNames.Length)];
    var ownerName = ownerNames[random.Next(ownerNames.Length)];
    var ownerPhoneNumber = ownerPhoneNumbers[random.Next(ownerPhoneNumbers.Length)];
    var animalType = random.Next(2);

    var owner = new Owner(ownerName, ownerPhoneNumber);
    IAnimal animal = animalType switch
    {
        0 => animalFactory.CreateDog(animalName, i, "blick", owner, i),
        1 => animalFactory.CreateCat(animalName, i, "blick", owner, i),
        _ => throw new ArgumentException("Invalid animal type"),
    };

    /*IAnimal oldSchool = default;
    
    switch (animalType)
    {
        case 0:
            break;
        case 1:
            oldSchool = animalFactory.CreateCat(animalName, owner);
            break;
        default:
            throw new ArgumentException("Invalid animal type");
            break;
    }*/
    
    genericHotel.AddAnimal(animal);
    //genericHotel.AddAnimal(oldSchool);
    kyivHotel.AddAnimal(animal);
    //kyivHotel.AddAnimal(oldSchool);
    romashkaHotel.AddAnimal(animal);
    //romashkaHotel.AddAnimal(oldSchool);
}

foreach (var animal in genericHotel)
{
    Console.WriteLine(animal.Name);
    animal.Eat();
}

foreach (var animal in kyivHotel)
{
    Console.WriteLine(animal.Name);
    animal.Sleep();
}

foreach (var animal in romashkaHotel)
{
    if (animal != null && animal is IAnimal)
        Console.WriteLine(((IAnimal)animal).Name);
}

// TODO: get all animals with name 'Parrot' from genericHotel
var genericHotelParrots = genericHotel.Where(x => x.Name == "Parrot");

// TODO: get all animals with name 'Parrot' from kyivHotel
var kyivHotelParrots = kyivHotel.Where(x => x.Name == "Parrot");

// TODO: get all animals with name 'Parrot' from romashkaHotel
var romashkaHotelParrots = new RomashkaHotel();
foreach (var animal in romashkaHotel)
{
    if(animal is  IAnimal iAnimal)
    {
        if (iAnimal.Name == "Parrot")
            romashkaHotelParrots.AddAnimal(animal);
    }
}

// TODO: extend animals entity to have a property 'Age' and sort animals by age
genericHotel.SortByAge();
Console.WriteLine("@@@@@@@@@@@@@@@@@@");
genericHotel.ToList().ForEach(x => Console.WriteLine(x.Age));

genericHotel.SortByDescendingAge();
Console.WriteLine("@@@@@@@@@@@@@@@@@@");
genericHotel.ToList().ForEach(x => Console.WriteLine(x.Age));

genericHotel.SortByAge();
Console.WriteLine("@@@@@@@@@@@@@@@@@@");
genericHotel.ToList().ForEach(x => Console.WriteLine(x.Age));

//------------------------------
kyivHotel.SortByAge();
Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@");
kyivHotel.ToList().ForEach(x => Console.WriteLine(x.Age));

kyivHotel.SortByDescendingAge();
Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@");
kyivHotel.ToList().ForEach(x => Console.WriteLine(x.Age));

//----------------------------------
romashkaHotel.SortByAge();
Console.WriteLine("@@@@");
foreach (var animal in romashkaHotel)
{
    if(animal is IAnimal iAnimal)
        Console.WriteLine(iAnimal.Age);
}

romashkaHotel.SortByDescendingAge();
Console.WriteLine("@@@@");
foreach(var animal in romashkaHotel)
{
    if(animal is IAnimal iAnimal)
        Console.WriteLine(iAnimal.Age);
}

Console.WriteLine("----------------------");

genericHotel.GetAllAnimalsByOwner(ownerNames[0]).ToList().ForEach(x => Console.WriteLine(x.Name));
Console.WriteLine("----------------------");
kyivHotel.GetAllAnimalsByOwner(ownerNames[random.Next(ownerNames.Length)]).ToList().ForEach(x => Console.WriteLine(x.Name));
Console.WriteLine("----------------------");
var romashkaOwners = romashkaHotel.GetAllAnimalsByOwner(ownerNames[random.Next(ownerNames.Length)]);
foreach(var animal in romashkaOwners)
{
    if(animal is IAnimal iAnimal)
        Console.WriteLine(iAnimal.Name);
}