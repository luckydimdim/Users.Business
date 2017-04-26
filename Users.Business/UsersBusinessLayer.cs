using Cmas.BusinessLayers.Users.Criteria;
using Cmas.BusinessLayers.Users.Entities;
using Cmas.Infrastructure.Domain.Commands;
using Cmas.Infrastructure.Domain.Queries;
using System.Threading.Tasks;

namespace Cmas.BusinessLayers.Users
{
    public class UsersBusinessLayer
    {
        private readonly ICommandBuilder _commandBuilder;
        private readonly IQueryBuilder _queryBuilder;

        public UsersBusinessLayer(ICommandBuilder commandBuilder, IQueryBuilder queryBuilder)
        {
            _commandBuilder = commandBuilder;
            _queryBuilder = queryBuilder;
        }

        public async Task<User> GetUser(string login)
        {
            if (string.IsNullOrEmpty(login))
                return null;

            return await _queryBuilder.For<Task<User>>().With(new FindByLogin(login));
        }
    }
}