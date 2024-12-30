using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;


public class GenericHotel<TData> : IEnumerable<TData> where TData : IAnimal
{
    private int _count = 0;
    private int _capacity = 4;
    private TData[] _animals = new TData[4];
    public void FeedAnimals()
    {
        foreach (var animal in _animals)
        {
            animal.Eat();
        }
    }
    
    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals)
        {
            animal.Sleep();
        }
    }
    public void SortByAge()
    {
        var sortetedArray = new TData[_count];
        for (int i = 0; i < sortetedArray.Length; i++)
            sortetedArray[i] = _animals[i];
        sortetedArray = sortetedArray.OrderBy(x => x.Age).ToArray();
        for (int i = 0;i < sortetedArray.Length;i++)
            _animals[i] = sortetedArray[i];
    }
    public void SortByDescendingAge()
    {
        var sortetedArray = new TData[_count];
        for (int i = 0; i < sortetedArray.Length; i++)
            sortetedArray[i] = _animals[i];
        sortetedArray = sortetedArray.OrderByDescending(x => x.Age).ToArray();
        for (int i = 0; i < sortetedArray.Length; i++)
            _animals[i] = sortetedArray[i];
    }
    
    public void AddAnimal(TData animal)
    {
        if (_count == _capacity)
        {
            _capacity *= 2;
            Array.Resize(ref _animals, _capacity);
        }
        
        _animals[_count++] = animal;
    }
    
    public void PrintAnimals()
    {
        foreach (var animal in _animals)
        {
            Console.WriteLine(animal.Name);
        }
    }
    public TData[] GetAllAnimalsByOwner(string ownerName)
    {
        if (ownerName == null) throw new NullReferenceException("cant search for animal with null as owner");
        var animalsWithOwner = new TData[_count];
        int amount = 0;
        for (int i = 0; i < _count; i++)
        {
            
                if (_animals[i].Owner.Name == ownerName)
                {
                    animalsWithOwner[amount++] = _animals[i];
                }
        }
        var result = new TData[amount];
        for (int i = 0; i < amount; i++)
            result[i] = animalsWithOwner[i];
        return result;
    }

    public TData this[int index]
    {
        get => _animals[index];
        set => _animals[index] = value;
    }

    public IEnumerator<TData> GetEnumerator()
    {
        for (var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}