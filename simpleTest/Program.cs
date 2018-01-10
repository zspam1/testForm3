using System;
using System.Threading.Tasks;
using System.Net.Http;
using CoreRSS.Domain;
using CoreRSS.Concrete.Parsers;

namespace simpleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = LoadURLAsync("http://news.gbzph.com/rssa/n_3_0.xml").Result;
            Console.WriteLine("Hello World!"+s);
            var parser = new RSSFeedParser("");
            var rss = parser.ParseXml(s);
            //

        }

        public static async Task<String> LoadAsync(String page) {
            String s = await LoadURLAsync(page).ConfigureAwait(false);
            return s;
        }

        public static async Task<string> LoadURLAsync(String page)
        {
            string result = null;

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                result = await content.ReadAsStringAsync();

            }
            return result;

        }
    }
}
