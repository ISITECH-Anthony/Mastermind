// #define SHOW_LOGS
using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;

            while (restart)
            {
                Console.Clear();

                Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│                                                                                                  │");
                Console.WriteLine("│                                            MASTERMIND                                            │");
                Console.WriteLine("│                                                                                                  │");
                Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────────────┘");
                
                Console.WriteLine();

                Console.WriteLine("/ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  \\");
                Console.WriteLine("*                                                                                                  *");
                Console.WriteLine("*  Bienvenue dans le jeu Mastermind !                                                              *");
                Console.WriteLine("*                                                                                                  *");
                Console.WriteLine("*  Vous pouvez choisir ce que vous voulez faire en précisant le numéro                             *");
                Console.WriteLine("*                                                                                                  *");
                Console.WriteLine("\\  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * /");

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("                              ┌──────────────────────────────────────┐                              ");
                Console.WriteLine("                              │ 1)           Partie normal           │                              ");
                Console.WriteLine("                              └──────────────────────────────────────┘                              ");

                Console.WriteLine();

                Console.WriteLine("                              ┌──────────────────────────────────────┐                              ");
                Console.WriteLine("                              │ 2)       Partie personnalisée        │                              ");
                Console.WriteLine("                              └──────────────────────────────────────┘                              ");

                Console.WriteLine();

                Console.WriteLine("                              ┌──────────────────────────────────────┐                              ");
                Console.WriteLine("                              │ 3)      Historique des parties       │                              ");
                Console.WriteLine("                              └──────────────────────────────────────┘                              ");

                Console.WriteLine();

                Console.WriteLine("                              ┌──────────────────────────────────────┐                              ");
                Console.WriteLine("                              │ 4)          Règles du jeu            │                              ");
                Console.WriteLine("                              └──────────────────────────────────────┘                              ");

                Console.WriteLine();

                int buttonSelected = Convert.ToInt32(Console.ReadLine());

                if (buttonSelected == 1)
                {
                    Console.Clear();

                    new Game(12, 4);
                }
                else if (buttonSelected == 2)
                {
                    bool success = false;
                    bool error = false;
                    int nbLap = 12;
                    int nbColor = 4;

                    while (success == false)
                    {
                        Console.Clear();

                        Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────┐");
                        Console.WriteLine("│                                                                                                  │");
                        Console.WriteLine("│                                             OPTIONS                                              │");
                        Console.WriteLine("│                                                                                                  │");
                        Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────────────┘");

                        Console.WriteLine();

                        Console.WriteLine("/ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  \\");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*  Vous êtes sur le point de définir vos options de partie                                         *");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*  Veuillez choisir le nombre de tours que vous souhaitez faire pour votre partie                  *");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*  !! Attention !!                                                                                 *");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*  Tours minimum : 2                                                                               *");
                        Console.WriteLine("*  Tours maximum : 25                                                                              *");

                        if (error == true)
                        {
                            Console.WriteLine("*                                                                                                  *");
                            Console.WriteLine("*  Erreur : Veuillez entrer un nombre compris entre 2 et 25                                        *");
                        }

                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("\\  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * /");

                        Console.WriteLine();

                        nbLap = Convert.ToInt32(Console.ReadLine());

                        if (nbLap >= 2 && nbLap <= 25)
                        {
                            success = true;
                        }
                        else
                        {
                            error = true;
                        }
                    }

                    success = false;
                    error = false;

                    while (success == false)
                    {
                        Console.Clear();

                        Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────┐");
                        Console.WriteLine("│                                                                                                  │");
                        Console.WriteLine("│                                             OPTIONS                                              │");
                        Console.WriteLine("│                                                                                                  │");
                        Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────────────┘");

                        Console.WriteLine();

                        Console.WriteLine("/ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  \\");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*  Vous êtes sur le point de définir vos options de partie                                         *");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*  Veuillez choisir le nombre de couleurs que vous souhaitez utiliser pour votre partie            *");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*  !! Attention !!                                                                                 *");
                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("*  Couleurs minimum : 1                                                                            *");
                        Console.WriteLine("*  Couleurs maximum : 6                                                                            *");
                        
                        if (error == true)
                        {
                            Console.WriteLine("*                                                                                                  *");
                            Console.WriteLine("*  Erreur : Veuillez entrer un nombre compris entre 1 et 6                                        *");
                        }

                        Console.WriteLine("*                                                                                                  *");
                        Console.WriteLine("\\ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * /");

                        Console.WriteLine();

                        nbColor = Convert.ToInt32(Console.ReadLine());

                        if (nbColor >= 1 && nbColor <= 6)
                        {
                            success = true;
                        }
                        else
                        {
                            error = true;
                        }
                    }

                    Console.Clear();

                    new Game(nbLap, nbColor);
                }
                else if (buttonSelected == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi d'afficher l'historique des parties");
                }
                else if (buttonSelected == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi d'afficher les règles du jeu");
                }
                else
                {
                    Console.WriteLine("Erreur : Veuillez entrer un nombre valide !");
                }

                Console.WriteLine("Voulez vous retourner à l'accueil ? (y/n)");
                var answer = Console.ReadLine();

                if (answer == "n")
                {
                    restart = false;
                }
            }
        }
    }
}