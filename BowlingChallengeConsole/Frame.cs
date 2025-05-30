public class Frame
{
    private List<Roll> rollList;
    private bool isLastFrame;
    private const int MaxPinsInFrame = 10;
    private int bonus = 0;

    public int FrameNumber { get; }

    public Frame(int frameNumber, bool isLastFrame = false)
    {
        if (frameNumber < 1 || frameNumber > MaxPinsInFrame)
        {
            throw new ArgumentOutOfRangeException(nameof(frameNumber), "Frame number must be between 1 and 10");
        }

        this.rollList = new List<Roll>();
        this.isLastFrame = isLastFrame;

        this.FrameNumber = frameNumber;
    }

    public void AddRoll(Roll roll)
    {
        if (IsCompleted())
        {
            // Consider throwing exception
            // throw new InvalidOperationException();
            return;
        }

        rollList.Add(roll);
    }

    public bool IsStrike()
    {
        return !isLastFrame && rollList.Count > 0 && rollList[0].IsStrike();
    }

    public bool IsSpare()
    {
        return rollList.Count >= 2 &&
               !rollList[0].IsStrike() &&
               (rollList[0].GetPinsDown() + rollList[1].GetPinsDown() == MaxPinsInFrame);
    }

    public bool IsCompleted()
    {
        // Frame is not completed if no rolls have been made
        if (rollList.Count == 0)
        {
            return false;
        }

        if (!isLastFrame)
        {
            // A strike on the first roll, the frame is complete
            if (rollList.Count == 1 && rollList[0].IsStrike())
            {
                return true;
            }

            // If two rolls have been made, the frame is complete since this is not the last frame
            if (rollList.Count == 2)
            {
                return true;
            }

            // Otherwise, not complete
            return false;
        }

        // Frame is not complete if less than two rolls have been made
        if (rollList.Count < 2)
        {
            return false;
        }

        // Check if a bonus roll is earned (strike on first, or spare on second)
        bool firstRollIsStrike = rollList[0].IsStrike();
        bool isSpare = !firstRollIsStrike && rollList.Take(2).Sum(x => x.GetPinsDown()) == MaxPinsInFrame;

        // If bonus is earned, and 3 rolls have not been made, then frame is not complete
        if ((firstRollIsStrike || isSpare) && rollList.Count < 3)
        {
            return false;
        }

        return true;
    }

    public bool IsLastFrame()
    {
        return isLastFrame;
    }

    public List<Roll> GetRolls()
    {
        return rollList;
    }

    public int GetPinsDownInFrame()
    {
        return rollList.Sum(r => r.GetPinsDown());
    }

    public int GetScore()
    {
        return GetPinsDownInFrame() + bonus;
    }

    public void ApplyBonus(int bonus)
    {
        this.bonus = bonus;
    }
}
