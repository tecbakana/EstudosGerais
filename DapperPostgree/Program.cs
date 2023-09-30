using System;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace DapperPostgree
{
    public class Program
    {
        private static string connString = "User ID=postgres;Password=su74;Host=localhost;Port=5432;Database=cmsxDB;";
        public static void Main(string[] args)
        {
            CadastrarCliente("Samanta", 22);
            CadastrarCliente("adelmo",35);
        }

        public static void CadastrarCliente(string clienteNome, int clienteIdade)
        {
            int result=0;
            using (var connection = new NpgsqlConnection(connString))
            {
                var sql = $"insert into tbl_cliente(nome, idade) values('{clienteNome}',{clienteIdade})";
                if(connection.Query($"select nome from tbl_cliente where nome='{clienteNome}'").Count() <= 0)
                    result = connection.Execute(sql) ;
            }

            Console.WriteLine(result==0?$"Usuario {clienteNome} já existe!":$"Usuario {clienteNome} cadastrado com sucesso!");
            
        }

        public static bool ValidaCliente(string clienteNome)
        {
            using(var conn = new NpgsqlConnection(connString))
            {
                return conn.Query($"select nome from tbl_cliente where nome='{clienteNome}'").Count() > 0? true : false;
            }
        }
    }
}
