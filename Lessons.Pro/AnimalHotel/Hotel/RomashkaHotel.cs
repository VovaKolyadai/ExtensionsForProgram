using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class RomashkaHotel : IEnumerable
{
    private object[] _animals = new object[4];
    private int _count = 0;
    private int _capacity = 4;
    
    public void FeedAnimals()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                iAnimal.Eat();
            }
        }
    }
    
    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                iAnimal.Sleep();
            }
        }
    }
    public void SortByAge()
    {
        var sortetedArray = new IAnimal[_count];
        for (int i = 0; i < sortetedArray.Length; i++)
            sortetedArray[i] = (IAnimal)_animals[i];
        sortetedArray = sortetedArray.OrderBy(x => x.Age).ToArray();
        for (int i = 0; i < sortetedArray.Length; i++)
            _animals[i] = sortetedArray[i];
    }
    public void SortByDescendingAge()
    {
        var sortetedArray = new IAnimal[_count];
        for (int i = 0; i < sortetedArray.Length; i++)
            sortetedArray[i] = (IAnimal)_animals[i];
        sortetedArray = sortetedArray.OrderByDescending(x => x.Age).ToArray();
        for (int i = 0; i < sortetedArray.Length; i++)
            _animals[i] = sortetedArray[i];
    }

    public void AddAnimal(object animal)
    {
        if(animal is IAnimal)
        {
            if (_count == _capacity)
            {
                _capacity *= 2;
                Array.Resize(ref _animals, _capacity);
            }

            _animals[_count++] = animal;
        }
    }
    
    public void PrintAnimals()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                Console.WriteLine(iAnimal.Name);
            }
        }
    }
    public object[] GetAllAnimalsByOwner(string ownerName)
    {
        if (ownerName == null) throw new NullReferenceException("cant search for animal with null as owner"); 
        var animalsWithOwner = new object[_count];
        int amount = 0;
        for(int i = 0; i < _count; i++)
        {
            if(_animals[i] is IAnimal iAnimal)
            {
                if(iAnimal.Owner.Name == ownerName)
                {
                    animalsWithOwner[amount++] = iAnimal;
                }
            }
        }
        var result = new object[amount];
        for (int i = 0; i < amount; i++)
            result[i] = animalsWithOwner[i];
        return result;
    }

    public object this[int index]
    {
        get => _animals[index];
        set => _animals[index] = value;
    }

    public IEnumerator GetEnumerator()
    {
        for(var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }
}