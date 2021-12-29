﻿using System;
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
                        Console.WriteLine("2. Check money:");
                        Console.WriteLine("3. Check armor availability:");
                        Console.WriteLine("4. Check potion availability:");
                        Console.WriteLine("5. Check weapon availability:");
                        Console.WriteLine("6. Buy");
                        Console.WriteLine("7. Sell");
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

                        else if (enteredNumber==2)
                        {
                            var moneyCheck = new Player.Money();
                            moneyCheck.CheckForLeftMoney();
                            Console.WriteLine("Press 0 to go back");
                            int checkInt = Convert.ToInt32(Console.ReadLine());
                            if (checkInt == 0)
                                returnInt = 0;
                            else
                                returnInt = 0;

                        }

                        else if (enteredNumber == 3)
                        {
                            var armorCheck = new Player.Armor();
                            armorCheck.CheckArmorAvaibility();
                            Console.WriteLine("Press 0 to go back");
                            int checkInt = Convert.ToInt32(Console.ReadLine());
                            if (checkInt == 0)
                                returnInt = 0;
                            else
                                returnInt = 0;

                        }

                        else if (enteredNumber == 4)
                        {
                            var potionCheck = new Player.Potion();
                            potionCheck.CheckPotionAvaibility();

                            Console.WriteLine("0. Go back");
                            int checkInt = Convert.ToInt32(Console.ReadLine());
                            if (checkInt == 0)
                                returnInt = 0;

                        }

                        else if (enteredNumber == 5)
                        {
                            var weaponCheck = new Player.Weapon();
                            weaponCheck.CheckWeaponAvaibility();

                            Console.WriteLine("0. Go back");
                            int checkInt = Convert.ToInt32(Console.ReadLine());
                            if (checkInt == 0)
                                returnInt = 0;
                        }

                        else if (enteredNumber == 6)
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
                                        var weightLeftHeader = new Player.Inventory();
                                        weightLeftHeader.CheckForLeftWeight();

                                        var moneyLeftHeader = new Player.Money();
                                        moneyLeftHeader.CheckForLeftMoney();
                                        
                                        Console.WriteLine("----------------------");

                                        
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

                                            if (check == 1)
                                            {
                                                Console.Clear();

                                                string[] readText = File.ReadAllLines(armorList);
                                                string textWithoutNumber = readText[chosenNumber].Remove(0, 3);

                                                string[] splitForCost = textWithoutNumber.Split(",");
                                                string removedSemicolon=splitForCost[3].Remove(splitForCost[3].Length-1,1);
                                                double costOfBoughtArmor = Convert.ToDouble(removedSemicolon);
                                                var costOfArmor = new Player.Money();
                                                double checkForLeftMoney = costOfArmor.LeftMoneyValue();


                                                string[] splitForWeight = textWithoutNumber.Split(",");
                                                int WeightOfBoughtArmor = Convert.ToInt32(splitForWeight[2]);
                                                var weightCheck = new Player.Inventory();
                                                int checkInventoryWeight = weightCheck.LeftWeightValue();

                                                if (checkForLeftMoney-costOfBoughtArmor<0)
                                                {
                                                    Console.WriteLine("You don't have enough money");
                                                    Console.WriteLine("Press 0 to go back");
                                                    int goBack = Convert.ToInt32(Console.ReadLine());
                                                    if (goBack == 0)
                                                        returning = 0;
                                                    Console.Clear();
                                                }

                                                else if (checkInventoryWeight-WeightOfBoughtArmor < 0)
                                                {
                                                    Console.WriteLine("You can't carry anymore stuff");
                                                    Console.WriteLine("Press 0 to go back");
                                                    int goBack = Convert.ToInt32(Console.ReadLine());
                                                    if (goBack == 0)
                                                        returning = 0;
                                                    Console.Clear();
                                                }

                                                else
                                                {
                                                    double moneyLeft = costOfArmor.SubtractBoughtStuffCostFromMoneyLeft(costOfBoughtArmor);
                                                    int leftWeight = weightCheck.SubtractBoughtStuffWeightFromMaxWeight(WeightOfBoughtArmor);

                                                    Console.WriteLine("Adding the next item to you inventory:");
                                                    Console.WriteLine(readText[chosenNumber]);//text start from 0 index of readText


                                                    var addedItem = new Player.Armor();
                                                    addedItem.BoughtArmor(textWithoutNumber);


                                                    var chosenString = Convert.ToString(chosenNumber);
                                                    chosenString = $"{chosenString}. ";
                                                    var deleteItem = new Store.Armor();//method for deleting bought stuff
                                                    deleteItem.soldArmorToPlayer(chosenString);

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
                                    int returning = 0;

                                    while (returning == 0)
                                    {
                                        var weightLeftHeader = new Player.Inventory();
                                        weightLeftHeader.CheckForLeftWeight();

                                        var moneyLeftHeader = new Player.Money();
                                        moneyLeftHeader.CheckForLeftMoney();

                                        Console.WriteLine("----------------------");


                                        var storePotion = new Store.Potion();//check store armor avaibility
                                        storePotion.CheckPotionAvaibility();

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
                                            string potionList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Store\PotionList.txt";

                                            Console.Clear();

                                            Console.WriteLine("Are you sure you want to buy this item:");//confirm choise
                                            Console.WriteLine("1. yes");
                                            Console.WriteLine("2. no");

                                            int check = Convert.ToInt32(Console.ReadLine());

                                            if (check == 1)
                                            {
                                                Console.Clear();

                                                string[] readText = File.ReadAllLines(potionList);
                                                string textWithoutNumber = readText[chosenNumber].Remove(0, 3);

                                                string[] splitForCost = textWithoutNumber.Split(",");
                                                string removedSemicolon = splitForCost[3].Remove(splitForCost[3].Length - 1, 1);
                                                double costOfBoughtPotion = Convert.ToDouble(removedSemicolon);
                                                var costOfPotion = new Player.Money();
                                                double checkForLeftMoney = costOfPotion.LeftMoneyValue();


                                                string[] splitForWeight = textWithoutNumber.Split(",");
                                                int WeightOfBoughtPotion = Convert.ToInt32(splitForWeight[2]);
                                                var weightCheck = new Player.Inventory();
                                                int checkInventoryWeight = weightCheck.LeftWeightValue();

                                                if (checkForLeftMoney-costOfBoughtPotion < 0)
                                                {
                                                    Console.WriteLine("You don't have enough money");
                                                    Console.WriteLine("Press 0 to go back");
                                                    int goBack = Convert.ToInt32(Console.ReadLine());
                                                    if (goBack == 0)
                                                        returning = 0;
                                                    Console.Clear();
                                                }

                                                else if (checkInventoryWeight-WeightOfBoughtPotion < 0)
                                                {
                                                    Console.WriteLine("You can't carry anymore stuff");
                                                    Console.WriteLine("Press 0 to go back");
                                                    int goBack = Convert.ToInt32(Console.ReadLine());
                                                    if (goBack == 0)
                                                        returning = 0;
                                                    Console.Clear();
                                                }

                                                else
                                                {
                                                    double moneyLeft = costOfPotion.SubtractBoughtStuffCostFromMoneyLeft(costOfBoughtPotion);
                                                    int leftWeight = weightCheck.SubtractBoughtStuffWeightFromMaxWeight(WeightOfBoughtPotion);

                                                    Console.WriteLine("Adding the next item to you inventory:");
                                                    Console.WriteLine(readText[chosenNumber]);//text start from 0 index of readText


                                                    var addedItem = new Player.Potion();
                                                    addedItem.BoughtPotion(textWithoutNumber);


                                                    var chosenString = Convert.ToString(chosenNumber);
                                                    chosenString = $"{chosenString}. ";
                                                    var deleteItem = new Store.Potion();//method for deleting bought stuff
                                                    deleteItem.SoldPotionToPlayer(chosenString);

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

                                else if (choise == 3)
                                {
                                    int returning = 0;

                                    while (returning == 0)
                                    {
                                        var weightLeftHeader = new Player.Inventory();
                                        weightLeftHeader.CheckForLeftWeight();

                                        var moneyLeftHeader = new Player.Money();
                                        moneyLeftHeader.CheckForLeftMoney();

                                        Console.WriteLine("----------------------");


                                        var storeWeapon = new Store.Weapon();//check store armor avaibility
                                        storeWeapon.CheckWeaponAvaibility();

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
                                            string weaponList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Store\WeaponList.txt";

                                            Console.Clear();

                                            Console.WriteLine("Are you sure you want to buy this item:");//confirm choise
                                            Console.WriteLine("1. yes");
                                            Console.WriteLine("2. no");

                                            int check = Convert.ToInt32(Console.ReadLine());

                                            if (check == 1)
                                            {
                                                Console.Clear();

                                                string[] readText = File.ReadAllLines(weaponList);
                                                string textWithoutNumber = readText[chosenNumber].Remove(0, 3);

                                                string[] splitForCost = textWithoutNumber.Split(",");
                                                string removedSemicolon = splitForCost[4].Remove(splitForCost[4].Length - 1, 1);
                                                double costOfBoughtWeapon = Convert.ToDouble(removedSemicolon);
                                                var costOfWeapon = new Player.Money();
                                                double checkForLeftMoney = costOfWeapon.LeftMoneyValue();


                                                string[] splitForWeight = textWithoutNumber.Split(",");
                                                int WeightOfBoughtWeapon = Convert.ToInt32(splitForWeight[3]);
                                                var weightCheck = new Player.Inventory();
                                                int checkInventoryWeight = weightCheck.LeftWeightValue();

                                                if (checkForLeftMoney-costOfBoughtWeapon < 0)
                                                {
                                                    Console.WriteLine("You don't have enough money");
                                                    Console.WriteLine("Press 0 to go back");
                                                    int goBack = Convert.ToInt32(Console.ReadLine());
                                                    if (goBack == 0)
                                                        returning = 0;
                                                    Console.Clear();
                                                }

                                                else if (checkInventoryWeight-WeightOfBoughtWeapon < 0)
                                                {
                                                    Console.WriteLine("You can't carry anymore stuff");
                                                    Console.WriteLine("Press 0 to go back");
                                                    int goBack = Convert.ToInt32(Console.ReadLine());
                                                    if (goBack == 0)
                                                        returning = 0;
                                                    Console.Clear();
                                                }

                                                else 
                                                {
                                                    double moneyLeft = costOfWeapon.SubtractBoughtStuffCostFromMoneyLeft(costOfBoughtWeapon);
                                                    int leftWeight = weightCheck.SubtractBoughtStuffWeightFromMaxWeight(WeightOfBoughtWeapon);

                                                    Console.WriteLine("Adding the next item to you inventory:");
                                                    Console.WriteLine(readText[chosenNumber]);//text start from 0 index of readText


                                                    var addedItem = new Player.Weapon();
                                                    addedItem.BoughtWeapon(textWithoutNumber);


                                                    var chosenString = Convert.ToString(chosenNumber);
                                                    chosenString = $"{chosenString}. ";
                                                    var deleteItem = new Store.Weapon();//method for deleting bought stuff
                                                    deleteItem.soldWeaponToPlayer(chosenString);

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

                                else if (choise == 0)
                                {
                                    break;
                                }
                            }
                        }

                        else if (enteredNumber == 7)
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
                                        int entered = Convert.ToInt32(Console.ReadLine());

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

                                                string[] splitForCost = textWithoutNumber.Split(",");
                                                string removedSemicolon = splitForCost[3].Remove(splitForCost[3].Length - 1, 1);
                                                double costOfSoldArmor = Convert.ToDouble(removedSemicolon);
                                                var addCostOfSoldArmor = new Player.Money();
                                                double reducedValue = costOfSoldArmor * 0.8;
                                                addCostOfSoldArmor.AddSoldStuffCostToCurrentMoney(reducedValue);


                                                string [] weightToBeFree = textWithoutNumber.Split(",");//armor weight
                                                int weightOfSoldArmor = Convert.ToInt32(weightToBeFree[2]);
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
                                    int returning = 0;

                                    while (returning == 0)
                                    {
                                        var playerPotion = new Player.Potion();//check player Potion avaibility
                                        playerPotion.CheckPotionAvaibility();

                                        Console.WriteLine("---------");
                                        Console.WriteLine("0. Go back");
                                        int entered = Convert.ToInt32(Console.ReadLine());

                                        if (entered == 0)
                                        {
                                            returning = 1;
                                            returnInt = 0;
                                            Console.Clear();
                                        }

                                        else
                                        {
                                            string potionList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Player\PotionList.txt";

                                            Console.Clear();

                                            Console.WriteLine("Are you sure you want to sell this item:");
                                            Console.WriteLine("1. yes");
                                            Console.WriteLine("2. no");

                                            int check = Convert.ToInt32(Console.ReadLine());


                                            if (check == 1)
                                            {
                                                Console.Clear();

                                                string[] readText = File.ReadAllLines(potionList);

                                                Console.WriteLine("Removing the next item from your inventory:");
                                                Console.WriteLine(readText[entered]);//text start from 0 index of readText

                                                string textWithoutNumber = readText[entered].Remove(0, 3);

                                                var removedItem = new Player.Potion();//methods for deleting sold stuff from Player
                                                var convertedInputToString = Convert.ToString(entered);
                                                removedItem.SoldPotionToStore($"{convertedInputToString}. ");

                                                string[] splitForCost = textWithoutNumber.Split(",");
                                                string removedSemicolon = splitForCost[3].Remove(splitForCost[3].Length - 1, 1);
                                                double costOfSoldPotion = Convert.ToDouble(removedSemicolon);
                                                var addCostOfSoldPotion = new Player.Money();
                                                double reducedValue = costOfSoldPotion * 0.8;
                                                addCostOfSoldPotion.AddSoldStuffCostToCurrentMoney(reducedValue);


                                                string[] weightToBeFree = textWithoutNumber.Split(",");//Potion weight
                                                int weightOfSoldPotion = Convert.ToInt32(weightToBeFree[2]);
                                                var addWeightOfSoldStuff = new Player.Inventory();
                                                addWeightOfSoldStuff.AddSoldStuffWeightToCurrentWeight(weightOfSoldPotion);//remaining weight

                                                var addedItem = new Store.Potion();//method for adding sold stuff to Store
                                                addedItem.boughtPotionFromPlayer(readText[entered]);


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

                                else if (choise ==3)
                                {
                                    int returning = 0;

                                    while (returning == 0)
                                    {
                                        var playerWeapon = new Player.Weapon();//check player Weapon avaibility
                                        playerWeapon.CheckWeaponAvaibility();

                                        Console.WriteLine("---------");
                                        Console.WriteLine("0. Go back");
                                        int entered = Convert.ToInt32(Console.ReadLine());

                                        if (entered == 0)
                                        {
                                            returning = 1;
                                            returnInt = 0;
                                            Console.Clear();
                                        }

                                        else
                                        {
                                            string WeaponList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Player\WeaponList.txt";

                                            Console.Clear();

                                            Console.WriteLine("Are you sure you want to sell this item:");
                                            Console.WriteLine("1. yes");
                                            Console.WriteLine("2. no");

                                            int check = Convert.ToInt32(Console.ReadLine());


                                            if (check == 1)
                                            {
                                                Console.Clear();

                                                string[] readText = File.ReadAllLines(WeaponList);

                                                Console.WriteLine("Removing the next item from your inventory:");
                                                Console.WriteLine(readText[entered]);//text start from 0 index of readText

                                                string textWithoutNumber = readText[entered].Remove(0, 3);

                                                var removedItem = new Player.Weapon();//methods for deleting sold stuff from Player
                                                var convertedInputToString = Convert.ToString(entered);
                                                removedItem.SoldWeaponToStore($"{convertedInputToString}. ");

                                                string[] splitForCost = textWithoutNumber.Split(",");
                                                string removedSemicolon = splitForCost[3].Remove(splitForCost[4].Length, 1);
                                                double costOfSoldWeapon = Convert.ToDouble(removedSemicolon);
                                                var addCostOfSoldWeapon = new Player.Money();
                                                double reducedValue = costOfSoldWeapon * 0.8;
                                                addCostOfSoldWeapon.AddSoldStuffCostToCurrentMoney(reducedValue);


                                                string[] weightToBeFree = textWithoutNumber.Split(",");//Weapon weight
                                                int weightOfSoldWeapon = Convert.ToInt32(weightToBeFree[3]);
                                                var addWeightOfSoldStuff = new Player.Inventory();
                                                addWeightOfSoldStuff.AddSoldStuffWeightToCurrentWeight(weightOfSoldWeapon);//remaining weight

                                                var addedItem = new Store.Weapon();//method for adding sold stuff to Store
                                                addedItem.boughtWeaponFromPlayer(readText[entered]);


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
                            while (returnInt == 0)
                            {

                                Console.WriteLine("What would you like to do");
                                Console.WriteLine("1. Order new potion (potion shipment)");
                                Console.WriteLine("2. Check potion avaibility");
                                Console.WriteLine("0. Go back");

                                checkInt = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (checkInt == 0)
                                    returnToSellerBeginning = 0;

                                if (checkInt == 1)
                                {
                                    var listOfStorePotions = new Store.Potion();
                                    listOfStorePotions.PotionShipment();

                                    Console.WriteLine("0. Go back");

                                    checkInt = Convert.ToInt32(Console.ReadLine());
                                    if (checkInt == 0)
                                        returnInt = 0;

                                    Console.Clear();
                                }

                                else if (checkInt == 2)
                                {
                                    var PotionAvaibility = new Store.Potion();// proveravanje Potiona u prodavnici
                                    PotionAvaibility.CheckPotionAvaibility();

                                    Console.WriteLine("0. Go back");

                                    checkInt = Convert.ToInt32(Console.ReadLine());
                                    if (checkInt == 0)
                                        returnInt = 0;

                                    Console.Clear();

                                }

                                else if (checkInt == 0)
                                {
                                    returnInt = 1;
                                }



                            }
                        }

                        else if (checkInt == 3)
                        {
                            while (returnInt == 0)
                            {

                                Console.WriteLine("What would you like to do");
                                Console.WriteLine("1. Order new weapon (weapon shipment)");
                                Console.WriteLine("2. Check weapon avaibility");
                                Console.WriteLine("0. Go back");

                                checkInt = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (checkInt == 0)
                                    returnToSellerBeginning = 0;

                                if (checkInt == 1)
                                {


                                    var listOfStoreWeapons = new Store.Weapon();
                                    listOfStoreWeapons.WeaponShipment();

                                    Console.WriteLine("0. Go back");

                                    checkInt = Convert.ToInt32(Console.ReadLine());
                                    if (checkInt == 0)
                                        returnInt = 0;

                                    Console.Clear();
                                }

                                else if (checkInt == 2)
                                {
                                    var WeaponAvaibility = new Store.Weapon();// proveravanje Weapona u prodavnici
                                    WeaponAvaibility.CheckWeaponAvaibility();


                                    Console.WriteLine("0. Go back");

                                    checkInt = Convert.ToInt32(Console.ReadLine());
                                    if (checkInt == 0)
                                        returnInt = 0;

                                    Console.Clear();

                                }

                                else if (checkInt == 0)
                                {
                                    returnInt = 1;
                                }



                            }
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
                        var resetArmorListForStore = new Store.Armor();
                        resetArmorListForStore.ResetArmorListStore();

                        var resetPotionListForStore = new Store.Potion();
                        resetPotionListForStore.ResetPotionListStore();

                        var resetWeaponListStore = new Store.Weapon();
                        resetWeaponListStore.ResetWeaponListStore();

                        var resetMaxWeight = new Player.Inventory();
                        resetMaxWeight.ResetMaxWeight();

                        var resetStartingMoney = new Player.Money();
                        resetStartingMoney.ResetStartingMoney();

                        var resetArmorListForPlayer = new Player.Armor();
                        resetArmorListForPlayer.ResetArmorListPlayer();

                        var resetPotionListForPlayer = new Player.Potion();
                        resetPotionListForPlayer.ResetPotionListPlayer();

                        var resetWeaponListPlayer = new Player.Weapon();
                        resetWeaponListPlayer.ResetWeaponListPlayer();
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
    }
}
