using Microsoft.Win32;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class CommandObject
{
    // Fields
    private Dictionary<string, SqlParameter> SqlParameters = new Dictionary<string, SqlParameter>();
    private SqlCommand sqlCommand = new SqlCommand();

    // Methods
    private SqlParameter[] AddParameters(Dictionary<string, Parameter> param)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        foreach (string str in param.Keys)
        {
            if (!param[str].IsOut)
            {
                object value = param[str].Value;
                if (value == null)
                    value = "";

                list.Add(new SqlParameter(str, value));
                continue;
            }
            string parameterName = str;
            object value_1 = param[str].Value;

            if (value_1 == null)
                value_1 = "";

            SqlParameter parameter = new SqlParameter(parameterName, value_1)
            {
                Direction = ParameterDirection.Output,
                SqlDbType = param[str].OutType,
                Size = param[str].Size
            };
            if (param[str].DataSetColumn.Key)
                parameter.SourceColumn = param[str].DataSetColumn.Value;

            this.SqlParameters.Add(parameterName, parameter);
            list.Add(this.SqlParameters[str]);
        }
        return list.ToArray();
    }

    private SqlParameter[] AddParameters(Dictionary<string, object> param)
    {
        List<SqlParameter> list = new List<SqlParameter>();
        foreach (string str in param.Keys)
        {
            object value = param[str];
            if (value == null)
                value = "";
            list.Add(new SqlParameter(str, value));
        }
        return list.ToArray();
    }

    public SqlCommand CreateQuery(string cmd, Dictionary<string, Parameter> parameters, SqlConnection connection)
    {
        this.sqlCommand = new SqlCommand(cmd, connection);
        this.sqlCommand.CommandType = CommandType.StoredProcedure;
        if (parameters != null)
        {
            this.sqlCommand.Parameters.AddRange(this.AddParameters(parameters));
        }
        return this.sqlCommand;
    }

    public SqlCommand CreateQuery(string cmd, Dictionary<string, object> parameters, SqlConnection connection)
    {
        this.sqlCommand = new SqlCommand(cmd, connection);
        this.sqlCommand.CommandType = CommandType.Text;
        if (parameters != null)
        {
            this.sqlCommand.Parameters.AddRange(this.AddParameters(parameters));
        }
        return this.sqlCommand;
    }

    public void Parameter(Dictionary<string, Parameter> value)
    {
        this.sqlCommand.Parameters.AddRange(this.AddParameters(value));
    }

    public void Parameter(Dictionary<string, object> value)
    {
        this.sqlCommand.Parameters.AddRange(this.AddParameters(value));
    }

    // Properties
    public string CommandText
    {
        get =>
            this.sqlCommand.CommandText;
        set =>
            this.sqlCommand.CommandText = value;
    }

    public SqlConnection SqlConnection
    {
        set =>
            this.sqlCommand.Connection = value;
    }
}


