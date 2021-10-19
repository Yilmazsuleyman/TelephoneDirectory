using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelephoneDirectory.Models
{
    public class TelephoneDirectoryDatabaseSettings : ITelephoneDirectoryDatabaseSettings
    {
        public string PersonCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string ReportCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITelephoneDirectoryDatabaseSettings
    {
        public string PersonCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string ReportCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
