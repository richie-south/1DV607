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
        private const string fileName = "member.bin";
        public void save(List<model.Member> m)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, m);
            stream.Close();
        }

        public List<model.Member> loadFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            List<model.Member> members = (List<model.Member>)formatter.Deserialize(stream);
            stream.Close();

            return members;
        }
    }
}
