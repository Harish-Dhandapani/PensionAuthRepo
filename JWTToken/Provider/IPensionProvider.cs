using JWTToken.Models;
using System.Collections.Generic;

namespace JWTToken.Provider
{
    public interface IPensionProvider
    {
        public List<PensionerCredentials> GetList();
        public PensionerCredentials GetPensioner(PensionerCredentials cred);
    }
}
