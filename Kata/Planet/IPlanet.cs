using System;
using System.Collections.Generic;

namespace Kata.Planet
{
    public interface IPlanet
    {
        int MaxX { get; set; }
        int MaxY { get; set; }
        IEnumerable<ITerrainFeature> TerrainFeatures { get; set; }
    }
}
