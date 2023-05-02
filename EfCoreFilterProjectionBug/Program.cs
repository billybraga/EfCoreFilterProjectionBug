// See https://aka.ms/new-console-template for more information

using EfCoreFilterProjectionBug;
using Microsoft.EntityFrameworkCore;

await using var db = new AppDbContext();
await db.Database.EnsureDeletedAsync();
await db.Database.MigrateAsync();

db.Parents.Add(new Parent
{
    Name = "Parent 1",
    Child = new Child
    {
        Name = "Child 1.1",
        GrandChildren = new GrandChild[]
        {
            new()
            {
                Name = "grand child 1.1.1",
            },
            new()
            {
                Name = "grand child 1.1.2",
            },
        },
    },
});

db.Parents.Add(new Parent
{
    Name = "Parent 2",
    Child = new Child
    {
        Name = "Child 2.1",
        GrandChildren = new GrandChild[]
        {
            new()
            {
                Name = "grand child 2.1.1",
            },
            new()
            {
                Name = "grand child 2.1.2",
            },
        },
    },
});

await db.SaveChangesAsync();

var queryable = db
    .Parents
    .Select(x => new ParentDto
    {
        Id = x.Id,
        Name = x.Name,
        Child =
            // Comment-out the line below to avoid bug 
            x.Child == null ? null : 
        new ChildDto
        {
            Id = x.Child.Id,
            Name = x.Child.Name,
            GrandChildren = x
                .Child
                .GrandChildren
                .Select(g => new GrandChildDto
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToList(),
        }
    })
    .Where(x => x.Child.GrandChildren.Any(g => g.Name == "grand child 2.1.1"));

var parentDtos = await queryable.ToListAsync();

foreach (var parentDto in parentDtos)
{
    Console.WriteLine(parentDto.Name);
}