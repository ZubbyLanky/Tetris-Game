using System;

namespace FinialProject.Framework
{
    [Flags]
    public enum Orientation
    {
        NotDefined = 0,
        North = 1,
        East = 2,
        South = 4,
        West = 8,
        NorthEast = 3,
        SouthEast = 6,
        NorthWest = 9,
        SouthWest = 12
    }
}
