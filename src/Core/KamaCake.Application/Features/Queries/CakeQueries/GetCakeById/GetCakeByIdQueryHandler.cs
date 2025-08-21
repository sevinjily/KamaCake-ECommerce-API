﻿using AutoMapper;
using KamaCake.Application.DTOs.CakeDTOs;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;

namespace KamaCake.Application.Features.Queries.CakeQueries.GetCakeById
{
    public class GetCakeByIdQueryHandler : IRequestHandler<GetCakeByIdQuery, ServiceResponseWithData<GetCakeDTO>>
    {
        private readonly ICakeRepository repository;
        private readonly IMapper mapper;

        public GetCakeByIdQueryHandler(ICakeRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ServiceResponseWithData<GetCakeDTO>> Handle(GetCakeByIdQuery request, CancellationToken cancellationToken)
        {
            var findCake=await repository.GetByIdAsync(request.Id);

            if (findCake == null)
                return new ServiceResponseWithData<GetCakeDTO>(
                    value: default,
                    isSuccess: false,
                    statusCode: System.Net.HttpStatusCode.NotFound,
                message: "Belə bir cake yoxdur"
                );

            try
            {
                var viewModel = mapper.Map<GetCakeDTO>(findCake);

                return new ServiceResponseWithData<GetCakeDTO>(
                    value: viewModel,
                    isSuccess: true,
                    statusCode: System.Net.HttpStatusCode.OK
                    );
                
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponseWithData<GetCakeDTO>(
                    value: default,
                    isSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError
                );


            }
        }
    }
}
