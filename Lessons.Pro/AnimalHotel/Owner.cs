namespace AnimalHotel;

public class Owner(string name, string phoneNumber)
{
    public string Name { get; set; } = name;

    public string PhoneNumber { get; set; } = phoneNumber;
}