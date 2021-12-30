﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Player
{
    public class Receipt
    {
        string receiptLocation = @"C:\Downloads\## UNITY I GIT\Inventory (Player)-Store System\Inventory- Store System\Inventory- Store System\Player\Receipt.txt";

        public void AddSoldItemToReceipt(string soldItem)
        {
            string readReceipt = File.ReadAllText(receiptLocation);
            
            if (readReceipt == "")
            {
                File.AppendAllText(receiptLocation, "Receipt:\n");
                File.AppendAllText(receiptLocation, $"- {soldItem}\n");
            }

            else
            {
                File.AppendAllText(receiptLocation, $"- {soldItem}\n");
            }
        }

        public void AddBoughtItemToReceipt(string soldItem)
        {
            string readReceipt = File.ReadAllText(receiptLocation);

            if (readReceipt == "")
            {
                File.AppendAllText(receiptLocation, "Receipt:\n");
                File.AppendAllText(receiptLocation, $"+ {soldItem}\n");
            }

            else
            {
                File.AppendAllText(receiptLocation, $"+ {soldItem}\n");
            }
        }



        public string[] CheckReceipt()
        {
            string [] receiptsLines=File.ReadAllLines(receiptLocation);
            return receiptsLines;

        }

        public void ResetReceipt()
        {
            File.WriteAllText(receiptLocation, "");
        }
    }
}
