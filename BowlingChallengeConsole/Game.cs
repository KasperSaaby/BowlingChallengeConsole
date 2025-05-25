public class Game
{
    private const int NumberOfFrames = 10;
    private List<Frame> frameList;
    private int currentFrameIndex = 0;
    private bool isGameCompleted = false;

    public Game()
    {
        frameList = new List<Frame>();

        InitializeFrames();
    }

    private void InitializeFrames()
    {
        for (var frameNumber = 1; frameNumber <= NumberOfFrames; frameNumber++)
        {
            frameList.Add(new(frameNumber, frameNumber == NumberOfFrames));
        }
    }

    public void AddRoll(Roll roll)
    {
        if (IsGameCompleted())
        {
            return;
        }

        var frame = GetCurrentFrame();
        if (frame.IsCompleted())
        {
            return;
        }

        frame.AddRoll(roll);

        AdvanceGame();
    }

    private void AdvanceGame()
    {
        var currentFrame = GetCurrentFrame();

        // Only advance if the current frame is complete (and not the 10th frame potentially allowing more rolls)
        if (currentFrame.IsCompleted())
        {
            if (currentFrame.IsLastFrame())
            {
                isGameCompleted = true;
            }
            else
            {
                currentFrameIndex++;
            }
        }
    }

    public List<Frame> GetFrames()
    {
        return frameList;
    }

    public Frame GetCurrentFrame()
    {
        return frameList[currentFrameIndex];
    }

    public bool IsGameCompleted()
    {
        return isGameCompleted;
    }
}
