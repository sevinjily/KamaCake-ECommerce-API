using KamaCake.Application.DTOs.CartDTOs.CartItemDTO;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Commands.CartItemCommands
{
    public class CreateCartItemCommand:IRequest<ServiceResponse>
    {
        //todo DeleteCartItem,Update,Get
        public CreateCartItemDTO Model { get; set; }
        public CreateCartItemCommand(CreateCartItemDTO model)
        {
            Model = model;
        }


      
    }
}
