using System;
using System.Text;
using System.Configuration;
using System.Net;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace Business
{
    public class Marvel
    {
        public Personagem obterDadosPersonagem(string nomePersonagem)
        {
            WebClient w = new WebClient();
            Personagem personagem;

            string json_data;
            string ts = DateTime.Now.Ticks.ToString();
            string url = ConfigurationManager.AppSettings["URL"];
            string chavePublica = ConfigurationManager.AppSettings["chavePublica"];
            string chavePrivada = ConfigurationManager.AppSettings["chavePrivada"];
            string hash = GerarHash(ts, chavePublica, chavePrivada);

            json_data = w.DownloadString($"{url}characters?ts={ts}&apikey={chavePublica}&hash={hash}&name={nomePersonagem}");

            JObject buscaPersonagem = JObject.Parse(json_data);
            JToken resultado = buscaPersonagem["data"]["results"];

            personagem = new Personagem();
            personagem.Nome = resultado[0]["name"].ToString();
            personagem.Descricao = resultado[0]["description"].ToString();

            JToken imagem = resultado[0]["thumbnail"];

            personagem.UrlImagem = imagem["path"].ToString() + "." + imagem["extension"].ToString();

            JToken urls = resultado[0]["urls"];

            personagem.UrlWiki = urls[1]["url"].ToString();

            return personagem;
        }

        private string GerarHash(string ts, string chavePublica, string chavePrivada)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ts + chavePrivada + chavePublica);
            MD5 gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);
        }
    }
}
