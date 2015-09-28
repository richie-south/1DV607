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
            Console.Clear();
            Console.WriteLine("1. New member");
            Console.WriteLine("2. Detail list members");
            Console.WriteLine("3. Compact list members");
            Console.WriteLine("4. Exit");
        }

        public int getMenuKeyPress()
        {
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;

                default:
                    return 4;
            }
        }

        public string getInput() {
            return Console.ReadLine();
        }

        public void displayNameInstruktions()
        {
            Console.Clear();
            Console.WriteLine("Input Name");
        }

        public void displaySocialSecurityNumberInstruktions()
        {
            Console.Clear();
            Console.WriteLine("Input SocialSecurityNumber");
        }
    }
}
