namespace GenericsRegistration.Demo.Tests.Database.Entities;

public class EntityThree
{
    public long Id { get; set; }
    public string ThreeName { get; set; }
    public decimal ThreeNumber { get; set; }

    public ICollection<EntityFour> Fours { get; set; }
}