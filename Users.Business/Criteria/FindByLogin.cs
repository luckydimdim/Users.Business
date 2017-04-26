using Cmas.Infrastructure.Domain.Criteria;

namespace Cmas.BusinessLayers.Users.Criteria
{
    public class FindByLogin : ICriterion
    {
        public FindByLogin(string login)
        {
            Login = login.Trim().ToLower();
        }

        public string Login { get; set; }
    }
}