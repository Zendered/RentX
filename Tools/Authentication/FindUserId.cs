using System.Security.Claims;

namespace RentX.Tools.Authentication
{
    public class FindUserId : IFindUserId
    {
        private readonly IHttpContextAccessor contextAccessor;

        public FindUserId(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public Guid GetUserId() => Guid.Parse(contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
