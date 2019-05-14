using Autofac;
using chtr.server.api.Configuration;
using chtr.server.data.Infrastructure;
using chtr.server.data.Repositories;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace chtr.server.api.Controllers
{
    [Route(Api.GraphQlPath)]
    public class GraphQlQueryController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ILogger<GraphQlQueryController> _logger;

        public GraphQlQueryController(ISchema schema, IDocumentExecuter documentExecuter, ILogger<GraphQlQueryController> logger)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
            _logger = logger;
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
            {
                _logger.LogError(result.Errors.ToString());
                return BadRequest();
            }
            
            return Ok(result);
        }
    }
}
