using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Player = Inventory__Store_System.Player;
using Store = Inventory__Store_System.Store;


namespace Inventory__Store_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            int returnToStart = 0;
            int returnToBeginning = 0;

            int counterForArmorListPlayer = 1;

            while (returnToStart==0)
            {
                Console.WriteLine("Welcome to my humble store system");
                Console.WriteLine("Are you a:");
                Console.WriteLine("1. buyer");
                Console.WriteLine("2. seller");
                Console.WriteLine("0. Type 0 to exit the program");

                Console.WriteLine("------------------");
                int readNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------");

                if (readNumber == 0)
                    Environment.Exit(0);

                else if (readNumber==1)//buyer-inventory weight check
                {
                   int returnInt = 0;               
                   Console.Clear();

                    while (returnInt==0)//first going back
                    {
                        Console.WriteLine("1. Check inventory weight:");
                        Console.WriteLine("2. Check armor availability:");
                        Console.WriteLine("3. Check potion availability:");
                        Console.WriteLine("4. Check weapon availability:");
                        Console.WriteLine("5. Buy");
                        Console.WriteLine("0. Go back");

                        Console.WriteLine("------------------");
                        int enteredNumber = Convert.ToInt32(Console.ReadLine());                
                        Console.WriteLine("------------------");
                        
                        Console.Clear();
                        
                        if (enteredNumber == 1)
                        {
                            var inventory = new Player.Inventory();//checking remaining player weight left
                            inventory.Check();

                            Console.WriteLine("0. Go back");
                            int checkInt = Convert.ToInt32(Console.ReadLine());
                            if (checkInt == 0)
                                returnInt = 0;
                            else
                            {
                                Console.WriteLine("Please enter 0 if you want to go back");
                                returnInt = 0;
                            }    
                        }

                        else if (enteredNumber==2)
                        {
                            var armorCheck = new Player.Armor();
                            armorCheck.CheckArmor();

                            Console.WriteLine("0. Go back");
                            int checkInt = Convert.ToInt32(Console.ReadLine());
                            if (checkInt == 0)
                                returnInt = 0;

                        }

                        else if (enteredNumber == 3)
                        {
                            var potionCheck = new Player.Potion();
                            potionCheck.CheckPotion();

                            Console.WriteLine("0. Go back");
                            int checkInt = Convert.ToInt32(Console.ReadLine());
                            if (checkInt == 0)
                                returnInt = 0;

                        }

                        else if (enteredNumber==4)
                        {
                            var weaponCheck = new Player.Weapon();// OVDE
                            weaponCheck.CheckWeapon();

                            Console.WriteLine("0. Go back");
                            int checkInt = Convert.ToInt32(Console.ReadLine());
                            if (checkInt == 0)
                                returnInt = 0;
                        }


                        else if (enteredNumber==5)
                        {
                            while (returnInt == 0)
                            {
                                Console.WriteLine("What would you like to buy?");
                                Console.WriteLine("1. Armor");
                                Console.WriteLine("2. Potion");
                                Console.WriteLine("3. Weapon");
                                Console.WriteLine("0. Go back");

                                int choise = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (choise==1)
                                {
                                    int returning = 0;
                                    
                                    while (returning==0)
                                    {
                                        var storeArmor = new Store.Armor();//check store armor avaibility
                                        storeArmor.CheckArmorAvaibility();
                                        
                                        Console.WriteLine("---------");
                                        Console.WriteLine("0. Go back");
                                        int chosen1 = Convert.ToInt32(Console.ReadLine());//input is chosen1

                                        if (chosen1 == 0)
                                        {
                                            returning = 1;
                                            returnInt = 0;
                                            Console.Clear();
                                        }

                                        else
                                        {
                                            string armorList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Store\ArmorList.txt";

                                            Console.Clear();

                                            Console.WriteLine("Are you sure you want to buy this item:");//confirm choise
                                            Console.WriteLine("1. yes");
                                            Console.WriteLine("2. no");

                                            int check = Convert.ToInt32(Console.ReadLine());
                                            if (check == 1)
                                            {
                                                Console.Clear();

                                                string[] readText = File.ReadAllLines(armorList);

                                                Console.WriteLine("Adding the next item to you inventory:");
                                                Console.WriteLine($"{chosen1}.{readText[chosen1]}");//text start from 0 index of readText

                                                //PlayerArmor.Armor();//prvo da dam igracu pa onda mogu brisati iz stor-a
                                                //Armor.soldArmorToPlayer(chosen1);


                                                var addedItem = new Player.Armor();
                                                addedItem.BoughtArmor(readText[chosen1], counterForArmorListPlayer);
                                                counterForArmorListPlayer++;

                                                var deleteItem = new Store.Armor();//method for deleting bought stuff
                                                deleteItem.soldArmorToPlayer(chosen1);

                                                Console.WriteLine("0. go back");

                                                int input = Convert.ToInt32(Console.ReadLine());

                                                if (input == 0)
                                                {
                                                    returning = 0;
                                                    Console.Clear();
                                                }
                                            }
                                            else if(check==2)
                                            {
                                                returning = 0;
                                                Console.Clear();
                                            }
                                        }

                                    }
                                        //Console.WriteLine();
                                        //Console.WriteLine("0. Go back");
                                        //int checkInt = Convert.ToInt32(Console.ReadLine());
                                        //if (checkInt == 0)
                                        //    returnInt = 0;

                                        //Console.Clear();

                                    
                                }

                                else if (choise==2)
                                {

                                }

                                else if (choise == 3)
                                {

                                }

                                else if(choise==0)
                                {
                                    break;
                                }
                            }
                        }


                        else if (enteredNumber == 0)
                        {
                            returnInt = 1;
                            returnToStart = 0;
                        }    

                        

                        else
                        {
                            Console.WriteLine("Please enter 0 if you want to go back");
                        }
                        Console.Clear();
                    }              
                }



                else if (readNumber==2)//seller
                {
                    Console.Clear();

                    while (returnToBeginning==0)
                    {
                        int returnInt = 0;
                        Console.Clear();

                        Console.WriteLine("Choose the category");
                        Console.WriteLine("1. Armor");
                        Console.WriteLine("2. Potion");
                        Console.WriteLine("3. Weapon");
                        Console.WriteLine("0. Go back");
                    
                        int checkInt = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (checkInt == 0)
                            returnToBeginning=1;
                            returnToStart = 0;
                    

                        if (checkInt == 1)//armor
                        {
                            while (returnInt==0)
                            {

                                Console.WriteLine("What would you like to do");
                                Console.WriteLine("1. Order new armor (armor shipment)");
                                Console.WriteLine("2. Check armor avaibility");
                                Console.WriteLine("0. Go back");

                                checkInt= Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (checkInt == 0)
                                    returnToBeginning = 0;
                             
                                if (checkInt == 1)
                                {
                                    var armorList = new Store.Armor();// dodavanje novog armor-a
                                    armorList.ArmorShipment();
                                
                                    Console.WriteLine("0. Go back");

                                    checkInt = Convert.ToInt32(Console.ReadLine());
                                    if (checkInt == 0)
                                        returnInt = 0;
                                
                                    Console.Clear();
                                }

                                else if (checkInt==2)
                                {
                                    var armorAvaibility = new Store.Armor();// proveravanje armora u prodavnici
                                    armorAvaibility.CheckArmorAvaibility();

                                    Console.WriteLine("0. Go back");

                                    checkInt = Convert.ToInt32(Console.ReadLine());
                                    if (checkInt == 0)
                                        returnInt = 0;

                                    Console.Clear();

                                }

                                else if (checkInt==0)
                                {
                                    returnInt = 1;
                                }
                            
                        
                        
                            }
                        }

                        else if (checkInt==2)
                        {

                        }

                        else if (checkInt == 3)
                        {

                        }

                        else if (checkInt == 0)
                        {
                            returnInt = 1;
                            returnToStart = 0;
                        }
                    
                    }    
                    
                }

                

            }

        }

        //napravim metodu za player-a (npr V1);

        //napravim metodu za store (npr V2);
    }

}
