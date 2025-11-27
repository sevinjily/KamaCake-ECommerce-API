using AutoMapper;
using KamaCake.Application.DTOs.CategoryDTO;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.Features.Queries.CategoryQueries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ServiceResponseWithData<GetCategoryByIdDTO>>
    {
        private readonly ICategoryRepository repository;
        private readonly IMapper mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ServiceResponseWithData<GetCategoryByIdDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await repository.GetByIdAsync(request.Id);
            if (category == null)
                return new ServiceResponseWithData<GetCategoryByIdDTO>(default,false, System.Net.HttpStatusCode.NotFound, "Belə kateqoriya tapılmadı");

            try
            {
                var viewModel = mapper.Map<GetCategoryByIdDTO>(category);

                return new ServiceResponseWithData<GetCategoryByIdDTO>(
                    value: viewModel,
                    isSuccess: true,
                    statusCode: System.Net.HttpStatusCode.OK
                    );               
               // value: viewModel,
               //isSuccess: true,
               //statusCode: System.Net.HttpStatusCode.OK

           
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponseWithData<GetCategoryByIdDTO>(
                    value: default,
                    isSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError
                );


            }

        }
    }
}
