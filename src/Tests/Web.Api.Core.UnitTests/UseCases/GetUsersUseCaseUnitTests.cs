using System;
using System.Threading.Tasks;
using Moq;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Xunit;

namespace Web.Api.Core.UnitTests.UseCases
{
    public class GetUsersUseCaseUnitTests
    {

        [Fact]
        public async void Can_Get_Users()
        {
            // arrange
            // 1. First it's necessary to store the user data somehow
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
              .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
              .Returns(Task.FromResult(new CreateUserResponse(1, true)));

            // 2. We declare and instantiate the UseCase
            var useCase = new GetAsyncUsersUseCase(mockUserRepository.Object);

            // 3. The output port is the way to pass response data from the UseCase to a Presenter 
            // for final preparation to deliver back to the UI/web page/api response etc.
            var mockOutputPort = new Mock<IOutputPort<GetUsersResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<GetUsersResponse>()));

            // act
            // 4. We need a model request to carry data into the use case from the upper layer (UI, Controller etc.)
            var response = await useCase.Handle(new GetUsersRequest(), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }
    }
}
