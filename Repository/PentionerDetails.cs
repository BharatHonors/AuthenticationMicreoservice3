using System.Collections.Generic;
using AuthenticationMicreoservice3.Model;

namespace AuthenticationMicreoservice3.Repository
{
    public class PentionerDetails : IPentionerDetails
    {
        List<Pentioner> pentionerList = new List<Pentioner>()
        {
            new Pentioner(){Name="User1", Password="123"},
            new Pentioner(){Name="User2", Password = "123"}
        };

        public Pentioner GetPentioner(Pentioner pentioner)
        {
            return pentionerList.Find(x => x.Name == pentioner.Name);
        }

        public List<Pentioner> GetPentioners()
        {
            return pentionerList;
        }
    }
}
