public class PlayerStats
{
    private List<Frame> frameList;
    private Player player;
    private int currentFrameIndex;

    public PlayerStats(Player player, List<Frame> frameList)
    {
        this.player = player;
        this.frameList = frameList;
        this.currentFrameIndex = 0;
    }

    public void AddRoll(Roll roll)
    {
        var frame = GetCurrentFrame();
        if (frame.IsCompleted())
        {
            return;
        }

        frame.AddRoll(roll);

        if (frame.IsCompleted() && currentFrameIndex < frameList.Count - 1)
        {
            currentFrameIndex++;
        }
    }

    public bool IsFrameCompleted()
    {
        return GetCurrentFrame().IsCompleted();
    }

    private Frame GetCurrentFrame()
    {
        return frameList[currentFrameIndex];
    }
}