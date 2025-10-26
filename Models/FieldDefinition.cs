namespace Randomly.Models;

public class FieldDefinition
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = "firstName";
    public Guid Id { get; set; } = Guid.NewGuid();
}
