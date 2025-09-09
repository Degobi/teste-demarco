using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace teste_demarco.Models.Integracao
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}
