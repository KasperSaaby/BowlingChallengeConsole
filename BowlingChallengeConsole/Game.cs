public class Game
{
    private const int NumberOfFrames = 10;
    private List<Frame> frameList;
    private int currentFrameIndex = 0;

    public Game()
    {
        frameList = new List<Frame>();
        
        for (var i = 0; i < NumberOfFrames; i++)
        {
            var frameNumber = i + 1;
            frameList.Add(new(frameNumber, frameNumber == NumberOfFrames));
        }
    }

    public void AddRoll(Roll roll)
    {
        var frame = GetCurrentFrame();
        if (frame.IsCompleted())
        {
            return;
        }

        frame.AddRoll(roll);
    }

    public Frame GetCurrentFrame()
    {
        return frameList[currentFrameIndex];
    }
}
