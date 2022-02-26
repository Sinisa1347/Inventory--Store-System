using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Player
{
    public class Potion
    {
        //hp potions has name,hp restored,  weight,  price,

        string potionList = "Player/PotionList.txt";

        private string _name;//name
        public string Name { get; set; }

        private int _hpRestored;
        public int HpRestored { get; set; }

        private int _weight;
        public int Weight { get; set; }

        private int _price;
        public int Price { get; set; }


        public void BoughtPotion(string potion)
        {
            string readText = File.ReadAllText(potionList);
            string[] readTextLines = File.ReadAllLines(potionList);
            int numberOfLines = readTextLines.Length;

            if (readText == "")
            {
                File.AppendAllText(potionList, "Name, hp restored(1 - 5), weight(1 - 10), price(1 - ...);\n");
                File.AppendAllText(potionList, $"{numberOfLines + 1}. {potion}\n");
            }
            else
            {
                File.AppendAllText(potionList, $"{numberOfLines}. {potion}\n");

            }
        }

        public void CheckPotionAvaibility()
        {

            var allLines = File.ReadLines(potionList);

            foreach (var line in allLines)
            {
                Console.WriteLine(line);
            }
        }

        public void SoldPotionToStore(string input)//input is input for line number
        {
            string[] readText = File.ReadAllLines(potionList);
            int forLineCount = 0;

            using (StreamWriter sw = new StreamWriter(potionList))
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

        public void ResetPotionListPlayer()
        {
            File.WriteAllText(potionList, "");
        }
    }
}