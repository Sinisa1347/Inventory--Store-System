using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Store
{
     public class Potion
    {
            string potionList = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Store\PotionList.txt";

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

            public void PotionShipment()
            {
                string[] readTextLines = File.ReadAllLines(potionList);
                int numberOfLines = readTextLines.Length;

                Console.WriteLine("Please enter added potion:");
                Console.WriteLine("Name, hp restored(1 - 3), weight(1 - 10), price(1 - ...);");
                Console.WriteLine("Press 0 if you have changed you mind");
                var readText = Console.ReadLine();

                if (numberOfLines == 0)
                {
                    File.AppendAllText(potionList, "Name, hp restored(1 - 3), weight(1 - 10), price(1 - ...);\n");
                    File.AppendAllText(potionList, $"{numberOfLines + 1}. {readText};\n");
                }

                else if (numberOfLines > 0)
                {
                    File.AppendAllText(potionList, $"{numberOfLines}. {readText};\n");

                }

                else if (readText == "0")
                {
                    File.AppendAllText(potionList, "");
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


            public void CheckChoise(int chosen1)
            {
                string[] readText = File.ReadAllLines(potionList);

                Console.Write($"{chosen1}. {readText[chosen1]}");
            }

            public void SoldPotionToPlayer(string input)// deleting sold potion
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

            public void boughtPotionFromPlayer(string potion)
            {
                string[] readText = File.ReadAllLines(potionList);
                int numberOfLines = readText.Length;

                string newPotion = potion.Remove(0, 3);

                string withCounter = $"{numberOfLines}. {newPotion}\n";

                File.AppendAllText(potionList, withCounter);

            }

            public void ResetPotionListStore()
            {
                string textToReset = "Name, hp restored(1 - 3), weight(1 - 10), price(1 - ...);\n1. Small health potion,1,3,4;\n2. Medium health potion,2,5,7;\n3. Big potion,3,7,10;\n";
                File.WriteAllText(potionList, textToReset);
            }
     }

}
