using Domain.Entities;
using Domain.Documentos;
namespace Domain.Specification
{
    public class ClienteAptoParaCadastro 
    {
        public bool ValidarCPF(Cliente cliente)
        {
            CPFValidation cPFValidation = new CPFValidation();

            if (!cPFValidation.ValidarCPF(cliente))
            {
                cliente.Mensagens.Add("CPF INVÁLIDO");
                return false;
            }
            return cPFValidation.ValidarCPF(cliente); 
        }
        /*
        public bool ValidarDataNascimento(Cliente cliente)
        {
            DataNascimentoValidation dataNascimentoValidation = new DataNascimentoValidation();

            return dataNascimentoValidation.VerificarDataNascimento(cliente.DataNascimentoCliente, 18);
        }
        */
        public bool ValidarEmail(Cliente cliente)
        {
            EmailValidation emailValidation = new EmailValidation();
          
            if (!emailValidation.ValidarFormatoEmail(cliente))
            {
                cliente.Mensagens.Add("EMAIL INVÁLIDO");
                return false;
            }
            return emailValidation.ValidarFormatoEmail(cliente);
        }
    }
}

