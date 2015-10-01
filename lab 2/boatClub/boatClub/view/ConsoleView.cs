using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub.view
{
    class ConsoleView
    {
        public void displayStartMenu(){
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============WELCOME==============");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("1. New member");
            Console.WriteLine("2. Detail list members");
            Console.WriteLine("3. Compact list members");
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
                case '5':
                    return 5;
                case '6':
                    return 6;
                default:
                    return 0;
            }
        }

        public void displayBoatUpdateInstructions()
        {
            Console.WriteLine("Select boat to update");
        }

        public string getInput()
        {
            return Console.ReadLine();
        }

        public void displayNameInstruktions()
        {
            Console.WriteLine("Input Name");
        }

        public void displayExeptions(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        public void displaySocialSecurityNumberInstruktions()
        { 
            Console.WriteLine("Input SocialSecurityNumber");
        }

        public void displayCompactList(int i, string name, int memberId, int nrOfBoats)
        {
            Console.WriteLine("{0}.Name:{1}   Member id:{2}   Nr of boats:{3}",i , name, memberId, nrOfBoats);
        }

        public void displaySelectUserInstruktions()
        {
            Console.Write("Select user by typing list nr:");
        }

        public void displaySelectedUser(string name, int memberId, string socialSecurityNr)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=================MEMBER=======================");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("SocialSecurity number: {0}", socialSecurityNr);
            Console.WriteLine("Member id: {0}", memberId);
        }

        public void displayBoat(int listId, string boatType, float boatLength)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("============BOAT==============");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("ListID: {0}", listId);
            Console.WriteLine("Boat type: {0}", boatType);
            Console.WriteLine("Boat length: {0}", boatLength);
        }

        public void displayMemberMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("============MENU==============");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("1. Delete member");
            Console.WriteLine("2. Update memeber");
            Console.WriteLine("3. Add new boat");
            Console.WriteLine("4. Delete boat");
            Console.WriteLine("5. update boat");
        }

        public void displayBackToMenu()
        {
            Console.WriteLine("0. Back to startmenu");
        }

        public void displayMemberChangeMenu()
        {
            Console.WriteLine("Any key to go back");
            Console.WriteLine("1. Change name");
            Console.WriteLine("2. Change Social security number");
            
        }

        public int memberChangeMenuKeyPress()
        {
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                default:
                    return 0;
            }
        }

        public void displayBoatChangeMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("============MENU==============");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Any key to go back");
            Console.WriteLine("1. Change Lenth");
            Console.WriteLine("2. Change Type");

        }

        public int boatChangeMenuKeyPress()
        {
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                default:
                    return 0;
            }
        }

        public bool backToMenuPress()
        {
            return Console.ReadKey().KeyChar == 48;
        }

        public bool ExitProgramPress()
        {
            return Console.ReadKey().KeyChar == 4;
        }

        public int memberMenuKeyPress()
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
                    return 0;
            }
        }

        public void displayBoatLenghtInstruktions()
        {
            Console.WriteLine("Input boat length");
        }

        public void displayDeleteBoatInstruktions()
        {
            Console.WriteLine("Select the boat listID");
        }

        public void displayBoatTypeInstruktions()
        {
            Console.WriteLine("Select boat type nr");
        }
        public void displayBoatTypes(int id, string boatType)
        {
            Console.WriteLine("{0}. {1}", id, boatType);
        }
        public void clear()
        {
            Console.Clear();
        }

    }
}
