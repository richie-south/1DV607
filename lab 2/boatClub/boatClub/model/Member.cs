using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace boatClub.model
{
    [Serializable]
    class Member
    {
        private string _name;
        private string _socialSecurityNumber;
        private int _id;
        //A user own boats
        private List<model.Boat> _boats = new List<model.Boat>();

        public List<model.Boat> Boats { get { return _boats; }}

        public int Id { get { return _id; } }

        //throwing exeptions with wrong format
        public string Name { get { return _name; } 
            set {
                if(String.IsNullOrWhiteSpace(value) || value.Any(char.IsDigit)){
                    throw new ArgumentException("wrong format");
                }
                _name = value;
            } 
        }

        public string SocialSecurityNumber { get { return _socialSecurityNumber; } 
            set {

                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Wrong format!");
                }
                _socialSecurityNumber = value;
            } 
        }

        public Member(string name, string socialSecurityNumber, int id)
        {
            _id = id;
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public void addBoat(model.Boat Boat)
        {
            _boats.Add(Boat);
        }

        public void deleteBoat(int listId)
        {
            _boats.Remove(_boats.ElementAt(listId));
        }

    }
}
