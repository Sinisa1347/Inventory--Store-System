using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Player
{
    internal class Potion
    {
        //hp potions has name,hp restored,  weight,  price,

        string potionList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Player\PotionList.txt";

        private string _name;//name

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        private int _hpRestored;// for hp restored

        public void SetDefenseStatus(int hpRestored)
        {
            _hpRestored = hpRestored;
        }

        public int GetDefenseStatus()
        {
            return _hpRestored;
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

        public void BoughtPotion(string _name, int _hpRestored, int _weight, int _price)
        {

            Console.WriteLine($"Name:{_name},HP restored: {_hpRestored}, weight: {_weight}, price: {_price}");
            using (StreamWriter sw = new StreamWriter(potionList))
            {
                sw.WriteLine($"\nName:{_name},HP restored: {_hpRestored}, weight: {_weight}, price: {_price}\n");
            }
        }

        public void CheckPotion()
        {
            using (StreamReader sr = new StreamReader(potionList))
            {
                Console.WriteLine(sr.ReadToEnd());

            }
        }

        public void SoldPotion(string _name, int _hpRestored, int _weight, int _price)
        {

            Console.WriteLine($"Name:{_name},HP restored: {_hpRestored}, weight: {_weight}, price: {_price}");
            using (StreamReader sr = new StreamReader(potionList))
            {
                string armourList = sr.ToString();
                if (potionList.Contains($"Name:{_name},HP restored: {_hpRestored}, weight: {_weight}, price: {_price}"))
                {
                    armourList.Replace($"Name:{_name},HP restored: {_hpRestored}, weight: {_weight}, price: {_price}", "\b");
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }


    }
}
