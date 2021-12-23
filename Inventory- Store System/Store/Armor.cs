using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Store
{
    public class Armor
    {
        string armorList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Store\ArmorList.txt";

        private string _name;//name

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        private int _defenseStatus;// for defense status

        public void SetDefenseStatus(int defenseStatus)
        {
            _defenseStatus = defenseStatus;
        }

        public int GetDefenseStatus()
        {
            return _defenseStatus;
        }

        private int _weight;//for weight

        public void SetWeight(int weight)
        {
            _weight = weight;
        }

        public int GetWeight()
        {
            return _weight;
        }

        private int _price;// for price

        public void SetPrice(int price)
        {
            _price = price;
        }

        public int GetPrice()
        {
            return _price;
        }

        public void ArmorShipment()
        {
            Console.WriteLine("Please enter added armor:");
            Console.WriteLine("Name, defense status(1-5), weight(1-10), price(1-...)");

            var entered = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(armorList, true))
            {
                sw.WriteLine(entered);
                Console.WriteLine();
            }

        }

        //public void BoughtArmorFromPlayer(string _name, int _defenseStatus, int _weight, int _price)// writing new stuff in armor list
        //{

        //    Console.WriteLine($"Name:{_name},defense status: {_defenseStatus}, weight: {_weight}, price: {_price}");
        //    using (StreamWriter sw = new StreamWriter(armorList))
        //    {
        //        sw.WriteLine($"\nName:{_name},defense status: {_defenseStatus}, weight: {_weight}, price: {_price}\n");
        //    }
        //}

        public void CheckArmorAvaibility()
        {
            int counter = 1;
            var allLines = File.ReadLines(armorList);

            foreach (var line in allLines)
            {
                if (line.Contains("Name, defense status(1-5), weight(1-10), price(1-...);"))
                {
                    Console.WriteLine(line);
                }

                else
                {
                    
                    Console.WriteLine($"{counter}.{line}");
                    counter++;
                }
                
            }
        }


        public void CheckChoise(int chosen1)
        {
            string[] readText = File.ReadAllLines(armorList);

            Console.Write($"{chosen1}.{readText[chosen1]}");
        }

        public void soldArmorToPlayer(int input)// deleting sold armor
        {
            string[] lines = File.ReadAllLines(armorList);
            int count = 0;

            using (StreamWriter sw = File.CreateText(armorList))
            {
                foreach (var line in lines)
                {
                    if (count==0)
                    {
                        sw.WriteLine(line);
                        count++;
                    }
                    
                    else if (count==input)
                    {
                        sw.Write("");
                        count++;
                    }
                    else
                    {
                        sw.WriteLine(line);
                        count++;
                    }
                }
                
               
            }

        }
    }
}
