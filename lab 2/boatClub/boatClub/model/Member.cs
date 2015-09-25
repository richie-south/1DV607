using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace boatClub.model
{

    class Member
    {
        private string _name;
        private string _socialSecurityNumber;
        private string _id;
        private List<model.Boat> _boats;
        private Regex regex = new Regex(@"^(\d{6}|\d{8})[-|(\s)]{0,1}\d{4}$");

        public List<model.Boat> Boats { get { return _boats; }}
        public string Name { get { return _name; } 
            set {
                if(String.IsNullOrWhiteSpace(value) && value.Any(char.IsDigit)){
                    throw new ArgumentException("wrong name format");
                }
                _name = value;
            } 
        }

        public string SocialSecurityNumber { get { return _socialSecurityNumber; } 
            set {

                if(String.IsNullOrWhiteSpace(value) && !regex.IsMatch(value)){
                    throw new ArgumentException("Wrong format!");
                }
                _socialSecurityNumber = value;
            } 
        }

        public Member(string name, string socialSecurityNumber)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public void addBoat(model.Boat Boat)
        {
            _boats.Add(Boat);
        } 

    }
}
