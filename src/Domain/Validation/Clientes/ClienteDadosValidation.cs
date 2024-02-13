using Domain.Specification;
using Domain.Entities;

namespace Domain.Validation.Clientes
{
    public class ClienteDadosValidation
    {

        ClientePersistirDados persistirDados = new ClientePersistirDados();
        
        public bool pers(Cliente cliente)
        {

            if (!persistirDados.PersistirDadosCliente(cliente))
            {
                cliente.Mensagens.Add("Informe os dados para o cadastro");
                return false;
            }
            return persistirDados.PersistirDadosCliente(cliente);

        }

    }
}

