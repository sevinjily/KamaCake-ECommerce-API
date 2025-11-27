using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.Features.Queries.CategoryQueries.GetAllCategory.GetAllCategoryForUser
{
    public class GetAllCategoryForUserQuery:IRequest<ServiceResponseWithData<List<GetAllCategoryForUserDTO>>>
    {
    }
}
