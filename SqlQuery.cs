using System.Collections.Generic;

public class SqlQuery
{

    // Properties
    public Dictionary<string, object> Parameters { get; set; }
    public Dictionary<string, Parameter> ProcdureParameters { get; set; }
    public string Query { get; set; }
}


