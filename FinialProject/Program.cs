﻿using System;

namespace FinialProject
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new TetrisGame())
                game.Run();
        }
    }
}