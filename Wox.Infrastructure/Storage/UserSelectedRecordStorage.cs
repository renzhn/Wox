using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Wox.Infrastructure.Storage;
using Wox.Plugin;

namespace Wox.Infrastructure.Storage
{
    public class UserSelectedRecordStorage : JsonStrorage<UserSelectedRecordStorage>
    {
        [JsonProperty]
        private Dictionary<string, string> records = new Dictionary<string, string>();

        protected override string ConfigName
        {
            get { return "UserSelectedRecords"; }
        }

        public void Add(string query, Result result)
        {
            records[query] = result.SubTitle;
            Save();
        }

        public string Get(string query)
        {
            if (records.ContainsKey(query))
            {
                return records[query];
            }
            return null;
        }
    }
}
