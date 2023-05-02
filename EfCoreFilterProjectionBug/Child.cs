namespace EfCoreFilterProjectionBug;

public class Child
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IReadOnlyCollection<GrandChild> GrandChildren { get; set; }
}