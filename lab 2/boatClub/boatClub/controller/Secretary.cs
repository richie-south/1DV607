using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub.controller
{
    class Secretary
    {
        private List<model.Member> members = new List<model.Member>();
        private view.ConsoleView consoleView;
        private model.boatClubDAL DAL = new model.boatClubDAL();
        public Secretary(view.ConsoleView c)
        {
            consoleView = c;
            addMembersFromFile();
        }

        public void addMembersFromFile(){

            var membersFromFile = DAL.loadFile();
            foreach (var member in membersFromFile) 
            {
                members.Add(member);
            }
        }

        public void displayStartMenu()
        {
            
            consoleView.displayStartMenu();
            switch (consoleView.getMenuKeyPress())
            {
                case 1:
                    addNewMember();
                    break;
            }
        }
        public void addNewMember()
        {
            consoleView.displayNameInstruktions();
            string name = consoleView.getInput();
            consoleView.displaySocialSecurityNumberInstruktions();
            string nr = consoleView.getInput();

            model.Member member = new model.Member(name, nr);
            members.Add(member);
            DAL.save(members);
        }

        
    }
}
