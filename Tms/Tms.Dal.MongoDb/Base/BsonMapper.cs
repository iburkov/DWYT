using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Tms.Domain.Base;

namespace Tms.Dal.MongoDb.Base
{
    public static class BsonMapper
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<EntityBaseWithStringKey> (cm =>
            {
                cm.AutoMap();

                cm.IdMemberMap
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);

                cm.MapProperty(m => m.CreatedAt)
                    .SetSerializer(new DateTimeSerializer(DateTimeKind.Utc));

                cm.MapProperty(m => m.ModifiedAt)
                    .SetSerializer(new DateTimeSerializer(DateTimeKind.Utc));
            });
        }
    }
}