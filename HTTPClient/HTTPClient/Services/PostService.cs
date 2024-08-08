using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    public class PostService
    {
        private HttpClient httpClient;
        private List<Post> posts;
        private JsonSerializerOptions jsonSerializerOptions;

        public PostService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Post>> GetPostsAsync() 
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode) {
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<List<Post>>(content, jsonSerializerOptions);
                }
            }
            catch
            {

            }
            return posts;
        }

    }
}
