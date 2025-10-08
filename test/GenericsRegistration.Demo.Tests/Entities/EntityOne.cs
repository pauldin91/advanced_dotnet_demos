namespace GenericsRegistration.Demo.Tests.Entities;

public class EntityOne
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Number { get; set; }

    public virtual ICollection<EntityTwo> Twos { get; set; }
}