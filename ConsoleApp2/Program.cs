using System.ComponentModel.Design;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            // Player stats
            int attackPower = 3;
            int yourHealth = 20;
            int playerDefense = 0;
            int playerDefenseTR = 0;
            int playerCooldown = 0;
          

            // Enemy stats
            int enemyHealth = 23;
            int enemyAttack = 3;
            int enemyDefense = 0;
            int enemyDefendTR = 0;
            int enemyCooldown = 0;

            // Introduction
            Console.WriteLine("Welcome to the collesum!");
            Console.ReadKey();
            Console.WriteLine("Well it is time to begin your first fight againts a colluseem newbie");
            Console.ReadKey();

            // Main game loop
            while (yourHealth > 0 && enemyHealth > 0)
            {
                Console.WriteLine("Your turn! a to attack and d to defend!");
                Console.WriteLine($"Your health - {yourHealth}  Enemy health - {enemyHealth}");
                Console.WriteLine($"Your defense - {playerDefense} Enemy defense - {enemyDefense}");
                Console.WriteLine($"Turns: {playerDefenseTR}  Enenmy Turns: {enemyDefendTR}");
                string playerFight = Console.ReadLine();

                if (playerFight == "a")
                {
                    // Player attacks
                    
                    enemyHealth -= attackPower - enemyDefense;
                    Console.WriteLine($"You attacked and dealt {attackPower} damage!");
                    if (enemyDefendTR > 0)
                    {
                        enemyDefendTR--;
                        Console.ReadKey();
                    }
                    else if (enemyDefendTR >= 0)
                    {

                    }
                 
                   
                }
                else if (playerFight == "d")
                {

                    if (playerDefense == 2 | playerCooldown == 1)
                    {
                        Console.WriteLine($"You can't defend for {playerDefenseTR} turns.");
                        continue;
                    }

                    // Player defends
                    if (playerDefense == 0 & playerDefenseTR == 0 & playerCooldown == 0)
                    {
                        Console.WriteLine("You defended! You gained 2 defense points for 2 attacks.");
                        playerDefense += 2;
                        playerDefenseTR += 2;
                        Console.ReadKey();
                    }
                    else if (playerDefense >= 2 && playerDefenseTR <= 0)
                    {
                        Console.WriteLine("Your two turns are up! You lost two defense");
                        playerDefense -= 2;
                        playerCooldown++;
                    }
                    
                    
                }
                else
                {

                    Console.WriteLine("Choose a valid input!");
                    continue;
                }
               
                if (enemyDefense >= 2 && enemyDefendTR == 0)
                {
                    enemyDefense -= 2;
                    enemyCooldown++;
                    Console.WriteLine($"The enemy's defense is now {enemyDefense}.");

                }
                
                



                if (enemyHealth > 0)
                //Enemy turn
                {

                    Console.WriteLine("--Enemys Turn--");
                    int enemyChoice = random.Next(0, 2);
                    int dodgeChance = random.Next(1, 3);



                    if (enemyChoice == 0)
                    {
                        Console.WriteLine($"The enemy attacked and dealth {enemyAttack} damage to you! ");
                        yourHealth = yourHealth - enemyAttack;
                        if (playerDefenseTR > 0)
                        {
                            playerDefenseTR--;
                            
                        }
                        else if (playerDefenseTR >= 0)
                        {

                        }
                        Console.ReadKey();

                    }
                    else if (enemyChoice == 1  )
                    {
                        if (enemyDefendTR <= 0 & enemyCooldown == 0)
                        {
                            enemyDefendTR += 2;
                            enemyDefense += 2;
                            Console.WriteLine("The enemy defended and gained 2 defense points!");
                            Console.ReadKey();
                        }
                        else if (enemyDefendTR >= 1 | enemyCooldown == 1)
                        {
                            Console.WriteLine($"The enemy attacked and dealt {enemyAttack} damage to you! ");
                            yourHealth = yourHealth - enemyAttack;
                            Console.ReadKey();
                            if (playerDefenseTR > 0)
                            {
                                playerDefenseTR--;

                            }
                            else if (playerDefenseTR >= 0)
                            {
                               
                            }

                           
                        }
                    }
                }

                if (playerDefense >= 2 && playerDefenseTR <= 0)
                {
                    Console.WriteLine("Your two turns are up! You lost two defense");
                    playerDefense -= 2;
                }
                if (playerCooldown == 1)
                {
                    playerCooldown--;
                    Console.WriteLine("You can defend again!");
                }

                if (yourHealth <= 0)
                {
                    Console.WriteLine("You were deafeated by a newbie... NOOB");

                }
                else if (enemyHealth <= 0)
                {
                    Console.WriteLine("Nice job! You defeated your first enemy.");
                }




            }
            }
        }
    }

