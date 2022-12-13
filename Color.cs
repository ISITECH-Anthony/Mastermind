using System;

namespace Mastermind
{
    enum Colors {
        Red,
        Green,
        Blue,
        Yellow,
        Orange,
        Purple
    }
    class Color
    {
        private Colors color;

        // constructor
        public Color(Colors color)
        {
            this.color = color;
        }

        // get color
        public Colors GetColor()
        {
            return this.color;
        }

        // get color index
        public int GetColorIndex()
        {
            return (int) this.color;
        }

        // list all colors with index
        public static void ListAllColors()
        {
            foreach (Colors color in Enum.GetValues(typeof(Colors)))
            {
                Console.WriteLine(((int) color + 1) + ") " + color);
            }
        }
    }
}