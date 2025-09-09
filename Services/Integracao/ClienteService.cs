using MongoDB.Driver;
using teste_demarco.Interfaces;
using teste_demarco.Models;
using teste_demarco.Models.Integracao;

namespace teste_demarco.Services.Integracao
{
    public class ClienteService : IClienteService
    {
        private readonly IMongoCollection<Cliente> _clientes;
        private readonly IMongoCollection<LogBase> _logBase;

        public ClienteService(IMongoDatabase database)
        {
            _clientes = database.GetCollection<Cliente>("Clientes");
            _logBase = database.GetCollection<LogBase>("Log");
        }

        public async Task<List<Cliente>> GetAll()
        {
            try
            {
                return await _clientes.Find(c => true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente> Save(ClienteDto entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            try
            {
                await this.VerifyFields(entity);

                var cliente = new Cliente
                {
                    Nome = entity.Nome,
                    Email = entity.Email.ToLower()
                };

                await _clientes.InsertOneAsync(cliente);
                await _logBase.InsertOneAsync(new LogBase 
                { 
                    Acao = "Criação", 
                    DataHora = DateTime.UtcNow, 
                    IdCliente = cliente.Id
                });

                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task VerifyFields(ClienteDto entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Email) || string.IsNullOrWhiteSpace(entity.Nome))
                throw new ArgumentException("O email ou nome não pode ser vazio.");

            var exists = await _clientes.Find(c => c.Email.ToLower() == entity.Email.ToLower())
                                        .AnyAsync();

            if (exists)
                throw new InvalidOperationException($"O email '{entity.Email}' já está cadastrado.");
        }
    }
}
