namespace BowlingChallengeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.AddRoll(new Roll(2));
            game.AddRoll(new Roll(8));
        }
    }
}
