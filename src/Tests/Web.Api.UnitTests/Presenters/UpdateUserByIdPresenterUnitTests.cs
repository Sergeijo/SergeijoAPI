using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Presenters;
using Xunit;

namespace Web.Api.UnitTests.Presenters
{
    public class UpdateUserByIdPresenterUnitTests
    {
        [Fact]
        public void Contains_Ok_Status_Code_When_Use_Case_Succeeds()
        {
            // arrange
            var presenter = new UpdateUserByIdPresenter();

            // act
            presenter.Handle(new UpdateUserByIdResponse(1, true));

            // assert
            Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void Contains_Id_When_Use_Case_Succeeds()
        {
            // arrange
            var presenter = new UpdateUserByIdPresenter();

            // act
            presenter.Handle(new UpdateUserByIdResponse(1, true));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.True(data.success.Value);
            Assert.Equal("2", data.id.Value);
        }

        [Fact]
        public void Contains_Errors_When_Use_Case_Fails()
        {
            // arrange
            var presenter = new UpdateUserByIdPresenter();

            // act
            presenter.Handle(new UpdateUserByIdResponse(new[] { "UserId not exists" }, true));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.False(data.success.Value);
            Assert.Equal("missing first name", data.errors.First.Value);
        }
    }
}
