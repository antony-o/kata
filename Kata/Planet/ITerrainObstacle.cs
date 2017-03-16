namespace Kata.Planet
{
    public interface ITerrainObstacle
    {
        string Description { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}