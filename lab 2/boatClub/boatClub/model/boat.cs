using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub.model
{
    [Serializable]
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

        //throws exeptions
        public float BoatLenght
        {
            get { return _boatLenght; } 
            set {
                if(value <= 0 || value >= 1000){
                    throw new ArgumentOutOfRangeException("Invalid boat length");
                }
                _boatLenght = value;
            }
        }

        public BoatType BoatTypeProp
        {
            get { return _BoatType; } 
            set {
                if(!Enum.IsDefined(typeof(BoatType), value)){
                    throw new ArgumentException("Båt typen finns inte");
                }
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
