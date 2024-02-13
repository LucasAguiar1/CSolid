using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Infra.Context
{
	public class ConexaoBanco
    {
        public MySqlConnection OpenConnection()
        {
            

            string connectionString = "Server=localhost;Database=Crud;User ID=root;Password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public MySqlDataReader command(string query, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
           
            return reader;
        }


        public void CloseConnection(MySqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlCommand Insert(string insert, MySqlConnection connection)
        {

            string insertQuery = "INSERT INTO usuario (NomeCliente, EmailCliente, TelefoneCliente, DataNascimentoCliente) VALUES (@Nome, @Email, @Telefone, @DataNascimento)";

            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            return command; 
        }
    }
}

