using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub.controller
{
    class Secretary
    {
        //List with members
        //consturctor creating instance of view
        //private List<model.Member> members = new List<model.Member>();
        private view.ConsoleView consoleView;
        private model.boatClubDAL DAL = new model.boatClubDAL();
        private model.GenerateID generateId = new model.GenerateID();
        public Secretary(view.ConsoleView c)
        {
            consoleView = c;
            addMembersFromFile();
        }

        //takeing the saved members in the file and pushing them to the array
        private void addMembersFromFile(){
            DAL.loadFile();
        }

        //showing the first menu (Add new member, detaildlist, complatlist)
        public void displayStartMenu()
        {
            consoleView.clear();
            consoleView.displayStartMenu();
            switch (consoleView.getMenuKeyPress())
            {
                case 1:
                    addNewMember();
                    break;
                case 2:
                    detaildList();
                    break;
                case 3:
                    compactList();
                    break;

            }
        }

        //showing members and their boats
        private void detaildList()
        {
            consoleView.clear();
            foreach (var member in DAL.Members)
            {
                consoleView.displaySelectedUser(member.Name, member.Id, member.SocialSecurityNumber);
                showUserBoats(member);
            }
            consoleView.displayBackToMenu();
            if (consoleView.backToMenuPress())
            {
                displayStartMenu();
            }
        }

        //creating new member, calling to display instructions
        //try-catch for exeptions with the name and securitynumber
        //saving the list to the bin-file
        private void addNewMember()
        {
            consoleView.clear();
            consoleView.displayNameInstruktions();
            string name = consoleView.getInput();
            consoleView.clear();
            consoleView.displaySocialSecurityNumberInstruktions();
            string SecurityNumber = consoleView.getInput();

            int uniqeId = generateId.newId(DAL.Members);
            try
            {
                model.Member member = new model.Member(name, SecurityNumber, uniqeId);
                DAL.addMember(member);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }
        
        //user can select a member and see more information
        //showing all members and nr of boats they own
        private void compactList()
        {
            consoleView.clear();
            
            int i = 0;
            foreach (var member in DAL.Members)
            {
                
                consoleView.displayCompactList(i, member.Name, member.Id, member.Boats.Count);
                i++;
            }
            consoleView.displaySelectUserInstruktions();
            
            int selectedUser = 0;
            try
            {
                selectedUser = int.Parse(consoleView.getInput());
                specificUser(selectedUser);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());

                consoleView.displayBackToMenu();
                if (consoleView.backToMenuPress())
                {
                   displayStartMenu();
                }
                else
                {
                    compactList();
                }
            }
        }

        //when specific member is choosen this members information is shown
        //a membermenu is shown to offer the user to: change/delete member/boats and add new boat to the member
        private void specificUser(int memberLocation)
        {
            var member = DAL.Members.First();
            try
            {
                member = DAL.getSpecificMember(memberLocation);
            }
            catch (Exception e)
            {
                throw;
            }
            consoleView.clear();
            consoleView.displaySelectedUser(member.Name, member.Id, member.SocialSecurityNumber);
            showUserBoats(member);
            displayMemberMenu(memberLocation);
        }

        //the menu that offers to the user to: change/delete member/boats and add new boat to the member
        private void displayMemberMenu(int memberLocation)
        {
            consoleView.displayMemberMenu();
            switch (consoleView.getMenuKeyPress())
            {
                case 1:
                    deleteMember(memberLocation);
                    break;
                case 2:
                    updateMember(memberLocation);
                    break;
                case 3:
                    addNewBoat(memberLocation);
                    break;
                case 4:
                    deleteMemberBoat(memberLocation);
                    break;
                case 5:
                    updateBoat(memberLocation);
                    break;
                case 6:
                    displayStartMenu();
                    break;
            }
        }

        //updating the boat, showing the instructions
        //letting the user decide which boat to update
        private void updateBoat(int memberLocation)
        {
            consoleView.clear();
            showUserBoats(DAL.getSpecificMember(memberLocation));
            consoleView.displayBoatUpdateInstructions();
            int boatLocation;
            try
            {
                boatLocation = int.Parse(consoleView.getInput());
                updateBoatMenu(memberLocation, boatLocation);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }

        //Menu letting the user choose what they want to change
        private void updateBoatMenu(int memberLocation, int boatLocation)
        {
            consoleView.displayBoatChangeMenu();
            switch (consoleView.boatChangeMenuKeyPress())
            {
                case 1:
                    updateBoatLength(memberLocation, boatLocation);
                    break;
                case 2:
                    updateBoatType(memberLocation, boatLocation);
                    break;
            }
        }

        //changing the boat type and saving new information
        private void updateBoatType(int memberLocation, int boatLocation)
        {
            consoleView.clear();
            consoleView.displayBoatTypeInstruktions();
            showBoatType();
            try
            {
                int value = int.Parse(consoleView.getInput());
                var boatType = Enum.ToObject(typeof(model.Boat.BoatType), value);
                DAL.updateBoatType(memberLocation, boatLocation, (model.Boat.BoatType)boatType);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }
        //changing the boat length and saving new information
        private void updateBoatLength(int memberLocation, int boatLocation)
        {
            consoleView.clear();
            consoleView.displayBoatLenghtInstruktions();
            float boatLength;
            try
            {   
                boatLength = float.Parse(consoleView.getInput());
                DAL.updateBoatLength(memberLocation, boatLocation, boatLength);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }

        //deleting a member from list and saving new information
        private void deleteMember(int memberLocation)
        {
            DAL.removeMember(memberLocation);
        }

        //updating a member and lettign the user choose that to change
        private void updateMember(int memberLocation)
        {
            consoleView.clear();
            consoleView.displayMemberChangeMenu();
            switch (consoleView.memberChangeMenuKeyPress())
            {
                case 1:
                    updateMemberName(memberLocation);
                    break;
                case 2:
                    updateMemberSocialSecurityNumber(memberLocation);
                    break;
            }
        }

        //updating the member name and saving new information
        private void updateMemberName(int memberLocation)
        {
            consoleView.clear();
            consoleView.displayNameInstruktions();
            try
            {
                DAL.updateMemberName(memberLocation, consoleView.getInput());
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }

        //updating members secutirynumber and saving new information
        private void updateMemberSocialSecurityNumber(int memberLocation)
        {
            consoleView.clear();
            consoleView.displaySocialSecurityNumberInstruktions();
            try
            {
                DAL.updateMemberSSN(memberLocation, consoleView.getInput());
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }

        //deleting a member and saving the new members
        private void deleteMemberBoat(int memberLocation)
        {
            consoleView.clear();
            showUserBoats(DAL.getSpecificMember(memberLocation));
            consoleView.displayDeleteBoatInstruktions();
            int listId = int.Parse(consoleView.getInput());
            DAL.removeMemberBoat(memberLocation, listId);
            
        }

        //adding a member and saving the new members
        private void addNewBoat(int memberLocation)
        {
            consoleView.clear();
            consoleView.displayBoatLenghtInstruktions();
            float length;
            float.TryParse(consoleView.getInput(), out length);

            consoleView.clear();
            consoleView.displayBoatTypeInstruktions();
            showBoatType();
            try
            {
                int value = int.Parse(consoleView.getInput());
                var boatType = Enum.ToObject(typeof(model.Boat.BoatType), value);
                model.Boat boat = new model.Boat((model.Boat.BoatType)boatType, length);
                DAL.addBoatToMember(memberLocation, boat);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }

        //showing all boatstypes
        private void showBoatType()
        {
            int id = 0;
            foreach (var boat in Enum.GetValues(typeof(model.Boat.BoatType)))
            {
                consoleView.displayBoatTypes(id, Enum.GetName(typeof(model.Boat.BoatType), boat));
                id++;
            }
        }

        //show all botas that belongs to this member
        private void showUserBoats(model.Member member)
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
