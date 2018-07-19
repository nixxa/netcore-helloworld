using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NSubstitute;
using WebApi.Controllers;
using Xunit;

namespace Tests
{
    public class TestValuesController
    {
        [Fact]
        public async Task Should_return_all_products()
        {
            var mediator = Substitute.For<IMediator>();
            var mapper = Substitute.For<IMapper>();
            var controller = new ValuesController(mediator, mapper);

            var result = await controller.Get();
            Assert.NotNull(result);
        }
    }
}
