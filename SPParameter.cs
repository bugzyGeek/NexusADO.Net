using System.Collections.Generic;
using System.Data.SqlClient;

namespace NexusADO.Net
{
    public class SPParameters
    {
        // Properties
        public Dictionary<string, SqlParameter> SqlParameters { get; private set; }
    }
}


