using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFuncionarios.Service
{
    /// <summary>
    /// Classe de serviço para integração com a API ViaCep
    /// </summary>
    public class ViaCepService
    {
        //Método para obter o endereço a partir do CEP
        public string ObterEndereco(string cep)
        {
            using(var client = new HttpClient())
            {
                //fazendo uma chamada oara o serviço de consulta ViaCep
                var response = client.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;

                //Retornando o conteúdo JSON obtido da consulta
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
