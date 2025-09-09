using teste_demarco.Models.Integracao;

namespace teste_demarco.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAll();

        Task<Cliente> Save(ClienteDto entity);
    }
}
