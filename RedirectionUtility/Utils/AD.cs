using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedirectionUtility.Utils
{
    public class AD
    {
        public bool UserPresent(string username)
        {
            using (var domainContext = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
            {
                using (var user = new UserPrincipal(domainContext))
                {
                    user.SamAccountName = username;
                    using (var pS = new PrincipalSearcher())
                    {
                        pS.QueryFilter = user;
                        using (PrincipalSearchResult<Principal> results = pS.FindAll())
                        {
                            if (results.Any())
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
