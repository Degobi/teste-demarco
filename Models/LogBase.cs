using MongoDB.Bson.Serialization.Attributes;

namespace teste_demarco.Models
{
    public class LogBase
    {
        [BsonElement("DataHora")]
        public DateTime DataHora { get; set; }

        [BsonElement("Acao")]
        public string Acao { get; set; }

        [BsonElement("IdCliente")]
        public string IdCliente { get; set; }
    }
}
