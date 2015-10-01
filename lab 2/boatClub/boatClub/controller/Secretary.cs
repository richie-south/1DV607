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
        private List<model.Member> members = new List<model.Member>();
        private view.ConsoleView consoleView;
        private model.boatClubDAL DAL = new model.boatClubDAL();
        public Secretary(view.ConsoleView c)
        {
            consoleView = c;
            addMembersFromFile();
        }

        //takeing the saved members in the file and pushing them to the array
        public void addMembersFromFile(){

            var membersFromFile = DAL.loadFile();
            foreach (var member in membersFromFile) 
            {
                members.Add(member);
            }
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
        public void detaildList()
        {
            consoleView.clear();
            foreach (var member in members)
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

        //creating a randomnr fot the uniquenr
        public int randomNumber()
        {
            Random ran = new Random();
            return ran.Next(int.MaxValue);
        }
        //checking if the uniquenr alredy exist in memberslist
        public bool isUniqeSame(int uniqeId)
        {
            foreach (var m in members)
            {
                if (uniqeId == m.Id)
                {
                    return true;
                }
            }
            return false;
        }

        //creating new member, calling to display instructions
        //try-catch for exeptions with the name and securitynumber
        //saving the list to the bin-file
        public void addNewMember()
        {
            consoleView.clear();
            consoleView.displayNameInstruktions();
            string name = consoleView.getInput();
            consoleView.clear();
            consoleView.displaySocialSecurityNumberInstruktions();
            string SecurityNumber = consoleView.getInput();

            int uniqeId = 0;
            do
            {
                uniqeId = randomNumber();    
            } while (isUniqeSame(uniqeId));

            try
            {
                model.Member member = new model.Member(name, SecurityNumber, uniqeId);
                members.Add(member);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
            
            
            DAL.save(members);
        }
        
        //user can select a member and see more information
        //showing all members and nr of boats they own
        public void compactList()
        {
            consoleView.clear();
            
            int i = 0;
            foreach (var member in members)
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
        public void specificUser(int userLocation)
        {
            if (members.Count <= 0)
            {
                throw new IndexOutOfRangeException("no user in list");
            }
            
            var member = members.First();
            try
            {
               member = members.ElementAt(userLocation);
            }
            catch (Exception e)
            {
                throw;
            }
            consoleView.clear();
            consoleView.displaySelectedUser(member.Name, member.Id, member.SocialSecurityNumber);
            showUserBoats(member);
            displayMemberMenu(member);
        }

        //the menu that offers to the user to: change/delete member/boats and add new boat to the member
        public void displayMemberMenu(model.Member member)
        {
            consoleView.displayMemberMenu();
            switch (consoleView.getMenuKeyPress())
            {
                case 1:
                    deleteMember(member);
                    break;
                case 2:
                    updateMember(member);
                    break;
                case 3:
                    addNewBoat(member);
                    break;
                case 4:
                    deleteMemberBoat(member);
                    break;
                case 5:
                    updateBoat(member);
                    break;
                case 6:
                    displayStartMenu();
                    break;
            }
        }

        //updating the boat, showing the instructions
        //letting the user decide which boat to update
        public void updateBoat(model.Member member)
        {
            consoleView.clear();
            showUserBoats(member);
            consoleView.displayBoatUpdateInstructions();
            int listId;
            try
            {
                listId = int.Parse(consoleView.getInput());
                updateBoatMenu(member.Boats.ElementAt(listId));
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }

        //Menu letting the user choose what they want to change
        public void updateBoatMenu(model.Boat boat)
        {
            consoleView.displayBoatChangeMenu();
            switch (consoleView.boatChangeMenuKeyPress())
            {
                case 1:
                    updateBoatLength(boat);
                    break;
                case 2:
                    updateBoatType(boat);
                    break;
            }
        }

        //changing the boat type and saving new information
        public void updateBoatType(model.Boat boat)
        {
            consoleView.clear();
            consoleView.displayBoatTypeInstruktions();
            showBoatType();
            try
            {
                int value = int.Parse(consoleView.getInput());
                var boatType = Enum.ToObject(typeof(model.Boat.BoatType), value);
                boat.BoatTypeProp = (model.Boat.BoatType)boatType;
                DAL.save(members);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }
        //changing the boat length and saving new information
        public void updateBoatLength(model.Boat boat)
        {
            consoleView.clear();
            consoleView.displayBoatLenghtInstruktions();
            try
            {
                boat.BoatLenght = float.Parse(consoleView.getInput());
                DAL.save(members);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }

        //deleting a member from list and saving new information
        public void deleteMember(model.Member member)
        {
            members.Remove(member);
            DAL.save(members);
        }

        //updating a member and lettign the user choose that to change
        public void updateMember(model.Member member) {
            consoleView.clear();
            consoleView.displayMemberChangeMenu();
            switch (consoleView.memberChangeMenuKeyPress())
            {
                case 1:
                    updateMemberName(member);
                    break;
                case 2:
                    updateMemberSocialSecurityNumber(member);
                    break;
            }
        }

        //updating the member name and saving new information
        public void updateMemberName(model.Member member)
        {
            consoleView.clear();
            consoleView.displayNameInstruktions();
            try
            {
                member.Name = consoleView.getInput();
                DAL.save(members);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }

        //updating members secutirynumber and saving new information
        public void updateMemberSocialSecurityNumber(model.Member member)
        {
            consoleView.clear();
            consoleView.displaySocialSecurityNumberInstruktions();
            try
            {
                member.SocialSecurityNumber = consoleView.getInput();
                DAL.save(members);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }
        }

        //deleting a member and saving the new members
        public void deleteMemberBoat(model.Member member)
        {
            consoleView.clear();
            showUserBoats(member);
            consoleView.displayDeleteBoatInstruktions();
            int listId = int.Parse(consoleView.getInput());
            member.deleteBoat(listId);
            DAL.save(members);
            
        }

        //adding a member and saving the new members
        public void addNewBoat(model.Member member)
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
                member.addBoat(boat);
            }
            catch (Exception e)
            {
                consoleView.displayExeptions(e.ToString());
            }

            DAL.save(members);
        }

        //showing all boatstypes
        public void showBoatType()
        {
            int id = 0;
            foreach (var boat in Enum.GetValues(typeof(model.Boat.BoatType)))
            {
                consoleView.displayBoatTypes(id, Enum.GetName(typeof(model.Boat.BoatType), boat));
                id++;
            }
        }

        //show all botas that belongs to this member
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
