using JWTToken.Models;


namespace JWTToken.Repository
{
    public interface IPensionRepo
    {
        public PensionerCredentials GetPensionerCred(PensionerCredentials cred);
    }
}
