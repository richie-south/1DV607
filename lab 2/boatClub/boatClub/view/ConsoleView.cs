using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub.view
{
    class ConsoleView
    {

        public void displayStartMenu(){
            Console.WriteLine("1. New member");
            Console.WriteLine("2. Detail list members");
            Console.WriteLine("3. Compact list members");
            Console.WriteLine("4. Exit");
        }
    }
}
