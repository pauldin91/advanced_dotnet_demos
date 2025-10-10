namespace GenericsRegistration.Demo.Tests.Database.Entities;

public class EntityFour
{
    public short Id { get; set; }
    public string FourName { get; set; }
    public float FourNumber { get; set; }
    public EntityThree Three { get; set; }
}