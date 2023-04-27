public interface IPlatform
{
    public enum Directions
    {
        right = 0,
        left = 1,
    }

    public Directions Controlling();

}
