using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Player
{
    public class Money
    {
        private double moneyLeft =40;

        string moneyLeftFile = "MoneyLeft.txt";

        public void CheckForLeftMoney()
        {
            if (File.ReadAllText(moneyLeftFile) == "")
            {
                File.AppendAllText(moneyLeftFile, $"{moneyLeft}");
                Console.WriteLine($"Current money is  {moneyLeft}");
            }
            else
            {
                double leftMoney = Convert.ToDouble(File.ReadAllText(moneyLeftFile));
                Console.WriteLine($"Left money is: {leftMoney}");

            }
        }

        public double LeftMoneyValue ()
        {
            double readMoneyValue= Convert.ToDouble(File.ReadAllText(moneyLeftFile));
            return readMoneyValue;
        }

        public double SubtractBoughtStuffCostFromMoneyLeft(double stuffCost)
        {
            double leftMoney = Convert.ToDouble(File.ReadAllText(moneyLeftFile));
            double updatedMoney = leftMoney - stuffCost;

            if (updatedMoney < 0)
            {
                File.WriteAllText(moneyLeftFile, $"{leftMoney}");
                return -1;
            }
            else
            {
                File.WriteAllText(moneyLeftFile, $"{updatedMoney}");
                return Convert.ToInt32(updatedMoney);
            }
        }

        public void AddSoldStuffCostToCurrentMoney(double soldStuffCost)
        {
            double leftMoney = Convert.ToDouble(File.ReadAllText(moneyLeftFile));
            string updatedMoney = Convert.ToString(leftMoney + soldStuffCost);

            File.WriteAllText(moneyLeftFile, updatedMoney);
        }

        public void ResetStartingMoney()
        {
            string startingMoney = "40";
            File.WriteAllText(moneyLeftFile, startingMoney);
        }
    }
}
