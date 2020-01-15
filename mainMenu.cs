using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace QuizGame
{
    class mainMenu
    {
        Quiz quiz;
        GameManager gm;
        string response;
        public mainMenu()
        {
           gm = new GameManager();
        }
        public void displayMainMenu()
        {
            

            Console.Clear();

            Console.WriteLine("Who want to be Milionare?!?");
            Console.WriteLine("");
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Display high scores");
            Console.WriteLine("3. Administration panel");
            Console.WriteLine("4. Quit game");
            Console.WriteLine("");
            getResponse();

        }
        private void selectGameMode()
        {            
            Console.WriteLine("Select game mode (Normal or ByDifficulty)");
            string response;
            response = Console.ReadLine();
            response = response.ToUpper();

            switch(response)
            {
                case "NORMAL":                   
                    for(int i = 3; i > 0; i--)
                    {
                        Console.Clear();
                        Console.WriteLine("Starting new game in..");
                        Console.WriteLine("{0}..", i);
                        Thread.Sleep(1000);
                    }
                    quiz.normalGame();
                    break;
                case "BYDIFFICULTY":
                    for (int i = 3; i > 0; i--)
                    {
                        Console.Clear();
                        Console.WriteLine("Starting new game in..");
                        Console.WriteLine("{0}..", i);
                        Thread.Sleep(1000);
                    }
                    quiz.byDifficulty();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong input!");
                    selectGameMode();
                    break;
            }
        }
        private void getResponse()
        {

            response = Console.ReadLine();
            
            switch (response)
            {
                case "1":
                    //Start new game  
                    quiz = new Quiz();
                    //quiz.normalGame();
                    Console.Clear();
                    selectGameMode();
                    quiz = null;
                    displayMainMenu();
                    break;
                case "2":
                    //display high scores
                    Console.Clear();
                    Console.WriteLine("High scores. Press any key");
                    int score = int.Parse(Console.ReadLine());
                    gm.addScore(score);
                    gm.saveHighScoresToFile();
                    displayHighSocre();
                    Console.ReadLine();
                    displayMainMenu();
                    break;
                case "3":
                    //administration panel
                    Console.Clear();
                    Console.WriteLine("Administration panel. Enter password: ");                    
                    string password = Console.ReadLine();
                    if(password == "1234")
                    {
                        Console.Clear();
                        gm.administrationPanelOptions();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Password! Press any key to go back to main menu!");
                        Console.ReadLine();
                    }
                    displayMainMenu();
                    break;
                case "4":
                    //quit
                    Console.Clear();
                    System.Environment.Exit(0);
                    break;
                default:
                    displayMainMenu();
                    break;
            }
        }
        public void displayHighSocre()
        {
            foreach(HighScore hs in GameManager.highScores)
            {

                Console.WriteLine(hs.ToString());
            }
        }
    }
}
