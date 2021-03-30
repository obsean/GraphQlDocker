using System;
using System.Collections.Generic;
using System.Net.Http;

namespace GraphQlDocker
{
    public abstract class GraphQLException : Exception
    {
        public HttpResponseMessage Response { get; private set; }

        public IEnumerable<string> ErrorMessages { get; private set; }

        public GraphQLException(HttpResponseMessage response)
            : base("Error running graphql query, see response for more details")
        {
            this.Response = response;
        }

        public GraphQLException(IEnumerable<string> errorMessages, HttpResponseMessage response)
            : base("Error running graphql query, error messages or response for more details")
        {
            this.Response = response;
            this.ErrorMessages = errorMessages;
        }
    }
}
