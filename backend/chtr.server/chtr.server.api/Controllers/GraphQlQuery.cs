using System;
using System.Collections.Generic;
using System.Text;
using GraphiQl;
using GraphQL;

namespace chtr.server.api.Controllers
{
    public class GraphQlQuery
    {
        public string QueryType { get; set; }
        public string Query { get; set; }
        public Inputs Variables { get; set; }
    }
}
