using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ControleDeFuncionarios.Entities;
using ControleDeFuncionarios.Service;

namespace ControleDeFuncionarios.Controllers
{
    /// <summary>
    /// Controlador de Funcionários
    /// </summary>
    public class FuncionarioController
    {

        // Cadastra novo funcionário no sistema
        public void CdastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\n CADASTRO DE FUNCIONÁRIO:\n");

                //Criando um objeto da classe Funcionário
                var funcionario = new Funcionario();

                Console.Write("NOME DO FUNCIONÁRIO.....:");
                funcionario.Nome = Console.ReadLine() ?? string.Empty;
                Console.Write("CPF.................: ");
                funcionario.Cpf = Console.ReadLine() ?? string.Empty;
                Console.Write("MATRÍCULA...........: ");
                funcionario.Matricula = Console.ReadLine() ?? string.Empty;
                Console.Write("DATA DE ADMISSÃO.....: ");
                funcionario.DataAdimissao = DateTime.Parse(Console.ReadLine() ?? string.Empty);
                Console.Write("SALÁRIO.............: ");
                funcionario.Salario = Decimal.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("INFORME O CPE...........: ");
                var cep = Console.ReadLine() ?? string.Empty;

                //Criando um objeto da classe de serviço
                var viaCepService = new ViaCepService();

                //Consultando o endereço a partir do CEP
                var endereco = viaCepService.ObterEndereco(cep);

                //Imprimindo o endereço no console
                Console.WriteLine("\nENDEREÇO OBTIDO:\n");
                Console.WriteLine(endereco);

                //Ler os campos do endereço contido no JSON retornado pelo ViaCep
                var json = JsonDocument.Parse(endereco);

                funcionario.Endereco.Logradouro = json.RootElement.GetProperty("logradouro").GetString() ?? string.Empty;
                funcionario.Endereco.Bairro = json.RootElement.GetProperty("bairro").GetString() ?? string.Empty;
                funcionario.Endereco.Localidade = json.RootElement.GetProperty("localidade").GetString() ?? string.Empty;
                funcionario.Endereco.Uf = json.RootElement.GetProperty("uf").GetString() ?? string.Empty;
                funcionario.Endereco.Cep = json.RootElement.GetProperty("cep").GetString() ?? string.Empty;


                Console.Write("\nINFORME O NÚMERO DO ENDEREÇO: ");
                funcionario.Endereco.Numero = Console.ReadLine() ?? string.Empty;

            }
            catch (Exception e)
            {
                Console.WriteLine($"\n Falha ao cadastrar funcionário: {e.Message}");
            }
        }
    }
}
