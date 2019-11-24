using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Web.Api.Controllers;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Models.Request;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Web.Api.Presenters;
using Xunit;
using Web.Api.Core.Dto.UseCaseResponses;
using System.Collections.Generic;

namespace Web.Api.UnitTests.Controllers
{
    public class UserControllerUnitTests
    {
        [Fact]
        public async void Post_Returns_Ok_When_Add_User_Use_Case_Succeeds()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new CreateUserResponse(1 ,true)));

            // fakes
            var outputAddUserPort = new AddUserPresenter();
            var outputGetUsersPort = new GetUsersPresenter();
            var outputGetUserByIdPort = new GetUserByIdPresenter();
            var outputUpdateUserPort = new UpdateUserByIdPresenter();
            var outputDeleteUserByIdPort = new DeleteUserByIdPresenter();

            var addUserUseCase = new AddAsyncUserUseCase(mockUserRepository.Object);
            var getUsersUseCase = new GetAsyncUsersUseCase(mockUserRepository.Object);
            var getUserByIdUseCase = new GetAsyncUserByIdUseCase(mockUserRepository.Object);
            var updateUserByIdUseCase = new UpdateAsyncUserByIdUseCase(mockUserRepository.Object);
            var deleteUserByIdUseCase = new DeleteAsyncUserByIdUseCase(mockUserRepository.Object);

            var controller = new UserController(addUserUseCase, outputAddUserPort,
                getUserByIdUseCase, outputGetUserByIdPort,
                getUsersUseCase, outputGetUsersPort,
                updateUserByIdUseCase, outputUpdateUserPort,
                deleteUserByIdUseCase, outputDeleteUserByIdPort);

            // act
            var result = await controller.AddUserAsync(new Models.Request.AddUserRequest());

            // assert
            var statusCode = ((ContentResult) result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int) HttpStatusCode.OK);
        }

        [Fact]
        public async void Post_Returns_Ok_When_Update_User_By_Id_Use_Case_Succeeds()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.Update("", It.IsAny<User>()))
                .Returns(Task.FromResult(new Core.Dto.GatewayResponses.Repositories.UpdateUserByIdResponse(1, true)));

            // fakes
            var outputAddUserPort = new AddUserPresenter();
            var outputGetUsersPort = new GetUsersPresenter();
            var outputGetUserByIdPort = new GetUserByIdPresenter();
            var outputUpdateUserPort = new UpdateUserByIdPresenter();
            var outputDeleteUserByIdPort = new DeleteUserByIdPresenter();

            var addUserUseCase = new AddAsyncUserUseCase(mockUserRepository.Object);
            var getUsersUseCase = new GetAsyncUsersUseCase(mockUserRepository.Object);
            var getUserByIdUseCase = new GetAsyncUserByIdUseCase(mockUserRepository.Object);
            var updateUserByIdUseCase = new UpdateAsyncUserByIdUseCase(mockUserRepository.Object);
            var deleteUserByIdUseCase = new DeleteAsyncUserByIdUseCase(mockUserRepository.Object);

            var controller = new UserController(addUserUseCase, outputAddUserPort,
                getUserByIdUseCase, outputGetUserByIdPort,
                getUsersUseCase, outputGetUsersPort,
                updateUserByIdUseCase, outputUpdateUserPort,
                deleteUserByIdUseCase, outputDeleteUserByIdPort);

            // act
            var result = await controller.UpdateUserByIdAsync("userIdToUpdate", new UpdateUserRequest() { Updated_id = 999, Updated_name = "newName", Updated_birthdate = DateTime.Now, Updated_password = "newPassword" });

            // assert
            var statusCode = ((ContentResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
        }

        [Fact]
        public async void Post_Returns_Bad_Request_When_Model_Validation_Fails()
        {
            // arrange
            var controller = new UserController(null, null, null, null, null, null, null, null, null, null);
            controller.ModelState.AddModelError("FirstName", "Required");

            // act
            var result = await controller.AddUserAsync(null);

            // assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
