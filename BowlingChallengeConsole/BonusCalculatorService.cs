public class BonusCalculatorService
{
    public BonusCalculatorService() { }

    public List<Frame> CalculateBonus(Game game)
    {
        var frames = game.GetFrames();
        var i = 0;

        foreach (var currentFrame in frames)
        {
            Frame nextFrame = null;

            i++;

            if (i < frames.Count)
            {
                nextFrame = frames[i];
            }
            else
            {
                break;
            }

            if (currentFrame.IsStrike())
            {
                currentFrame.ApplyBonus(nextFrame.GetRolls().Take(2).Sum(x => x.GetPinsDown()));
            }

            if (currentFrame.IsSpare())
            {
                currentFrame.ApplyBonus(nextFrame.GetRolls().Take(1).Sum(x => x.GetPinsDown()));
            }
        }

        return frames;
    }
}
