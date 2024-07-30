namespace EngineMasters_BackEnd.Data.Models;

public abstract class BaseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
