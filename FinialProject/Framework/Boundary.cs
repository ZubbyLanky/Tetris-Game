using System;

namespace FinialProject.Framework
{
    [Flags]
    public enum Boundary
    {
        None = 0,
        Top = 1,
        Left = 2,
        Bottom = 4,
        Right = 8
    }
}
