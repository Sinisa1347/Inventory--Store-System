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

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        private int _hpRestored;// for hp restored

        public void SetHpRestored(int hpRestored)
        {
            _hpRestored = hpRestored;
        }

        public int GetHpRestored()
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