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

        public void BoughtArmor(string armor,int counter)
        {
            
            string withCounter = $"\n{counter}. {armor}";
            
            File.AppendAllText (armorList, withCounter);
            


        }

            //if (readText[counter].Contains("Name, defense status(1-5), weight(1-10), price(1-...);"))
            //{
            //    sw.WriteLine(readText[counter]);
            //    counter++;
            //}

            //else
            //{
            //    sw.WriteLine($"{counter}. {armor}");
            //    counter++;
            //}

        


            //foreach (var line in allLines)
            //{
            //    if (line.Contains("Name, defense status(1-5), weight(1-10), price(1-...);"))
            //    {
            //        Console.WriteLine(line);
            //    }

            //    else
            //    {

            //        Console.WriteLine($"{counter}.{line}");
            //        counter++;
            //    }


        public void CheckArmor()
        {
            using (StreamReader sr = new StreamReader(armorList))
            {
                Console.WriteLine(sr.ReadToEnd());
                
            }
        }


        //public void SoldArmor(string _name, int _defenseStatus, int _weight, int _price)
        //{

        //    Console.WriteLine($"Name:{_name},defense status: {_defenseStatus}, weight: {_weight}, price: {_price}");
        //    using (StreamReader sr = new StreamReader(armorList))
        //    {
        //        string armourList = sr.ToString();
        //        if (armorList.Contains($"Name:{_name},defense status: {_defenseStatus}, weight: {_weight}, price: {_price}"))
        //        {
        //            armourList.Replace($"Name:{_name},defense status: {_defenseStatus}, weight: {_weight}, price: {_price}", "\b");
        //        }
        //        else
        //        {
        //            Console.WriteLine("");
        //        }
        //    }
        //}


    }
}
