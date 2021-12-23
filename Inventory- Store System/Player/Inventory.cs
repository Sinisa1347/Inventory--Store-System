using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory__Store_System.Player
{
    public class Inventory
    {
        private int _maxWeight = 30;

        public void SetMaxWeight (int maxWeight)
        {
            _maxWeight = maxWeight;
        }
        public int GetMaxWeight()
        {
            return _maxWeight;
        }

        public void Check()
        {
            if (_maxWeight == 0)
            {
                Console.WriteLine("You can't add anymore stuff to your invenotory");
                Console.WriteLine("Please sell something to continue");
                
            }
            else
            {
                Console.WriteLine($"Avaible weight left {_maxWeight}");
            }
        }




    }
}
