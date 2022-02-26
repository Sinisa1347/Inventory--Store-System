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
        string armorList = "Player/ArmorList.txt";
        

        private string _name;
        public string Name { get; set; }


        private int _defenseStatus;
        public int DefenseStatus { get; set; }



        private int _weight;
        public int Weight { get; set; }



        private int _price;
        public int Price { get; set; }



        public void BoughtArmor(string armor)
        {
            string readText = File.ReadAllText(armorList);
            string[] readTextLines = File.ReadAllLines(armorList);
            int numberOfLines = readTextLines.Length;

            if (readText=="")
            {
                File.AppendAllText(armorList, "Name, defense status(1 - 5), weight(1 - 10), price(1 - ...);\n");
                File.AppendAllText(armorList, $"{numberOfLines+1}. {armor}\n");
            }
            else
            {
                File.AppendAllText(armorList, $"{numberOfLines}. {armor}\n");
                
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
            int forLineCount = 0;

            using (StreamWriter sw = new StreamWriter(armorList))
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

        public void ResetArmorListPlayer ()
        {
            File.WriteAllText(armorList, "");
        }
    }
}
