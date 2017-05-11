using System;
using System.Security.Claims;
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
        private readonly ClaimsPrincipal _claimsPrincipal;

        public UsersBusinessLayer(IServiceProvider serviceProvider, ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
            _commandBuilder = (ICommandBuilder)serviceProvider.GetService(typeof(ICommandBuilder));
            _queryBuilder = (IQueryBuilder)serviceProvider.GetService(typeof(IQueryBuilder));
        }

        public async Task<User> GetUser(string login)
        {
            if (string.IsNullOrEmpty(login))
                return null;

            return await _queryBuilder.For<Task<User>>().With(new FindByLogin(login));
        }
    }
}