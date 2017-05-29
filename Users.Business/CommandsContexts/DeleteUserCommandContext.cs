using System;
using Cmas.Infrastructure.Domain.Commands;

namespace Cmas.BusinessLayers.Users.CommandsContexts
{
    public class DeleteUserCommandContext: ICommandContext
    {
        public String Id;
    }
}
