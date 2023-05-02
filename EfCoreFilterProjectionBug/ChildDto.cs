namespace EfCoreFilterProjectionBug;

public class ChildDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IReadOnlyCollection<GrandChildDto> GrandChildren { get; set; }
}