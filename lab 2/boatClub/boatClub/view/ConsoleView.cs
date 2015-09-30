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

        public void displayCompactList(int i, string name, int memberId, int nrOfBoats)
        {
            Console.WriteLine("{0}.  Name:{1}    Member id:{2}    Nr of boats:{3}",i , name, memberId, nrOfBoats);
        }

        public void displaySelectUserInstruktions()
        {
            Console.Write("Select user by typing list nr:");
        }

        public void displaySelectedUser(string name, int memberId, string socialSecurityNr)
        {
            Console.Clear();
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("SocialSecurity number: {0}", socialSecurityNr);
            Console.WriteLine("Member id: {0}", memberId);
        }

        public void displayBoat(int listId, string boatType, float boatLength)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("ListID: {0}", listId);
            Console.WriteLine("Boat type: {0}", boatType);
            Console.WriteLine("Boat length: {0}", boatLength);
        }

        public void displayMemberMenu()
        {
            Console.WriteLine("1. Delete member");
            Console.WriteLine("2. Add new boat");
            Console.WriteLine("3. Delete boat");
            Console.WriteLine("4. Back to startmenu");
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
                    return 4;
            }
        }

        public void displayBoatLenghtInstruktions()
        {
            Console.Clear();
            Console.WriteLine("Input boat length");
        }
        public void displayDeleteBoatInstruktions()
        {
            Console.WriteLine("Select the boat listID");
        }

        public void displayBoatTypeInstruktions()
        {
            Console.Clear();
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
