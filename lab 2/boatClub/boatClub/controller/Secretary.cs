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
                case 3:
                    compactList();
                    break;
            }
        }
        public void addNewMember()
        {
            consoleView.displayNameInstruktions();
            string name = consoleView.getInput();
            consoleView.displaySocialSecurityNumberInstruktions();
            string nr = consoleView.getInput();

            model.Member member = new model.Member(name, nr, members.Count);
            members.Add(member);
            DAL.save(members);
        }

        public void compactList()
        {
            int i = 0;
            foreach (var member in members)
            {
                
                consoleView.displayCompactList(i, member.Name, member.Id, member.Boats.Count);
                i++;
            }
            consoleView.displaySelectUserInstruktions();
            int selectedUser = int.Parse(consoleView.getInput());
            specificUser(selectedUser);

        }

        public void specificUser(int userLocation)
        {
            var member = members.ElementAt(userLocation);
            consoleView.displaySelectedUser(member.Name, member.Id, member.SocialSecurityNumber);
            showUserBoats(member);
            displayMemberMenu(member);
        }
        public void displayMemberMenu(model.Member member)
        {
            consoleView.displayMemberMenu();
            switch (consoleView.getMenuKeyPress())
            {
                case 1:
                    deleteMember(member);
                    break;
                case 2:
                    addNewBoat(member);
                    break;
                case 3:
                    deleteMemberBoat(member);
                    break;
                case 4:
                    displayStartMenu();
                    break;
            }
        }

        public void deleteMember(model.Member member)
        {
            members.Remove(member);
            DAL.save(members);
        }

        public void deleteMemberBoat(model.Member member)
        {
            consoleView.clear();
            showUserBoats(member);
            consoleView.displayDeleteBoatInstruktions();
            int listId = int.Parse(consoleView.getInput());
            member.deleteBoat(listId);
            
        }
        public void addNewBoat(model.Member member)
        {
            consoleView.displayBoatLenghtInstruktions();
            float length = float.Parse(consoleView.getInput());
            consoleView.displayBoatTypeInstruktions();

            showBoatType();

            var boatType = Enum.ToObject(typeof(model.Boat.BoatType), int.Parse(consoleView.getInput()));
            model.Boat boat = new model.Boat((model.Boat.BoatType)boatType, length);

            member.addBoat(boat); 
            DAL.save(members);
        }
        public void showBoatType()
        {
            int id = 0;
            foreach (var boat in Enum.GetValues(typeof(model.Boat.BoatType)))
            {
                consoleView.displayBoatTypes(id, Enum.GetName(typeof(model.Boat.BoatType), boat));
                id++;
            }
        }

        public void showUserBoats(model.Member member)
        {
            int id = 0;
            foreach (var boat in member.Boats)
            {
                consoleView.displayBoat(id, Enum.GetName(typeof(model.Boat.BoatType), boat.BoatTypeProp), boat.BoatLenght);
                id++;
            }
        }
    }
}
