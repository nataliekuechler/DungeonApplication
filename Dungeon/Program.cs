﻿using DungeonLibrary;
using System.IO;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title & Introduction

            #region Title / Introduction

            Console.Title = "SOLAR SYSTEM";

            Console.WriteLine("Your journey begins...\n");

            #endregion

            //Variable to Track Score

            int score = 0;

            //TODO Weapon Object to be created
            Weapon sword = new Weapon(WeaponType.Sword, 8, "Long Sword", 10, false, 1);
            //Console.WriteLine(sword);//test the ToString()
            //Create a list of weapons, and either give the player a random weapon, let them pick a weapon, 
            //or let them pick a WeaponType, and give them a weapon based off of that type.





            #region Player Object Creation
            Player player = new Player("Leeroy Jenkins", 70, 5, 40, Race.Elf, sword);
            #endregion





            // Create the main game loop
            #region Main Game Loop

            //Counter Variable- used in the condition of the loop
            bool exit = false;

            //The air in the room is steamy.The room smells smoky. A loud drumming noise can be heard. EXAMPLE

            
            

            do
            {
                Console.WriteLine(GetRoom());

                //Select a random monster to inhabit the room
                Monster monster = Monster.GetMonster();
                Console.WriteLine("On this planet..." +monster.Name);

                //Create the gameplay menu loop

                #region Gameplay Menu Loop

                bool reload = false;

                do
                {
                    //TODO Create the main gameplay menu
                    #region MENU

                    //Prompt the user
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away!\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    //Capture the user's menu selection
                    ConsoleKey userChoice = Console.ReadKey(true).Key; //Capture the pressed key, hide the key from the console,
                    //and execute immediately . ---true hides the key from the console---

                    //clear the console
                    Console.Clear();

                    //Use branching logic to act upon the user's selection
                    switch (userChoice)
                    {
                        case ConsoleKey.A:

                            // Combat


                            Combat.DoBattle(player, monster);
                            //Check if monster is dead
                            if (monster.Life <= 0)
                            {
                                //Use green to indicate winning!
                                Console.ForegroundColor = ConsoleColor.Green;

                                //output the result
                                Console.WriteLine($"\nYou killed {monster.Name}!");

                                //Reset the color
                                Console.ResetColor();

                                //leave the inner loop
                                reload = true;

                                //update the score
                                score++;
                            }

                            break;

                        case ConsoleKey.R:

                            //TODO Run Away - Attack of Opportunity

                            Console.WriteLine("Run Away!!!");

                            //Monster gets an "attack of opportunity"
                            Console.WriteLine(monster.Name + " attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine(); //for formatting
                            reload = true;

                            break;

                        case ConsoleKey.P:

                            //TODO Player Stats

                            Console.WriteLine(player);

                            break;

                        case ConsoleKey.M:

                            //Monster Stats

                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:
                        case ConsoleKey.Escape:

                            //Exit the game

                            Console.WriteLine("Nobody likes a quitter...");

                            exit = true;
                            break;



                        default:

                            Console.WriteLine("That is not a valid option. Please try again.");
                            break;

                    }//end switch

                    #region Check Player's Life Total

                    //Check Player's Life

                    if (player.Life <=0)
                    {
                        Console.WriteLine("Dude, you died! \a");
                        exit = true;
                    }

                    #endregion


                    #endregion

                } while (!reload && !exit);

                #endregion








            } while (!exit); //keep looping as long as exit is false

            #endregion

            //TODO Output the Final Score
            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "!" : "s!"));


            //Added this line to preserve the Console.Title
            Console.ReadKey();

        }//end Main()

        private static string GetRoom()
        {
            string[] stellarObjects = {
                "The Sun- Ouch! Don't look! Or get too close...",
                "You've landed on the smallest planet. It's a scorching 800 degrees. Mercury",
                "You landed on the hottest planet...Venus! The atmosphere is thick and the pressure is immense.",
                "Back to Earth! Booming with life. Finally, a comfortable temperature.",
                "Looks like Earth...kind of. The ground is red with mountains on the horizon. Mars",
                "The largest of all! You start slowly sinking through the atmosphere without a surface in sight. Jupiter",
                "Saturn. You see rings in the sky with a pale blue dot in the distance. Home seems so far away now...",
                "Uranus. Blue-green gas is all around you.",
                "Neptune. Dark blue and gaseous",
                "Pluto. Not even a planet! We are in the Kuiper belt. It's cold and the Sun is just a tiny dot in the sky",
                "Asteroid Belt. There's asteroids everywhere!",
                "Kuiper Belt- There's icy objects everywhere!",
                "Oort Cloud- Everything seems so far away and it feels like you're inside a bubble. There's some large, icy objects floating around you. "
            };
            Random rand = new Random();
            return stellarObjects[rand.Next(stellarObjects.Length)];
        

        }//endGetRoom
    }//end class
}//end namespace