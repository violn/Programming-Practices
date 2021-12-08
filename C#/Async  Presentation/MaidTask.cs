namespace AsyncPresentation;

public class MaidTask
{
    public string Task { get; set; }
    public int Time { get; set; }

    public MaidTask(string task, int time)
    {
        Task = task;
        Time = time;
    }
}
