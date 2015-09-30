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
            return members;
        }
    }
}
