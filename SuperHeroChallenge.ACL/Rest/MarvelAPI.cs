using Newtonsoft.Json;
using SuperHero.Marvel.ACL.Interfaces;
using SuperHero.Marvel.ACL.Model;
using SuperHero.Marvel.ACL.Model.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace SuperHero.Marvel.ACL.Rest
{
    public class MarvelAPI : IMarvelAPI
    {
        private static string BASE_URL = "https://gateway.marvel.com";
        private static string publicKey = "7ed3396a98946a347c2d64481098d968";
        private static string privateKey = "8ae9acd315ed35e4ef7cbebd3c2dc127a7061586";
        private static HttpClient httpClient = new HttpClient();
        private static string ts = DateTime.Now.Ticks.ToString();
        private static string hash = GerarHash(ts, publicKey, privateKey);

        public CharacterMarvelResponse GetCharacter(string name)
        {
            try
            {
                HttpResponseMessage responseApi = httpClient.GetAsync($"{BASE_URL}/v1/public/characters?name={name}&ts={ts}&apikey={publicKey}&hash={hash}").Result;

                if (responseApi.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(responseApi.Content.ReadAsStringAsync().Result);
                }

                responseApi.EnsureSuccessStatusCode();
                string conteudo = responseApi.Content.ReadAsStringAsync().Result;
                dynamic data = JsonConvert.DeserializeObject(conteudo);

                var dataResult = JsonConvert.SerializeObject(data["data"]["results"][0]);
                var characterModel = JsonConvert.DeserializeObject<CharacterMarvelModel>(dataResult);

                var events = GetCharacterEvents(characterModel.Id);

                var response = new CharacterMarvelResponse(characterModel, events);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<EventsModel> GetCharacterEvents(int id)
        {
            try
            {
                HttpResponseMessage response = httpClient.GetAsync($"{BASE_URL}/v1/public/characters/{id}/events?&ts={ts}&apikey={publicKey}&hash={hash}").Result;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                response.EnsureSuccessStatusCode();
                string conteudo = response.Content.ReadAsStringAsync().Result;
                dynamic data = JsonConvert.DeserializeObject(conteudo);

                var dataResult = JsonConvert.SerializeObject(data["data"]["results"]);
                var listEvents = JsonConvert.DeserializeObject<List<EventsModel>>(dataResult);


                return listEvents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private static string GerarHash(string ts, string publicKey, string privateKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ts + privateKey + publicKey);

            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);

            return BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);
        }

    }
}
