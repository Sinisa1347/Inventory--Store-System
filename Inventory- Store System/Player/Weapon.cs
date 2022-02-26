using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Player
{
    public class Weapon
    {
        //weapons have name, damage output, effective range,  weight, price,

        

        string weaponList = "Player/WeaponList.txt";

        private string _name;//name
        public string Name { get; set; }


        private int _damageOutput;// for damage output
        public int DamageOutput { get; set; }


        private int _effectiveRange;//for effective range
        public int EffextiveRange { get; set; }


        private int _weight;// for weight
        public int Weight { get; set; }


        private int _price;// for price
        public int Price { get; set; }


        public void BoughtWeapon(string weapon)
        {
            string readText = File.ReadAllText(weaponList);
            string[] readTextLines = File.ReadAllLines(weaponList);
            int numberOfLines = readTextLines.Length;

            if (readText == "")
            {
                File.AppendAllText(weaponList, "Name, damage output(1 - 5), effective range(1-5), weight(1 - 10), price(1 - ...);\n");
                File.AppendAllText(weaponList, $"{numberOfLines + 1}. {weapon}\n");
            }
            else
            {
                File.AppendAllText(weaponList, $"{numberOfLines}. {weapon}\n");

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

        public void SoldWeaponToStore(string input)//input is input for line number
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

        public void ResetWeaponListPlayer()
        {
            File.WriteAllText(weaponList, "");
        }
    }
}