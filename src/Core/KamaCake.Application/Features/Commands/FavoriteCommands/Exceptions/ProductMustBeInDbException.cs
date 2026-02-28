using KamaCake.Application.Bases;

namespace KamaCake.Application.Features.Commands.FavoriteCommands.Exceptions
{
    public class ProductMustBeInDbException : BaseException
    {
        public ProductMustBeInDbException() : base("Product didn't find!") { }
    
    }
}
