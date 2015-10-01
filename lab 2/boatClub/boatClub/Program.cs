using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub
{
    class Program
    {
        //Starting up the program
        //Display the startmenu as long as the user dosent exit the program with x-button
        static void Main(string[] args)
        {

            view.ConsoleView c = new view.ConsoleView();
            controller.Secretary s = new controller.Secretary(c);
            do
            {
                s.displayStartMenu();
            } while (true);
        }
    }
}
