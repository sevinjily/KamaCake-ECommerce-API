using KamaCake.Application.Bases;
using KamaCake.Application.Features.Commands.FavoriteCommands.Exceptions;
using KamaCake.Domain.Entities;

namespace KamaCake.Application.Features.Commands.FavoriteCommands.Rules
{
    public class FavoriteRules :BaseRule
    {
        public Task ProductMustBeInDb(Cake? product)
        {
            if (product is null) throw new ProductMustBeInDbException();
            return Task.CompletedTask;
        }
    }
}
