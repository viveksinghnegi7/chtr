using Autofac;
using chtr.server.api.Configuration;
using chtr.server.data.Infrastructure;
using chtr.server.data.Repositories;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace chtr.server.api.Controllers
{
    [Route(Api.GraphQlPath)]
    public class GraphQlQueryController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQlQueryController(ISchema schema,  IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQlQuery gQlQuery)
        {
            var result = await _documentExecuter.ExecuteAsync(options =>
            {
                options.Schema = _schema;
                options.Query = gQlQuery.Query;
                options.Inputs = gQlQuery.Variables;
            });

            if (result.Errors?.Count > 0)
                return BadRequest();

            return Ok(result);
        }
    }
}
