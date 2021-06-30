using System.Collections.Generic;
using System.Data;
namespace NexusADO.Net
{
    public class Parameter
    {
        // Properties
        public bool IsOut { get; set; }

        public SqlDbType OutType { get; set; }

        public object Value { get; set; }

        public int Size { get; set; }
        public KeyValuePair<bool, string> DataSetColumn { get; set; } = new KeyValuePair<bool, string>(false, "");
    }
}