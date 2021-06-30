using System.Collections.Generic;

namespace NexusADO.Net
{
    public class SqlQuery
    {

        // Properties
        public Dictionary<string, object> Parameters { get; set; }
        public Dictionary<string, Parameter> ProcdureParameters { get; set; }
        public string Query { get; set; }
    }
}

