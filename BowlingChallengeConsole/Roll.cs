public class Roll
{
    private int pinsDown;

    public Roll(int pinsDown)
    {
        if (pinsDown < 0 || pinsDown > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(pinsDown), "Pins down must be between 0 and 10");
        }

        this.pinsDown = pinsDown;
    }

    public bool IsStrike()
    {
        return pinsDown == 10;
    }

    public bool IsGutter()
    {
        return pinsDown == 0;
    }

    public int GetPinsDown()
    {
        return pinsDown;
    }
}
