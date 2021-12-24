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

        public void ArmorShipment(int counter)
        {
            Console.WriteLine("Please enter added armor:");
            Console.WriteLine("Name, defense status(1-5), weight(1-10), price(1-...)");
            
            var entered = Console.ReadLine();
            var emptyText = File.ReadAllLines(armorList);
            

            //int lineCounter = 0;

            //File.AppendAllText(armorList,startingText);

                if (counter==1)
                {
                    File.AppendAllText(armorList, "Name, defense status(1-5), weight(1-10), price(1-...);\n");
                    File.AppendAllText(armorList, $"{counter}. {entered}\n");
                }

                else
                {
                    File.AppendAllText(armorList, $"{counter}. {entered}\n");
                    
                }
        }

        public void CheckArmorAvaibility()
        {
            //int counter = 1;
            var allLines = File.ReadLines(armorList);

            foreach (var line in allLines)
            {
                //line.Remove(0, 3);
                Console.WriteLine(line);
            }
        }


        public void CheckChoise(int chosen1)
        {
            string[] readText = File.ReadAllLines(armorList);

            Console.Write($"{chosen1}. {readText[chosen1]}");
        }

        public void soldArmorToPlayer(string input)// deleting sold armor
        {
            string[] readText = File.ReadAllLines(armorList);

            int counter = 0;
            //deletes line that is defined by input

            using (StreamWriter sw = new StreamWriter(armorList))
            {
                foreach (var line in readText)
                {
                    if (counter==0)// first line of text
                    {
                        sw.WriteLine(line);
                        counter++;
                    }
                
                    else if (line.Contains(input))//line to remove
                    {
                        sw.Write("");
                    }
                    else
                    {
                        string newLine=line.Remove(0, 3);
                        sw.WriteLine($"{counter}. {newLine}");
                        counter++;
                    }
                }
            }
        }

        public void boughtArmorFromPlayer (string armor, int counter)
        {
            
            
            string newArmor=armor.Remove(0, 3);
            
            string withCounter = $"{counter}. {newArmor}\n";

            File.AppendAllText(armorList, withCounter);

        }
    }
}
