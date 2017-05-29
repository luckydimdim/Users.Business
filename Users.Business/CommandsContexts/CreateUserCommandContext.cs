using Cmas.BusinessLayers.Users.Entities;
using Cmas.Infrastructure.Domain.Commands;
using System;

namespace Cmas.BusinessLayers.Users.CommandsContexts
{

    public class CreateUserCommandContext : ICommandContext
    {
        public String Id;
        public User User;
    }
}
