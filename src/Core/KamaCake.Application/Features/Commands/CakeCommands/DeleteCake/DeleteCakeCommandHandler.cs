using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.Features.Commands.CakeCommands.DeleteCake
{
    public class DeleteCakeCommandHandler : IRequestHandler<DeleteCakeCommand, ServiceResponse>
    {
        private readonly ICakeRepository repository;

        public DeleteCakeCommandHandler(ICakeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ServiceResponse> Handle(DeleteCakeCommand request, CancellationToken cancellationToken)
        {
           var findCake= await repository.GetByIdAsync(request.Id);
            if (findCake == null)
                return new ServiceResponse(

                    IsSuccess: false,
                    statusCode: HttpStatusCode.NotFound,
                    message: "Cake tapılmadı!"
                    );
            try
            {
                await repository.DeleteAsync(request.Id);


                return new ServiceResponse(
               IsSuccess: true,
               statusCode: System.Net.HttpStatusCode.OK,
               message: "Cake uğurla silindi"
           );
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError,
                    message: $"Cake silinə bilmədi: {ex.Message}"
                );
            }

        }
    }
}
