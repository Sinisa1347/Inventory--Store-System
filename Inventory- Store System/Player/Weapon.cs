using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Player
{
    internal class Weapon
    {
        //weapons have name, damage output, effective range,  weight, price,

        string weaponList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Player\WeaponList.txt";

        private string _name;//name

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        private int _damageOutput;// for defense status

        public void SetDefenseStatus(int damageOutput)
        {
            _damageOutput = damageOutput;
        }

        public int GetDefenseStatus()
        {
            return _damageOutput;
        }

        private int _effectiveRange;//for effective range

        public void SetEffectiveRange(int effectiveRange)
        {
            _effectiveRange = effectiveRange;
        }

        public int GetEffectiveRange()
        {
            return _effectiveRange;
        }

        private int _weight;// for weight

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

        public void BoughtWeapon(string _name, int _damageOutput, int _effectiveRange, int _weight, int _price)
        {
            Console.WriteLine($"Name:{_name},damge output: {_damageOutput}, effective range: {_effectiveRange}, weight: {_weight}, price { _price}");
            using (StreamWriter sw = new StreamWriter(weaponList))
            {
                sw.WriteLine($"\nName:{_name},damge output: {_damageOutput}, effective range: {_effectiveRange}, weight: {_weight}, price { _price}");
            }
        }

        public void CheckWeapon()
        {
            using (StreamReader sr = new StreamReader(weaponList))
            {
                Console.WriteLine(sr.ReadToEnd());

            }
        }

        public void SoldWeapon(string _name, int _damageOutput, int _effectiveRange, int _weight, int _price)
        {
            Console.WriteLine($"Name:{_name},damge output: {_damageOutput}, effective range: {_effectiveRange}, weight: {_weight}, price { _price}");
            using (StreamReader sr = new StreamReader(weaponList))
            {
                string armourList = sr.ToString();
                if (weaponList.Contains($"Name:{_name},damge output: {_damageOutput}, effective range: {_effectiveRange}, weight: {_weight}, price { _price}"))
                {
                    armourList.Replace($"Name:{_name},damge output: {_damageOutput}, effective range: {_effectiveRange}, weight: {_weight}, price { _price}","\b");
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }


    }
}
