namespace EfCoreFilterProjectionBug;

public class Parent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Child? Child { get; set; }
}