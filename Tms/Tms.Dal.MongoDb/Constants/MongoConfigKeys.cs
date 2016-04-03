using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tms.Dal.MongoDb.Constants
{
    internal sealed class MongoConfigKeys
    {
        public const string MongoSection = "mongoSettings";

        public const string MongoConnectionString = "MongoConnectionString";

        public const string MongoDatabase = "MongoDatabase";
    }
}
