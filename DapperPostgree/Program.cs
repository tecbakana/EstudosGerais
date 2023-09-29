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
            ConsultarCliente("marcio", 35);
            ConsultarCliente("adelmo",35);
        }

        public static void ConsultarCliente(string clienteNome, int clienteIdade)
        {
            if (!ValidaCliente(clienteNome))
            { 
                using (var connection = new NpgsqlConnection(connString))
                {
                    var sql = $"insert into tbl_cliente(nome, idade) values('{clienteNome}',{clienteIdade})";
                    int result = connection.Execute(sql) ;
                }
            }
        }

        public static bool ValidaCliente(string clienteNome)
        {
            using(var conn = new NpgsqlConnection(connString))
            {
                var sql = $"select nome from tbl_cliente where nome='{clienteNome}'";

                return conn.Query(sql).Count() > 0? true : false;
            }
        }
    }
}
