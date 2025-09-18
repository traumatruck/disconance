namespace Disconance.Models.Polls;

public class Poll
{
    public string Question { get; set; } = null!;
    public List<PollAnswer> Answers { get; set; } = [];
    public bool? AllowMultiselect { get; set; }
}
