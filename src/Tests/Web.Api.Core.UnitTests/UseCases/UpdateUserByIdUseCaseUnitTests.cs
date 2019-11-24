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
    public class UpdateUserByIdUseCaseUnitTests
    {

        [Fact]
        public async void Can_Update_User_By_Id()
        {
            // arrange
            // 1. First it's necessary to store the user data somehow
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
              .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
              .Returns(Task.FromResult(new CreateUserResponse(1, true)));

            // 2. We declare and instantiate the UseCase
            var useCase = new UpdateAsyncUserByIdUseCase(mockUserRepository.Object);

            // 3. The output port is the way to pass response data from the UseCase to a Presenter 
            // for final preparation to deliver back to the UI/web page/api response etc.
            var mockOutputPort = new Mock<IOutputPort<Web.Api.Core.Dto.UseCaseResponses.UpdateUserByIdResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<Web.Api.Core.Dto.UseCaseResponses.UpdateUserByIdResponse>()));

            // act
            // 4. We need a model request to carry data into the use case from the upper layer (UI, Controller etc.)
            var response = await useCase.Handle(new UpdateUserByIdRequest(1, 2, "name", DateTime.Now, "password"), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }
    }
}
