namespace BowlingChallengeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            // 1. frame
            game.AddRoll(new Roll(1));
            game.AddRoll(new Roll(4));

            // 2. frame
            game.AddRoll(new Roll(4));
            game.AddRoll(new Roll(5));

            // 3. frame
            game.AddRoll(new Roll(6));
            game.AddRoll(new Roll(4));

            // 4. frame
            game.AddRoll(new Roll(5));
            game.AddRoll(new Roll(5));

            // 5. frame
            game.AddRoll(new Roll(10));

            // 6. frame
            game.AddRoll(new Roll(0));
            game.AddRoll(new Roll(1));

            // 7. frame
            game.AddRoll(new Roll(7));
            game.AddRoll(new Roll(3));

            // 8. frame
            game.AddRoll(new Roll(6));
            game.AddRoll(new Roll(4));

            // 9. frame
            game.AddRoll(new Roll(10));

            // 10. frame
            game.AddRoll(new Roll(2));
            game.AddRoll(new Roll(8));
            game.AddRoll(new Roll(6));

            var bonusCalculatorService = new BonusCalculatorService();
            var frameList = bonusCalculatorService.CalculateBonus(game);
            var totalScoreProgress = 0;

            foreach (var frame in frameList)
            {
                var rolls = frame.GetRolls();
                var rollCount = 0;

                totalScoreProgress += frame.GetScore();

                foreach (var roll in rolls)
                {
                    rollCount++;

                    var isLastRollInFrame = rolls.Count == rollCount;

                    if (isLastRollInFrame)
                    {
                        Console.WriteLine("{0} {1} {2} {3}", frame.FrameNumber, rollCount, roll.GetPinsDown(), totalScoreProgress);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", frame.FrameNumber, rollCount, roll.GetPinsDown());
                    }
                }
            }

            if (game.IsGameCompleted())
            {
                Console.WriteLine("Game is completed.");
            }
        }
    }
}
