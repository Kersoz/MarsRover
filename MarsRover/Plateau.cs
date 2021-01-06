using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Plateau
    {
        public const int MinHeight = 0;
        public const int MinWidth = 0;
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        public Plateau(int maxWidht, int maxHeight)
        {
            MaxWidth = maxWidht;
            MaxHeight = maxHeight;
        }
    }
}
