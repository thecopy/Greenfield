using AutoMapper;
using FizzWare.NBuilder;
using Greenfield.Web.Api;
using Greenfield.Web.Api.ViewModels;

namespace Greenfield.Web.ApiTests
{
    using NUnit.Framework;

    [TestFixture]
    public class AutoMapperTests
    {
        [Test]
        public void ConfigurationIsValid()
        {
            // Arrange & Act
            GreenfieldBootstrapper.SetupAutoMapping();

            // Assert
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void ShouldMapOrderWithRowsMapped()
        {
            // Arrange
            GreenfieldBootstrapper.SetupAutoMapping();
            var order = Builder<Order>.CreateNew()
                .With(order1 => order1.Rows = Builder<OrderRow>.CreateListOfSize(5).Build())
                .Build();

            // Act
            var vm = Mapper.Map<OrderVm>(order);

            // Assert
            Assert.AreEqual(vm.Rows.Count, order.Rows.Count);
        }
    }
}
