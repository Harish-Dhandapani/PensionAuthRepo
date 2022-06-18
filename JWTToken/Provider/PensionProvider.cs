using JWTToken.Models;
using System.Collections.Generic;

namespace JWTToken.Provider
{
    public class PensionProvider:IPensionProvider
    {
        public static List<PensionerCredentials> PensionerList = new List<PensionerCredentials>
        {
            new PensionerCredentials
            {
                username = "user1",
                password = "user1"
            },
            new PensionerCredentials
            {
                username = "user2",
                password = "user2"
            }
        };

        public List<PensionerCredentials> GetList()
        {
            return PensionerList;
        }

        public PensionerCredentials GetPensioner(PensionerCredentials cred)
        {
            PensionerCredentials newCred = PensionerList.Find(x=>x.username==cred.username&&x.password==cred.password);
            return newCred;
        }
    }
}
