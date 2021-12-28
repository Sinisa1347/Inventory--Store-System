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

            //int counterForArmorListPlayer = 1;
            //int counterForArmorListStore = 1;

            //var enteredWeight = new Player.Inventory();
            

            while (returnToStart==0)
            {

                Console.WriteLine("Welcome to my humble store system");
                Console.WriteLine("Are you a:");
                Console.WriteLine("1. buyer");
                Console.WriteLine("2. seller");
                Console.WriteLine("9. Reset the program");
                Console.WriteLine("0. Type 0 to exit the program");

                
                int returnToSellerBeginning = 0;

                Console.WriteLine("------------------");
                int readNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------");

                Console.Clear();

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
                        Console.WriteLine("6. Sell");
                        Console.WriteLine("0. Go back");

                        Console.WriteLine("------------------");
                        int enteredNumber = Convert.ToInt32(Console.ReadLine());                
                        Console.WriteLine("------------------");
                        
                        Console.Clear();

                        if (enteredNumber == 1)
                        {
                            var inventory = new Player.Inventory();//checking remaining player weight left
                            int checkedWeight = inventory.CheckForLeftWeight();

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

                        else if (enteredNumber == 2)
                        {
                            var armorCheck = new Player.Armor();
                            armorCheck.CheckArmorAvaibility();

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

                        else if (enteredNumber == 4)
                        {
                            var weaponCheck = new Player.Weapon();// OVDE
                            weaponCheck.CheckWeapon();

                            Console.WriteLine("0. Go back");
                            int checkInt = Convert.ToInt32(Console.ReadLine());
                            if (checkInt == 0)
                                returnInt = 0;
                        }

                        else if (enteredNumber == 5)
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

                                if (choise == 1)
                                {
                                    int returning = 0;

                                    while (returning == 0)
                                    {
                                        var storeArmor = new Store.Armor();//check store armor avaibility
                                        storeArmor.CheckArmorAvaibility();

                                        Console.WriteLine("---------");
                                        Console.WriteLine("0. Go back");
                                        int chosenNumber = Convert.ToInt32(Console.ReadLine());//input is chosenNumber

                                        if (chosenNumber == 0)
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

                                            //string readText = File.ReadAllText(armorList);
                                            //int numberOfLines = readText.Length;
                                            //string[] readText = File.ReadAllLines(armorList);
                                            //string textWithoutNumber = readText[chosenNumber].Remove(0, 3);// removed first tree letter (number. )

                                            if (check == 1)
                                            {
                                                Console.Clear();

                                                string[] readText = File.ReadAllLines(armorList);
                                                string textWithoutNumber = readText[chosenNumber].Remove(0, 3);

                                                string[] splitForWeight = textWithoutNumber.Split(",");
                                                int WeightOfBoughtArmor = Convert.ToInt32(splitForWeight[2]);

                                                var weightCheck = new Player.Inventory();
                                                int leftWeight = weightCheck.SubtractBoughtStuffWeightFromMaxWeight(WeightOfBoughtArmor);
                                                
                                                int checkInventoryWeight = weightCheck.CheckForLeftWeight();

                                                if (leftWeight==-1)
                                                {
                                                    Console.WriteLine("You can't add anymore stuff to your invenotory");
                                                    Console.WriteLine("Please sell something to continue");
                                                    Console.WriteLine("Press 0 to go back");
                                                    int goBack = Convert.ToInt32(Console.ReadLine());
                                                    Console.Clear();

                                                    if (goBack == 0)
                                                        returning = 0;
                                                    else
                                                        returning = 0;

                                                }
                                                else
                                                {

                                                    Console.WriteLine("Adding the next item to you inventory:");
                                                    Console.WriteLine(readText[chosenNumber]);//text start from 0 index of readText


                                                    var addedItem = new Player.Armor();
                                                    addedItem.BoughtArmor(textWithoutNumber);
                                                        

                                                    var chosenString = Convert.ToString(chosenNumber);
                                                    chosenString = $"{chosenString}.";
                                                    var deleteItem = new Store.Armor();//method for deleting bought stuff
                                                    deleteItem.soldArmorToPlayer(chosenString);

                                                    //counterForArmorListPlayer++;
                                                    //counterForArmorListStore--;

                                                    Console.WriteLine("0. go back");

                                                    int input = Convert.ToInt32(Console.ReadLine());

                                                    if (input == 0)
                                                    {
                                                        //weightLeftForWhileLoop = 0;
                                                        returning = 0;
                                                        Console.Clear();
                                                    }
                                                }
                                                
                                            }

                                            else if (check == 2)
                                            {
                                                
                                                returning = 0;
                                                Console.Clear();
                                            }
                                            

                                        }

                                    }
                                }

                                else if (choise == 2)
                                {

                                }

                                else if (choise == 3)
                                {

                                }

                                else if (choise == 0)
                                {
                                    break;
                                }
                            }
                        }

                        else if (enteredNumber == 6)
                        {
                            while (returnInt == 0)
                            {
                                Console.WriteLine("What would you like to sell?");
                                Console.WriteLine("1. Armor");
                                Console.WriteLine("2. Potion");
                                Console.WriteLine("3. Weapon");
                                Console.WriteLine("0. Go back");

                                int choise = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (choise == 1)
                                {
                                    int returning = 0;

                                    while (returning == 0)
                                    {
                                        var playerArmor = new Player.Armor();//check player armor avaibility
                                        playerArmor.CheckArmorAvaibility();

                                        Console.WriteLine("---------");
                                        Console.WriteLine("0. Go back");
                                        int entered = Convert.ToInt32(Console.ReadLine());//input is chosen1

                                        if (entered == 0)
                                        {
                                            returning = 1;
                                            returnInt = 0;
                                            Console.Clear();
                                        }

                                        else
                                        {
                                            string armorList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Player\ArmorList.txt";

                                            Console.Clear();

                                            Console.WriteLine("Are you sure you want to sell this item:");
                                            Console.WriteLine("1. yes");
                                            Console.WriteLine("2. no");

                                            int check = Convert.ToInt32(Console.ReadLine());
                                            

                                            if (check == 1)
                                            {
                                                Console.Clear();

                                                string[] readText = File.ReadAllLines(armorList);

                                                Console.WriteLine("Removing the next item from your inventory:");
                                                Console.WriteLine(readText[entered]);//text start from 0 index of readText

                                                string textWithoutNumber = readText[entered].Remove(0, 3);

                                                var removedItem = new Player.Armor();//methods for deleting sold stuff from Player
                                                var convertedInputToString = Convert.ToString(entered);
                                                removedItem.SoldArmorToStore($"{convertedInputToString}. ");

                                                string[] armorToBeRemoved = textWithoutNumber.Split(",");//armor weight
                                                int weightOfSoldArmor = Convert.ToInt32(armorToBeRemoved[2]);

                                                var addWeightOfSoldStuff = new Player.Inventory();
                                                addWeightOfSoldStuff.AddSoldStuffWeightToCurrentWeight(weightOfSoldArmor);//remaining weight

                                                var addedItem = new Store.Armor();//method for adding sold stuff to Store
                                                addedItem.boughtArmorFromPlayer(readText[entered]);
                                                

                                                Console.WriteLine("0. go back");

                                                int input = Convert.ToInt32(Console.ReadLine());




                                                if (input == 0)
                                                {
                                                    returning = 0;
                                                    Console.Clear();
                                                }
                                            }
                                            else if (check == 2)
                                            {
                                                returning = 0;
                                                Console.Clear();
                                            }
                                            
                                           
                                        }

                                    }
                                }

                                else if (choise==2)
                                {

                                }

                                else if (choise ==3)
                                {

                                }

                                else if (choise == 0)
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

                    while (returnToSellerBeginning == 0)
                    {
                        

                        

                        Console.WriteLine("Choose the category");
                        Console.WriteLine("1. Armor");
                        Console.WriteLine("2. Potion");
                        Console.WriteLine("3. Weapon");
                        Console.WriteLine("0. Go back");

                        int returnInt = 0;

                        int checkInt = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        if (checkInt == 0)
                            returnToSellerBeginning = 1;
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
                                    returnToSellerBeginning = 0;
                             
                                if (checkInt == 1)
                                {


                                    var listOfStoreArmors = new Store.Armor();                         
                                    listOfStoreArmors.ArmorShipment();

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

                else if (readNumber==9)
                {
                    Console.WriteLine("Are you sure you want to reset?");
                    Console.WriteLine("This cannot be undone...");
                    Console.WriteLine("1. Yes, reset it");
                    Console.WriteLine("2. Go back");

                    int readInput = Convert.ToInt32(Console.ReadLine());
                    
                    if (readInput==1)
                    {
                        var resetArmorListForPlayer = new Player.Armor();
                        resetArmorListForPlayer.ResetArmorListPlayer();

                        var resetArmorListForStore = new Store.Armor();
                        resetArmorListForStore.ResetArmorListStore();

                        var resetMaxWeight = new Player.Inventory();
                        resetMaxWeight.ResetMaxWeight();
                    }
                    else if (readInput==0)
                    {
                        returnToStart = 0;
                    }
                    else
                    {
                        returnToStart = 0;
                    }
                    Console.Clear();


                }

                

            }

        }

        //napravim metodu za player-a (npr V1);

        //napravim metodu za store (npr V2);
    }

}
