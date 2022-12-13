using System;

namespace Mastermind
{
    class Game
    {
        private List<Color> secret_code = new List<Color>();
        private Stack<Play> plays = new Stack<Play>();
        private int nb_lap;
        private int nb_color;
        private int actual_lap;
        private bool found;

        // constructor
        public Game(int nb_lap, int nb_color)
        {
            this.nb_lap = nb_lap;
            this.nb_color = nb_color;
            this.actual_lap = 1;
            this.found = false;

            this.GenerateSecretCode();

            this.StartGame();
        }

        // generate secret code
        public void GenerateSecretCode()
        {
            for (int i = 0; i < this.nb_color; i++)
            {
                this.secret_code.Add(new Color((Colors) new Random().Next(0, 6)));
            }
        }

        // show secret code
        public void ShowSecretCode()
        {
            Console.Write("Secret code: ");

            foreach (Color color in this.secret_code)
            {
                Console.Write(color.GetColor() + " " + color.GetColorIndex() + " ");
            }

            Console.WriteLine();
        }

        // start game
        public void StartGame()
        {
            while (this.actual_lap <= this.nb_lap && !this.found)
            {
                Play new_play = new Play();
                this.plays.Push(new_play);

                // choose colors
                for (int y = 0; y < this.nb_color; y++)
                {
                    Console.Clear();

                    this.ShowSecretCode();

                    this.ShowGame();

                    bool success = false;
                    int colorSelected = 1;

                    switch (y)
                    {
                        case 0:
                            Console.WriteLine("Veuillez choisir votre première couleur parmi les suivantes :");
                            break;
                        case 1:
                            Console.WriteLine("Veuillez choisir votre deuxième couleur parmi les suivantes :");
                            break;
                        case 2:
                            Console.WriteLine("Veuillez choisir votre troisième couleur parmi les suivantes :");
                            break;
                        case 3:
                            Console.WriteLine("Veuillez choisir votre quatrième couleur parmi les suivantes :");
                            break;
                        case 4:
                            Console.WriteLine("Veuillez choisir votre cinquième couleur parmi les suivantes :");
                            break;
                        case 5:
                            Console.WriteLine("Veuillez choisir votre sixième couleur parmi les suivantes :");
                            break;
                        default:
                            break;
                    }

                    Color.ListAllColors();

                    while (!success)
                    {
                        try
                        {
                            colorSelected = Convert.ToInt32(Console.ReadLine());

                            if (colorSelected < 1 || colorSelected > 6)
                            {
                                throw new Exception();
                            }
                            success = true;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Veuillez entrer un nombre valide");
                        }
                    }

                    new_play.AddColor(new Color((Colors) colorSelected - 1));
                }

                this.plays.Peek().ComparePlay(this.secret_code);

                if (this.plays.Peek().IsFound())
                {
                    this.found = true;
                } else {
                    this.actual_lap++;
                }
            }

            Console.Clear();

            // show end game
            this.ShowEndGame();
        }

        // show game
        public void ShowGame()
        {
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                                  │");
            if (this.plays.Peek().IsFound() && this.actual_lap <= this.nb_lap)
            {
                Console.WriteLine("│                                   MASTERMIND - Partie terminée                                   │");
                Console.WriteLine("│                                                                                                  │");
                Console.WriteLine("│                                             VICTOIRE                                             │");
            }
            else if (!this.plays.Peek().IsFound() && this.actual_lap == this.nb_lap)
            {
                Console.WriteLine("│                                   MASTERMIND - Partie terminée                                   │");
                Console.WriteLine("│                                                                                                  │");
                Console.WriteLine("│                                             DÉFAITE                                              │");
            }
            else
            {
                Console.WriteLine("│                                   MASTERMIND - Partie en cours                                   │");
            }
            Console.WriteLine("│                                                                                                  │");
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────────────┘");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                                  │");
            Console.WriteLine("│  Tour N° " + actual_lap.ToString("00") + "/" + nb_lap.ToString("00") + "                                                            Nombre de couleur : " + this.nb_color.ToString("0") + "  │");
            Console.WriteLine("│                                                                                                  │");
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────┐");

            // create empty row
            for (int i = 0; i < this.nb_lap - this.plays.Count; i++)
            {
                int padding = 62 - (this.nb_color * 9);

                string top_boxes = "│ │ ";
                string middle_boxes = "│ │ ";
                string bottom_boxes = "│ │ ";
                string end_boxes = " │ │       │ │";

                for (int y = 0; y < padding; y++)
                {
                    end_boxes = " " + end_boxes;
                }

                for (int y = 0; y < this.nb_color; y++)
                {
                    top_boxes += " ┌─────┐ ";
                    middle_boxes += " │     │ ";
                    bottom_boxes += " └─────┘ ";
                }

                top_boxes += end_boxes;
                middle_boxes += end_boxes;
                bottom_boxes += end_boxes;

                Console.WriteLine("│ ┌────────────────────────────────────────────────────────────────┐ ┌───────┐ │");
                Console.WriteLine(top_boxes);
                Console.WriteLine(middle_boxes);
                Console.WriteLine(bottom_boxes);
                Console.WriteLine("│ └────────────────────────────────────────────────────────────────┘ └───────┘ │");

                // Console.WriteLine("│ ┌─────────────────────────────────────────────────────────────────────────────────┐ ┌──────────┐ │");
                // Console.WriteLine("│ │   ┌─────┐    ┌─────┐    ┌─────┐    ┌─────┐    ┌─────┐    ┌─────┐                │ │          │ │");
                // Console.WriteLine("│ │   │  R  │    │  G  │    │  B  │    │  P  │    │  Y  │    │  O  │                │ │          │ │");
                // Console.WriteLine("│ │   └─────┘    └─────┘    └─────┘    └─────┘    └─────┘    └─────┘                │ │          │ │");
                // Console.WriteLine("│ └─────────────────────────────────────────────────────────────────────────────────┘ └──────────┘ │");
            }

