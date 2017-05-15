using Cmas.Infrastructure.Domain.Commands;
using Cmas.BusinessLayers.Users.Entities;

namespace Cmas.BusinessLayers.Users.CommandsContexts
{
    public class UpdateUserCommandContext : ICommandContext
    {
        public User User;
    }
}
