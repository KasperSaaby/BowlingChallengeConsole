public class BonusCalculatorService
{
    public BonusCalculatorService() { }

    public void CalculateBonus(Game game)
    {
        var frames = game.GetFrames();

        for (var i = 0; i < frames.Count; i++)
        {
            if (i == frames.Count - 1)
            {
                return;
            }

            var currentFrame = frames[i];
            var nextFrame = frames[i+1];

            if (currentFrame.IsStrike())
            {
                currentFrame.ApplyBonus(nextFrame.GetRolls().Take(2).Sum(x => x.GetPinsDown()));
            }
            else if (currentFrame.IsSpare())
            {
                currentFrame.ApplyBonus(nextFrame.GetRolls().Take(1).Sum(x => x.GetPinsDown()));
            }
        }
    }
}
