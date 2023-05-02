namespace EfCoreFilterProjectionBug;

public class ParentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ChildDto? Child { get; set; }
}