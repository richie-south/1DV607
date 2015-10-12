using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boatClub.model
{
    class GenerateID
    {
        //creating a randomnr fot the uniquenr
        private int randomNumber()
        {
            Random ran = new Random();
            return ran.Next(int.MaxValue);
        }
        //checking if the uniquenr alredy exist in memberslist
        private bool isUniqeSame(int uniqeId, List<model.Member> members)
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

        public int newId(List<model.Member> members)
        {
            int uniqeId;
            do
            {
                uniqeId = randomNumber();

            } while (isUniqeSame(uniqeId, members));
            return uniqeId;
        }
    }
}
