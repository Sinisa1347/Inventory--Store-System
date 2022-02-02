using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Player
{
    
    
    public class Inventory
    {
        private int maxWeight = 20;
        
        string inventoryWeightLeft = "Player/InventoryWeightLeft.txt";

        public int CheckForLeftWeight()
        {
            //int i = 0;
            ////using (FileStream stream = File.Open("C:\\Downloads\\## UNITY I GIT\\InventoryStoreProject\\Inventory- Store System\\Player\\InventoryWeightLeft.txt", FileMode.Open))
            //using (FileStream stream = File.Open(".\\..\\..\\..\\Player\\InventoryWeightLeft.txt", FileMode.Open))
            //{
            //    StreamReader reader = new StreamReader(stream);
            //    int a = reader.Read();
            //    Console.WriteLine(a);
            //    i = a;
            //}

            //return i;
            
            //using (BinaryWriter writer = new BinaryWriter(stream))
            //{
            //    writer.Write(303);
            //    writer.Write(720);
            //}

            if (File.ReadAllText(inventoryWeightLeft)=="")
            {
                File.AppendAllText(inventoryWeightLeft, $"{maxWeight}");
                Console.WriteLine($"Current weight is  {maxWeight}");
                return maxWeight;
            }
            else
            {
                int leftWeight = Convert.ToInt32(File.ReadAllText(inventoryWeightLeft));
                Console.WriteLine($"Left weight is: {leftWeight}");
                return leftWeight;

            }
        }

        public int LeftWeightValue ()
        {
            int leftWeightValue = Convert.ToInt32(File.ReadAllText(inventoryWeightLeft));
            return leftWeightValue;
        }

        public int SubtractBoughtStuffWeightFromMaxWeight (int boughStuffWeight)
        {
            int leftWeight = Convert.ToInt32(File.ReadAllText(inventoryWeightLeft));
            int updatedWeight = leftWeight - boughStuffWeight;

            if (updatedWeight<0)
            {
                File.WriteAllText(inventoryWeightLeft, $"{leftWeight}");
                return -1;
            }
            else
            {
                File.WriteAllText(inventoryWeightLeft, $"{updatedWeight}");
                return Convert.ToInt32(updatedWeight);
            }
        }

        public void AddSoldStuffWeightToCurrentWeight (int soldStuffWeight)
        {
            int leftWeight = Convert.ToInt32(File.ReadAllText(inventoryWeightLeft));
            string updatedWeight = Convert.ToString(leftWeight + soldStuffWeight);

            File.WriteAllText(inventoryWeightLeft, updatedWeight);
        }

        public void ResetMaxWeight()
        {
            string maxWeightString = "20";
            File.WriteAllText(inventoryWeightLeft, maxWeightString);
        }

    }  



}
