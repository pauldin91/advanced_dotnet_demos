namespace GenericsRegistration.Demo.Tests.Database.Entities;

public class EntityTwo
{
    public Guid Id { get; set; }
    public string TwoName { get; set; }
    public double TwoNumber { get; set; }
    public EntityOne One { get; set; }
}