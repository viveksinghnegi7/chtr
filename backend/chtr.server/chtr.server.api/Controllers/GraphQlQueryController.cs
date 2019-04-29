﻿using Autofac;
using chtr.server.api.Configuration;
using chtr.server.api.GraphQL.Extensions;
using chtr.server.api.GraphQL.Queries;
using chtr.server.data.Infrastructure;
using chtr.server.data.Repositories;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace chtr.server.api.Controllers
{
    [Route(Api.GraphQlPath)]
    public class GraphQlQueryController : Controller
    {
        private readonly IComponentContext _context;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQlQueryController(IComponentContext context, IRoomRepository roomRepository, IUserRepository userRepository,
            IDocumentExecuter documentExecuter)
        {
            _context = context;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQlQuery gQlQuery)
        {
            //var query = _context.GetQuery(gQlQuery.QueryType);
            var schema = new Schema { Query = new RoomQuery(_roomRepository, _userRepository) };
            var result = await _documentExecuter.ExecuteAsync(options =>
            {
                options.Schema = schema;
                options.Query = gQlQuery.Query;
                options.Inputs = gQlQuery.Variables;
            });

            if (result.Errors?.Count > 0)
                return BadRequest();

            return Ok(result);
        }
    }
}
