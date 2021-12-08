namespace AsyncPresentation;

public class Maid
{
    public string Name { get; set; }

    public MaidTask Task { get; set; }

    public Maid(string name, MaidTask task)
    {
        Name = name;
        Task = task;
    }

    public override string ToString()
    {
        return $"{Name} finished {Task.Task.ToLower()} in {Task.Time / 1000f:0.00} seconds";
    }
}
