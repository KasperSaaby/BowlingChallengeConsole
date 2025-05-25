public class Game
{
    private const int NumberOfFrames = 10;
    private List<Frame> frameList;
    private int currentPlayerStatsIndex = 0;
    private bool isStarted = false;

    public Game()
    {
        frameList = new List<Frame>();
        for (var i = 0; i < NumberOfFrames; i++)
        {
            var frameNumber = i + 1;
            frameList.Add(new(frameNumber, frameNumber == NumberOfFrames));
        }
    }

    public void AdvanceTurn()
    {
        var playerStats = GetCurrentPlayerStats();

        // Only advance turn if the current player's current frame is completed
        if (!playerStats.IsFrameCompleted())
        {
            return;
        }

        if (currentPlayerStatsIndex < playerStatsList.Count - 1)
        {
            currentPlayerStatsIndex++;
        }
        else
        {
            currentPlayerStatsIndex = 0;
        }
    }

    public void AddRoll(Roll roll)
    {
        var playerStats = GetCurrentPlayerStats();
        if (playerStats.IsFrameCompleted())
        {
            return;
        }

        playerStats.AddRoll(roll);
    }

    private PlayerStats GetCurrentPlayerStats()
    {
        return playerStatsList[currentPlayerStatsIndex];
    }
}
