using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub.model
{
    class Boat
    {
        public enum BoatType
        {
            Salilboat,
            Motorsailer,
            Kayak_Canoe,
            Other
        }

        private float _boatLenght;
        private BoatType _BoatType;
        public float BoatLenght
        {
            get { return _boatLenght; } 
            private set {
                if(value <= 0 || value >= 1000){
                    throw new ArgumentOutOfRangeException();
                }
                _boatLenght = value;
            }
        }

        public BoatType BoatTypeProp
        {
            get { return _BoatType; } 
            private set {
                _BoatType = value;
            } 
        }

        public Boat(BoatType type, float boatLenght)
        {
            BoatTypeProp = type;
            BoatLenght = boatLenght;
        }
    }
}
