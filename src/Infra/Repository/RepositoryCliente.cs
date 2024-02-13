using System;
using Domain.Entities;
using Domain.Repository;
using Infra.Context;
using MySql.Data.MySqlClient;

namespace Infra.RepositoryCrud
{
	public class RepositoryCliente : Repository<Cliente>, IClienteRepository
    {
		public RepositoryCliente(ConexaoBanco context)
            :base(context)
		{
		}

        public IEnumerable<Cliente> ObterAtivos()
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            string query = "SELECT * FROM usuario where cpf='" + cpf + "'";

            var conn = BD.OpenConnection();

            Cliente cliente = new Cliente();

            var reader = BD.command(query, conn);
            while (reader.Read())
            {
                cliente.id = reader.GetInt32("idCliente");
                cliente.Nome = reader.GetString("NomeCliente");
                cliente.EmailCliente = reader.GetString("EmailCliente");
                cliente.TelefoneCliente = reader.GetString("TelefoneCliente");
                cliente.DataCadastroCliente = reader.GetDateTime("DataCadastroCliente");
                cliente.DataNascimentoCliente = reader.GetDateTime("DataNascimentoCliente");
                cliente.Cpf = reader.GetString("cpf");


            }
            BD.CloseConnection(conn);
            return cliente;
        }

        public Cliente ObterPorEmail(string email)
        {
            string query = "SELECT * FROM usuario where EmailCliente='" + email + "'";

            var conn = BD.OpenConnection();

            Cliente cliente = new Cliente();
           
            var reader = BD.command(query, conn);
            while (reader.Read())
            {
                cliente.id = reader.GetInt32("idCliente");
                cliente.Nome = reader.GetString("NomeCliente");
                cliente.EmailCliente = reader.GetString("EmailCliente");
                cliente.TelefoneCliente = reader.GetString("TelefoneCliente");
                cliente.DataCadastroCliente = reader.GetDateTime("DataCadastroCliente");
                cliente.DataNascimentoCliente = reader.GetDateTime("DataNascimentoCliente");
                cliente.Cpf = reader.GetString("cpf");


            }
            BD.CloseConnection(conn);
            return cliente;
        }

