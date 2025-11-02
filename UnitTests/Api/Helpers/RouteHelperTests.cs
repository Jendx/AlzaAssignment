using Api.Helpers;
using Shouldly;
using UnitTests.Constants;

namespace UnitTests.Api.Helpers;

[TestFixture(Category = TestCategories.HELPERS)]
public class RouteHelperTests
{
    [Test]
    public void GetControllerRoute_ReturnsCorrectRoute()
    {
        // Act
        var route = RouteHelper.GetControllerRoute("v1", "api/test");

        // Assert
        route.ShouldBe("v1/api/test");
    }
}