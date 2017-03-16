namespace Kata.Planet
{
    public interface ITerrainFeature
    {
        string Description { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}