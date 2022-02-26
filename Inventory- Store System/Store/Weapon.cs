using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inventory__Store_System.Store
{
    public class Weapon
    {
        string weaponList = "Store/WeaponList.txt";

        private string _name;
        public string Name { get; set; }



        private int _damageOutput;
        public int DamageOutput { get; set; }


        private int _effectiveRange;
        public int EffectiveRange { get; set; }


        private int _weight;
        public int Weight { get; set; }



        private int _price;
        public int Price { get; set; }



        public void WeaponShipment()
        {
            string[] readTextLines = File.ReadAllLines(weaponList);
            int numberOfLines = readTextLines.Length;

            Console.WriteLine("Please enter added weapon:");
            Console.WriteLine("Name, damage output(1 - 5), effective range(1-5), weight(1 - 10), price(1 - ...)");
            Console.WriteLine("Press 0 if you have changed you mind");
            var readText = Console.ReadLine();

            if (readText == "0")
            {
                File.AppendAllText(weaponList, "");
            }


            else if (numberOfLines == 0)
            {
                File.AppendAllText(weaponList, "Name, damage output(1 - 5), effective range(1-5), weight(1 - 10), price(1 - ...)\n");
                File.AppendAllText(weaponList, $"{numberOfLines + 1}. {readText};\n");
            }

            else if (numberOfLines > 0)
            {
                File.AppendAllText(weaponList, $"{numberOfLines}. {readText};\n");

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