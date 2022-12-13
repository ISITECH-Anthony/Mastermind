using System;

namespace Mastermind
{
    class Play
    {
        private List<Color> colors = new List<Color>();
        private List<int> result = new List<int>();

        // get colors
        public List<Color> GetColors()
        {
            return this.colors;
        }

        // get result
        public List<int> GetResult()
        {
            return this.result;
        }

        // set result
        public void SetResult(List<int> result)
        {
            this.result = result;
        }

        // add color
        public void AddColor(Color color)
        {
            this.colors.Add(color);
        }

        // compare play
        public void ComparePlay(List<Color> secret_code)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < secret_code.Count; i++)
            {
                if (this.colors[i].GetColorIndex() == secret_code[i].GetColorIndex())
                {
                    result.Add(1);
                }
                else if (this.colors.Contains(secret_code[i]))
                {
                    result.Add(2);
                }
                else
                {
                    result.Add(0);
                }
            }

            this.SetResult(result);
        }

        // is found
        public bool IsFound()
        {
            return this.result.Any() && this.result.All(x => x == 1);
        }

        // show play
        public void ShowPlay()
        {
            Console.Write("Play: ");

            foreach (Color color in this.colors)
            {
                Console.Write(color.GetColor() + " ");
            }

            Console.WriteLine();
        }

        // show result
        public void ShowResult()
        {
            Console.Write("Result: ");

            foreach (int result in this.result)
            {
                Console.Write(result + " ");
            }

            Console.WriteLine();
        }
    }
}