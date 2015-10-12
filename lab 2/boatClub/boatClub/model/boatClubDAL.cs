using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace boatClub.model
{
    class boatClubDAL
    {

        private List<model.Member> _members = new List<model.Member>();
        private const string fileName = "member.bin";
        public List<model.Member> Members { get {
            if (_members.Count <= 0)
            {
                throw new IndexOutOfRangeException("no user in list");
            }
            return _members; 
        } }

        private void save()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Members);
            stream.Close();
        }

        public void loadFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream;
            List<model.Member> members;

            try
            {
                stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
                members = (List<model.Member>)formatter.Deserialize(stream);
            }
            catch (Exception)
            {
                
                throw;
            }
            
            stream.Close();
            foreach (var member in members)
            {
                addMember(member);
            }
        }

        public void addMember(model.Member member)
        {
            _members.Add(member);
            save();
        }

        public model.Member getSpecificMember(int memberLocation)
        {
            return Members.ElementAt(memberLocation);
        }

        public void removeMember(int memberLocation)
        {
            Members.Remove(getSpecificMember(memberLocation));
            save();
        }

        public void updateMemberName(int memberLocation, string name)
        {
            model.Member member = getSpecificMember(memberLocation);
            member.Name = name;
            save();
        }

        public void updateMemberSSN(int memberLocation, string ssn)
        {
            model.Member member = getSpecificMember(memberLocation);
            member.SocialSecurityNumber = ssn;
            save();
        }

        public void addBoatToMember(int memberLocation, model.Boat boat)
        {
            model.Member member = getSpecificMember(memberLocation);
            member.addBoat(boat);
            save();
        }

        public void removeMemberBoat(int memberLocation, int boatLocation)
        {
            model.Member member = getSpecificMember(memberLocation);
            member.deleteBoat(boatLocation);
            save();
        }

        public model.Boat getSpecificBoat(int memberLocation, int boatLocation)
        {
            model.Member member = getSpecificMember(memberLocation);
            model.Boat boat = member.Boats.ElementAt(boatLocation);
            return boat;
        }

        public void updateBoatLength(int memberLocation, int boatLocation, float length) {
            model.Boat boat = getSpecificBoat(memberLocation, boatLocation);
            boat.BoatLenght = length;
            save();
        }

        public void updateBoatType(int memberLocation, int boatLocation, model.Boat.BoatType boatType)
        {
            model.Boat boat = getSpecificBoat(memberLocation, boatLocation);
            boat.BoatTypeProp = boatType;
            save();
        }
    }
}
