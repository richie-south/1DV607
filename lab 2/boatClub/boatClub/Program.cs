using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub
{
    class Program
    {
        static void Main(string[] args)
        {

            view.ConsoleView c = new view.ConsoleView();
            controller.Secretary s = new controller.Secretary(c);
            
            s.displayStartMenu();
            //c.displayStartMenu();

        }
    }
}
