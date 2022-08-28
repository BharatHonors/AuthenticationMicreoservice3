using System.Collections.Generic;

using AuthenticationMicreoservice3.Model;

namespace AuthenticationMicreoservice3.Repository
{
    public interface IPentionerDetails
    {
        public Pentioner GetPentioner(Pentioner pentioner);
        public List<Pentioner> GetPentioners();
    }
}
