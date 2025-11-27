using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.Features.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommand:IRequest<ServiceResponse>
    {
        public Guid Id { get; set; }
        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
