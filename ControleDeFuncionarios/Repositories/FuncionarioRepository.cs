using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeFuncionarios.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ControleDeFuncionarios.Repositories
{
    /// <summary>
    /// Classe de repositório de banco de dados para a entidade Funcionário
    /// </summary>
    public class FuncionarioRepository
    {
        //Método para inserir um novo funcionário no banco de dados
        public void Inserir(Funcionario funcionario)
        {
            //Declarar uma variavel para armazenar a connectionstring
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDFuncionarios;Integrated Security=True;";

            //Abrir uma conexão com o banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
              connection.Execute("SP_INSERIR_FUNCIONARIO",new
                {
                    @NOME = funcionario.Nome,
                    @DATAADIMISSAO = funcionario.DataAdimissao,
                    @CPF = funcionario.Cpf,
                    @MATRICULA = funcionario.Matricula,
                    @SALARIO = funcionario.Salario,
                    @CARGO = (int)funcionario.Cargo,
                    @LAGRADOURO = funcionario.Endereco.Logradouro,
                    @NUMERO = funcionario.Endereco.Numero,
                    @BAIRRO = funcionario.Endereco.Bairro,
                    @LOCALIDADE = funcionario.Endereco.Localidade,
                    @UF = funcionario.Endereco.Uf,
                    @CEP = funcionario.Endereco.Cep
                },
                commandType: CommandType.StoredProcedure);
            }
        }
    }
}

