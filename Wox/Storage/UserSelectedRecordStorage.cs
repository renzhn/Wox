using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Wox.Infrastructure.Storage;
using Wox.Plugin;
using System.IO;
using System.Reflection;

namespace Wox.Storage
{

    public class UserSelectedRecord {
        public string action { get; set; }
        public int count { get; set; }
    }

    public class UserSelectedRecordStorage : JsonStrorage<UserSelectedRecordStorage>
    {
        [JsonProperty]
        private Dictionary<string, UserSelectedRecord> records = new Dictionary<string, UserSelectedRecord>();

        protected override string ConfigFolder
        {
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Config"); }
        }

        protected override string ConfigName
        {
            get { return "UserSelectedRecords"; }
        }

        public void Add(string query, Result result)
        {
            if (result.SubTitle == null) {
                return;
            }
            if(!records.ContainsKey(query)) {
                UserSelectedRecord record = new UserSelectedRecord();
                record.action = result.SubTitle;
                record.count = 1;
                records[query] = record;
            } else {
                UserSelectedRecord record = records[query];
                if (record.action == result.SubTitle)
                {
                    record.count++;
                }
                else
                {
                    record.action = result.SubTitle;
                    record.count = 1;
                }
            }
            Save();
        }

        public Dictionary<string, UserSelectedRecord> Get(string query)
        {
            Dictionary<string, UserSelectedRecord> selectedRecords = new Dictionary<string, UserSelectedRecord>();
            foreach (KeyValuePair<string, UserSelectedRecord> record in records)
            {
                if (record.Key.StartsWith(query) && record.Value.action != null)
                {
                    if (!selectedRecords.ContainsKey(record.Value.action))
                    {
                        selectedRecords.Add(record.Value.action, record.Value);
                    }
                    else if (record.Value.count > selectedRecords[record.Value.action].count)
                    {
                        selectedRecords[record.Value.action] = record.Value;
                    }
                }
            }
            return selectedRecords;
        }
    }
}
