using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace WorkApp.csharp
{
   public static class Network
   {


        public static async Task<List<User>> LoadJSON()
        {
            HttpClient client = new HttpClient();
            string url = "http://jsonplaceholder.typicode.com/posts";//хардкод
            HttpResponseMessage response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<User>>(json);          
        }
    }
}