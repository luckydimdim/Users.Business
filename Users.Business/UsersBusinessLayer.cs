using System;
using System.Security.Claims;
using Cmas.BusinessLayers.Users.Criteria;
using Cmas.BusinessLayers.Users.Entities;
using Cmas.Infrastructure.Domain.Commands;
using Cmas.Infrastructure.Domain.Queries;
using System.Threading.Tasks;
using Cmas.BusinessLayers.Users.CommandsContexts;
using System.Collections.Generic;
using Cmas.Infrastructure.Domain.Criteria;

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
            _commandBuilder = (ICommandBuilder) serviceProvider.GetService(typeof(ICommandBuilder));
            _queryBuilder = (IQueryBuilder) serviceProvider.GetService(typeof(IQueryBuilder));
        }

        /// <summary>
        /// Получить пользователя по логину
        /// </summary>
        public async Task<User> GetUser(string login)
        {
            if (string.IsNullOrEmpty(login))
                return null;

            return await _queryBuilder.For<Task<User>>().With(new FindByLogin(login));
        }

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        public async Task<User> GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            return await _queryBuilder.For<Task<User>>().With(new FindById(id));
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<string> CreateUser()
        {
            User user = new User();

            user.Id = null;
            user.UpdatedAt = DateTime.UtcNow;
            user.CreatedAt = DateTime.UtcNow;

            var context = new CreateUserCommandContext
            {
                User = user
            };

            context = await _commandBuilder.Execute(context);

            return context.Id;
        }

        /// <summary>
        /// Получить пользователей
        /// </summary>
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _queryBuilder.For<Task<IEnumerable<User>>>().With(new AllEntities());
        }

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        public async Task<string> UpdateUser(User user)
        {
            user.UpdatedAt = DateTime.UtcNow;

            var context = new UpdateUserCommandContext
            {
                User = user
            };

            context = await _commandBuilder.Execute(context);

            return context.User.Id;
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        public async Task<string> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("id");

            var context = new DeleteUserCommandContext
            {
                Id = id
            };

            context = await _commandBuilder.Execute(context);

            return context.Id;
        }
    }
}