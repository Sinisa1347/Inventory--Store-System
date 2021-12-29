using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Store
{
    public class Weapon
    {
        string weaponList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Store\WeaponList.txt";

        private string _name;//name

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        private int _damageOutput;// for damage output

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

        public void WeaponShipment()
        {
            string[] readTextLines = File.ReadAllLines(weaponList);
            int numberOfLines = readTextLines.Length;

            Console.WriteLine("Please enter added weapon:");
            Console.WriteLine("Name, damage output(1 - 5), effective range(1-5), weight(1 - 10), price(1 - ...)");
            Console.WriteLine("Press 0 if you have changed you mind");
            var readText = Console.ReadLine();

            if (numberOfLines == 0)
            {
                File.AppendAllText(weaponList, "Name, damage output(1 - 5), effective range(1-5), weight(1 - 10), price(1 - ...)\n");
                File.AppendAllText(weaponList, $"{numberOfLines + 1}. {readText};\n");
            }

            else if (numberOfLines > 0)
            {
                File.AppendAllText(weaponList, $"{numberOfLines}. {readText};\n");

            }

            else if (readText == "0")
            {
                File.AppendAllText(weaponList, "");
            }


        }

        public void CheckWeaponAvaibility()
        {
            var allLines = File.ReadLines(weaponList);

            foreach (var line in allLines)
            {
                Console.WriteLine(line);
            }
        }


        public void CheckChoise(int chosen1)
        {
            string[] readText = File.ReadAllLines(weaponList);

            Console.Write($"{chosen1}. {readText[chosen1]}");
        }

        public void soldWeaponToPlayer(string input)// deleting sold Weapon
        {
            string[] readText = File.ReadAllLines(weaponList);
            int forLineCount = 0;

            using (StreamWriter sw = new StreamWriter(weaponList))
            {
                foreach (var line in readText)
                {
                    if (forLineCount == 0)
                    {
                        sw.WriteLine(line);
                        forLineCount++;
                    }

                    else if (line.Contains(input))
                    {
                        sw.Write("");
                    }
                    else
                    {
                        string newLine = line.Remove(0, 3);
                        sw.WriteLine($"{forLineCount}. {newLine}");
                        forLineCount++;
                    }
                }
            }
        }

        public void boughtWeaponFromPlayer(string weapon)
        {
            string[] readText = File.ReadAllLines(weaponList);
            int numberOfLines = readText.Length;

            string newWeapon = weapon.Remove(0, 3);

            string withCounter = $"{numberOfLines}. {newWeapon}\n";

            File.AppendAllText(weaponList, withCounter);

        }

        public void ResetWeaponListStore()
        {
            string textToReset = "Name, damage output(1 - 5), effective range(1 - 5), weight(1 - 10), price(1 - ...);\n1. Heavy sword,5,4,8,15;\n2. Swift sword, 2,3,4,10;\n3. Light sword,3,3,5,12;\n4. Mace, 5,3,7,13;\n5. Dagger, 3,1,3,8;\n";//add default values


            File.WriteAllText(weaponList, textToReset);
        }
    }
}