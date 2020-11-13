namespace ODZ.Web.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    public static class IdentityResultExtensions
    {
        public static string GetFirstError(this IdentityResult identityResult)
        {
            if (identityResult == null)
            {
                throw new ArgumentNullException(nameof(identityResult));
            }

            return identityResult.Errors.FirstOrDefault();
        }
    }
}
