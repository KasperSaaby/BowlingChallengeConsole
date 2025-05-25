namespace BowlingChallengeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            var player1 = new Player("player-1");

            game.AddPlayer(player1, GetFrames(10));

            game.AddRoll(new Roll(2));
            game.AddRoll(new Roll(8));
        }

        static List<Frame> GetFrames(int numberOfFrames)
        {
            var frames = new List<Frame>();
            for (var i = 0; i < numberOfFrames; i++)
            {
                var frameNumber = i + 1;
                frames.Add(new(frameNumber, frameNumber == numberOfFrames));
            }

            return frames;
        }
    }
}
