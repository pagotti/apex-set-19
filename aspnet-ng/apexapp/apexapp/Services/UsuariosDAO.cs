using apexapp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace apexapp.Services
{
    public class UsuariosDAO
    {

        private string string_conexao = ApexAppContext.Configuration.GetConnectionString("ApexApp");

        public List<Usuario> RetornarUsuarios()
        {
            string sql = "SELECT id, nome, idade FROM Usuarios";
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection conexao = new SqlConnection(string_conexao))
            {
                conexao.Open();
                using (SqlCommand command = new SqlCommand(sql, conexao))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var usuario = new Usuario()
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Idade = reader.GetInt32(2)
                        };
                        usuarios.Add(usuario);
                    }
                    reader.Close();
                }
            };
            return usuarios;

        }

        public void AlterarUsuario(int id, Usuario value)
        {
            string sql = "update Usuarios set nome = @nome, idade = @idade where id = @id";
            using (SqlConnection conexao = new SqlConnection(string_conexao))
            {
                conexao.Open();
                using (SqlCommand command = new SqlCommand(sql, conexao))
                {
                    command.Parameters.Add(new SqlParameter("id", id));
                    command.Parameters.Add(new SqlParameter("nome", value.Nome));
                    command.Parameters.Add(new SqlParameter("idade", value.Idade));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AdicionarUsuario(Usuario value)
        {
            string sql = "insert into Usuarios (nome, idade) values (@nome, @idade)";
            using (SqlConnection conexao = new SqlConnection(string_conexao))
            {
                conexao.Open();
                using (SqlCommand command = new SqlCommand(sql, conexao))
                {
                    command.Parameters.Add(new SqlParameter("nome", value.Nome));
                    command.Parameters.Add(new SqlParameter("idade", value.Idade));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirUsuario(int id)
        {
            string sql = "delete from Usuarios where id = @id";
            using (SqlConnection conexao = new SqlConnection(string_conexao))
            {
                conexao.Open();
                using (SqlCommand command = new SqlCommand(sql, conexao))
                {
                    command.Parameters.Add(new SqlParameter("id", id));
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