            // foreach plays row
            foreach (Play play in this.plays)
            {
                // Console.WriteLine("│ ┌─────────────────────────────────────────────────────────────────────────────────┐ ┌──────────┐ │");
                // Console.WriteLine("│ │                                                                                 │ │          │ │");
                // Console.WriteLine("│ │   Plays                                                                         │ │          │ │");
                // Console.WriteLine("│ │                                                                                 │ │          │ │");
                // Console.WriteLine("│ └─────────────────────────────────────────────────────────────────────────────────┘ └──────────┘ │");

                int numberPlayColors = play.GetColors().Count;

                int padding = 62 - ((numberPlayColors + (this.nb_color - numberPlayColors)) * 9);

                string top_boxes = "│ │ ";
                string middle_boxes = "│ │ ";
                string bottom_boxes = "│ │ ";

                string top_result_boxes = "";
                string middle_result_boxes = "";
                string bottom_result_boxes = "";

                if (play.GetResult().Count() != 0)
                {
                    int result_position = 0;

                    if (nb_color <= 2)
                        {
                        middle_result_boxes = "      ";
                        bottom_result_boxes = "      ";
                    }
                    else if (nb_color <= 4)
                    {
                        bottom_result_boxes = "      ";
                    }

                    foreach (int result in play.GetResult())
                    {
                        if (result_position <= 2)
                        {
                            switch (result)
                            {
                                case 0:
                                    top_result_boxes += "   ";
                                    break;
                                case 1:
                                    top_result_boxes += " ● ";
                                    break;
                                case 2:
                                    top_result_boxes += " ○ ";
                                    break;
                            }
                        }
                        else if (result_position <= 4)
                        {
                            switch (result)
                            {
                                case 0:
                                    middle_result_boxes += "   ";
                                    break;
                                case 1:
                                    middle_result_boxes += " ● ";
                                    break;
                                case 2:
                                    middle_result_boxes += " ○ ";
                                    break;
                            }
                        }
                        else
                        {
                            switch (result)
                            {
                                case 0:
                                    bottom_result_boxes += "   ";
                                    break;
                                case 1:
                                    bottom_result_boxes += " ● ";
                                    break;
                                case 2:
                                    bottom_result_boxes += " ○ ";
                                    break;
                            }
                        }

                        result_position++;
                    }
                } 
                else
                {
                    top_result_boxes = "      ";
                    middle_result_boxes = "      ";
                    bottom_result_boxes = "      ";
                }

                string end_top_boxes = " │ │" + top_result_boxes + " │ │";
                string end_middle_boxes = " │ │" + middle_result_boxes + " │ │";
                string end_bottom_boxes = " │ │" + bottom_result_boxes + " │ │";

                for (int i = 0; i < padding; i++)
                {
                    end_top_boxes = " " + end_top_boxes;
                    end_middle_boxes = " " + end_middle_boxes;
                    end_bottom_boxes = " " + end_bottom_boxes;
                }

                foreach (Color color in play.GetColors())
                {
                    string colorName = color.GetColor().ToString().Substring(0, 1);

                    top_boxes += " ┌─────┐ ";
                    middle_boxes += " │  " + colorName + "  │ ";
                    bottom_boxes += " └─────┘ ";
                }

                for (int i = 0; i < this.nb_color - numberPlayColors; i++)
                {
                    top_boxes += " ┌─────┐ ";
                    middle_boxes += " │     │ ";
                    bottom_boxes += " └─────┘ ";
                }

                top_boxes += end_top_boxes;
                middle_boxes += end_middle_boxes;
                bottom_boxes += end_bottom_boxes;

                Console.WriteLine("│ ┌────────────────────────────────────────────────────────────────┐ ┌───────┐ │");
                Console.WriteLine(top_boxes);
                Console.WriteLine(middle_boxes);
                Console.WriteLine(bottom_boxes);
                Console.WriteLine("│ └────────────────────────────────────────────────────────────────┘ └───────┘ │");
            }

            Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────────────┘");
        }
    
        // show end game
        public void ShowEndGame()
        {
            string concat_secret_code = "";

            // concat secret code
            foreach (Color color in this.secret_code)
            {
                concat_secret_code += color.GetColor() + " ";
            }

            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                                                  │");
            Console.WriteLine("│                                   MASTERMIND - Partie terminée                                   │");
            Console.WriteLine("│                                                                                                  │");
            Console.WriteLine("│                                             FIN                                                  │");
            Console.WriteLine("│                                                                                                  │");
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────────────┘");

            Console.WriteLine();
            Console.WriteLine();

            if (this.found)
            {
                Console.WriteLine("/ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  \\");
                Console.WriteLine("*                                                                                                  *");
                Console.WriteLine("*  Vous avez trouvé la solution en " + this.actual_lap.ToString("00") + " tour(s)                                                      *");
                Console.WriteLine("*                                                                                                  *");
                Console.WriteLine("*  Le code secret était : " + concat_secret_code + "                                               *");
                Console.WriteLine("*                                                                                                  *");
                Console.WriteLine("\\ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  /");
            }
            else 
            {
                Console.WriteLine("/ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  \\");
                Console.WriteLine("*                                                                                                  *");
                Console.WriteLine("*  Vous n'avez pas trouvé la solution                                                              *");
                Console.WriteLine("*                                                                                                  *");
                Console.WriteLine("*  Le code secret était : " + concat_secret_code + "                                               *");
                Console.WriteLine("*                                                                                                  *");
                Console.WriteLine("\\ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  /");
            }

            Console.WriteLine();
        }
    }
}