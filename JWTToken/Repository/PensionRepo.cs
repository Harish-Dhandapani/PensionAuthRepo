using JWTToken.Models;
using JWTToken.Provider;

namespace JWTToken.Repository
{
    public class PensionRepo:IPensionRepo
    {
        private readonly IPensionProvider provider;

        public PensionRepo(IPensionProvider provider)
        {
            this.provider = provider;
        }

        public PensionerCredentials GetPensionerCred(PensionerCredentials cred)
        {
            if(cred == null)
            {
                return null;
            }
            else
            {
                PensionerCredentials pensioner = provider.GetPensioner(cred);
                return pensioner;
            }
        }
    }
}
