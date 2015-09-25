using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub.model
{
    class Secretary
    {

        public void addNewMember()
        {
            

        }
        public void addNewBoat(model.Member member, model.Boat boat)
        {
            member.addBoat(boat);
        }

        public model.Boat newBoat(model.Boat.BoatType boatType, float boatLenght)
        {
            model.Boat boat = new model.Boat(boatType, boatLenght);
            return boat;
        }
    }
}
