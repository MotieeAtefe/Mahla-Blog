using System;
using System.Security.Claims;

namespace Mahla_Blog.CoreLayer.Utilities
{
    public static class UserUtil
    {
        public static int GetUserId(this ClaimsPrincipal perPrincipal)
        {
            if (perPrincipal == null)
                throw new ArgumentException(nameof(perPrincipal));
            return Convert.ToInt32(perPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
