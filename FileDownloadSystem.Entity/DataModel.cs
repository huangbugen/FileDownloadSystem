using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDownloadSystem.Entity
{
    public class DataModel
    {
        public class PageDataOptions
        {
            public int Page { get; set; }
            public int Rows { get; set; }
            public int Total { get; set; }
            public string TableName { get; set; }
            /// <summary>
            /// 排序字段
            /// </summary>
            /// <value></value>
            public string Sort { get; set; }
            /// <summary>
            /// 排序方式
            /// </summary>
            /// <value></value>
            public string Order { get; set; }
            public string Wheres { get; set; }
            public object Value { get; set; }
        }

        public class SearchParameters
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string DisplayType { get; set; }
        }
    }
}