        public override void Remover(int id)
        {
            string connectionString = "Server=localhost;Database=Crud;User ID=root;Password=root;";

            // Cria uma nova conexão
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                // Abre a conexão
                connection.Open();

                // Cria um comando SQL DELETE
                string deleteQuery = "DELETE FROM usuario WHERE idCliente = @idCliente";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@idCliente", id);
                    int rowsAffected = cmd.ExecuteNonQuery();


                }

            }

        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            string query = "SELECT idCliente, NomeCliente, EmailCliente, TelefoneCliente, DataCadastroCliente, DataNascimentoCliente FROM usuario";

            var conn = BD.OpenConnection();

            Cliente cliente = new Cliente();
            List<Cliente> l = new List<Cliente>(); 
            var reader = BD.command(query, conn);
            while (reader.Read())
            {
                l.Add(new Cliente
                {
                    id = reader.GetInt32("idCliente"),
                    Nome = reader.GetString("NomeCliente"),
                    EmailCliente = reader.GetString("EmailCliente"),
                    TelefoneCliente = reader.GetString("TelefoneCliente"),
                    DataCadastroCliente = reader.GetDateTime("DataCadastroCliente"),
                    DataNascimentoCliente = reader.GetDateTime("DataNascimentoCliente")
                });
          
            }
            BD.CloseConnection(conn);
            return l; 
        }

        public override Cliente ObterPorId(int id)
        {

            string query = "SELECT idCliente, NomeCliente, EmailCliente, TelefoneCliente, DataCadastroCliente, DataNascimentoCliente FROM usuario Where idCliente=" + id;

            var conn = BD.OpenConnection();

            Cliente cliente = new Cliente();
          
            var reader = BD.command(query, conn);
            while (reader.Read())
            {
                cliente.id = reader.GetInt32("idCliente");
                cliente.Nome = reader.GetString("NomeCliente");
                cliente.EmailCliente = reader.GetString("EmailCliente");
                cliente.TelefoneCliente = reader.GetString("TelefoneCliente");
                cliente.DataCadastroCliente = reader.GetDateTime("DataCadastroCliente");
                cliente.DataNascimentoCliente = reader.GetDateTime("DataNascimentoCliente");
              
            }
            BD.CloseConnection(conn);
            return cliente;

        }

        public override Cliente Adicionar(Cliente obj)
        {

            string connectionString = "Server=localhost;Database=Crud;User ID=root;Password=root;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Construa a instrução UPDATE com parâmetros
                string insertQuery = "INSERT INTO usuario (NomeCliente, EmailCliente, TelefoneCliente, DataNascimentoCliente,cpf) VALUES (@NomeCliente, @EmailCliente, @TelefoneCliente, @DataNascimentoCliente,@cpf)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    // Adicione parâmetros à consulta
                    command.Parameters.AddWithValue("@NomeCliente", obj.Nome);
                    command.Parameters.AddWithValue("@EmailCliente", obj.EmailCliente);
                    command.Parameters.AddWithValue("@TelefoneCliente", obj.TelefoneCliente);
                    command.Parameters.AddWithValue("@DataNascimentoCliente", obj.DataNascimentoCliente);
                    command.Parameters.AddWithValue("@cpf", obj.Cpf);

                    // Execute o comando de atualização
                    command.ExecuteNonQuery();
                    obj.id = (int)command.LastInsertedId;

                }
                return obj;
            }


            /*
            string insertQuery = "INSERT INTO usuario (NomeCliente, EmailCliente, TelefoneCliente, DataNascimentoCliente) VALUES (@NomeCliente, @EmailCliente, @TelefoneCliente, @DataNascimento)";
            var conn = BD.OpenConnection();
            var command = BD.Insert(insertQuery, conn);

            // Adicione parâmetros à consulta
            command.Parameters.AddWithValue("@NomeCliente", obj.Nome);
            command.Parameters.AddWithValue("@EmailCliente", obj.EmailCliente);
            command.Parameters.AddWithValue("@TelefoneCliente", obj.TelefoneCliente);
            command.Parameters.AddWithValue("@DataNascimentoCliente", obj.DataNascimentoCliente);


            // Execute o comando de inserção
            obj.id = command.ExecuteNonQuery();
            BD.CloseConnection(conn);
            */
         //  return obj;
        }

        public override Cliente Atualizar(Cliente obj)
        {
            
            string connectionString = "Server=localhost;Database=Crud;User ID=root;Password=root;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Construa a instrução UPDATE com parâmetros
                string updateQuery = "UPDATE usuario SET NomeCliente = @NomeCliente, EmailCliente = @EmailCliente, TelefoneCliente = @TelefoneCliente, DataNascimentoCliente = @DataNascimentoCliente  WHERE idCliente = @idCliente";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    // Adicione parâmetros à consulta
                    command.Parameters.AddWithValue("@NomeCliente", obj.Nome);
                    command.Parameters.AddWithValue("@idCliente", obj.id);
                    command.Parameters.AddWithValue("@EmailCliente", obj.EmailCliente);
                    command.Parameters.AddWithValue("@TelefoneCliente", obj.TelefoneCliente);
                    command.Parameters.AddWithValue("@DataNascimentoCliente", obj.DataNascimentoCliente);

                    // Execute o comando de atualização
                    obj.id = command.ExecuteNonQuery();

                   
                }
            }
            

         /*
                var conn = BD.OpenConnection();
                string updateQuery = "UPDATE usuario SET NomeCliente = @NomeCliente  WHERE idCliente = @idCliente";
                var command = BD.Insert(updateQuery, conn);

                // Adicione parâmetros à consulta
                command.Parameters.AddWithValue("@NomeCliente", obj.Nome);
                command.Parameters.AddWithValue("@idCliente", obj.id);

                // Execute o comando de atualização
                obj.id = command.ExecuteNonQuery();
                BD.CloseConnection(conn);
         */
           

            return obj;
        }

        public override void Dispose()
        {
            
        }
    }
}

