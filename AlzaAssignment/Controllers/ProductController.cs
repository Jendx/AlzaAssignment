using System.Web.Http;

namespace AlzaAssignment.Controllers;

/// <summary>
/// Controller handling CRUD operations for product entity
/// </summary>
public class ProductController : ApiController
{
    /// <summary>
    /// Default Endpoint
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public IHttpActionResult Index()
    {
        return Ok();
    }

}