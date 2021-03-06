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
        string armorList = "Store/ArmorList.txt";

        private string _name;
        public string Name { get; set; }


        private int _defenseStatus;
        public int DefenseStatus { get; set; }


        private int _weight;
        public int Weight { get; set; }


        private int _price;
        public int Price { get; set; }


        public void ArmorShipment()
        {
            string[] readTextLines = File.ReadAllLines(armorList);
            int numberOfLines = readTextLines.Length;

            Console.WriteLine("Please enter added armor:");
            Console.WriteLine("Name, defense status(1-5), weight(1-10), price(1-...)");
            Console.WriteLine("Press 0 if you have changed you mind");
            var readText = Console.ReadLine();

            if (readText == "0")
            {
                File.AppendAllText(armorList, "");
            }

            else if (numberOfLines == 0)
            {
                File.AppendAllText(armorList, "Name, defense status(1-5), weight(1-10), price(1-...);\n");
                File.AppendAllText(armorList, $"{numberOfLines + 1}. {readText};\n");
            }
            
            else if (numberOfLines > 0)
            {
                File.AppendAllText(armorList, $"{numberOfLines}. {readText};\n");

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


        public void CheckChoise(int chosen1)
        {
            string[] readText = File.ReadAllLines(armorList);

            Console.Write($"{chosen1}. {readText[chosen1]}");
        }

        public void soldArmorToPlayer(string input)// deleting sold armor
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

        public void boughtArmorFromPlayer (string armor)
        {
            string[] readText = File.ReadAllLines(armorList);
            int numberOfLines = readText.Length;

            string newArmor=armor.Remove(0, 3);
            
            string withCounter = $"{numberOfLines}. {newArmor}\n";

            File.AppendAllText(armorList, withCounter);

        }

        public void ResetArmorListStore()
        {
            string textToReset = "Name, defense status(1-5), weight(1-10), price(1-...)\n1. Heavy armor,5,9,20;\n2. Light armor,3,6,15;\n3. Thiefs armor,2,4,10;\n4. Knight's armor,5,10,25;";


            File.WriteAllText(armorList, textToReset);
        }
    }
}
