using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Player
{
    public class Armor
    {
        //armour has defense status, price, weight, name
        string armorList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Player\ArmorList.txt";

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

        public void SetDefenseStatus (int defenseStatus)
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

        public void BoughtArmor(string armor, int counter, bool check)
        {

            //armor.Remove(0, 3);
            //if (counter == 1&& armorList==null)
            

            if (check==true)
            {
                File.AppendAllText(armorList, "Name, defense status(1-5), weight(1-10), price(1-...);\n");// GRESKA JE OVDE-OVO mi izbacuje cak i nakon sto je vec postoji
                File.AppendAllText(armorList, $"{counter}. {armor}\n");
                
            }

            else
            {
                //string withCounter = $"{counter}. {armor}\n";
                File.AppendAllText(armorList, $"{counter}. {armor}\n");

            }

            


            

        }

        public void CheckArmorAvaibility()
        {
            
            var allLines = File.ReadLines(armorList);

            foreach (var line in allLines)
            {
                
                Console.WriteLine(line);
            }
        }

        public void SoldArmorToStore (string input)//input is input for line number
        {
            string[] readText = File.ReadAllLines(armorList);

            int counter = 0;
            //deletes line that is defined by input

            using (StreamWriter sw = new StreamWriter(armorList))
            {
                foreach (var line in readText)
                {
                    if (counter == 0)// first line of text
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
                        string newLine = line.Remove(0, 3);
                        sw.WriteLine($"{counter}. {newLine}");
                        counter++;
                    }
                }
            }



            //string[] lines = File.ReadAllLines(armorList);


            //string stringInput = Convert.ToString(count);


            //using (StreamWriter sw = File.CreateText(armorList))
            //{
            //    foreach (var line in lines)
            //    {


            //        if (count == 0)
            //        {
            //            sw.WriteLine(line);
            //            //count++;
            //        }

            //        else if (lines[input].StartsWith(stringInput))
            //        {
            //            sw.Write("");
            //            //count++;
            //        }
            //        else
            //        {
            //            line.Remove(0, 3);
            //            sw.WriteLine($"{line}");
            //            count++;
            //        }
            //    }


            //}
        }
    }
}
