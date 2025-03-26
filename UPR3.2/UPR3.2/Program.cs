using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string url = "https://www.timeanddate.com/worldclock/bulgaria/sofia";

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string htmlContent = await response.Content.ReadAsStringAsync();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            var timeNode = doc.GetElementbyId("ct");

            if (timeNode != null)
            {
                string currentTime = timeNode.InnerText.Trim();
                Console.WriteLine("Текущо време в София: " + currentTime);
            }
            else
            {
                Console.WriteLine("Не беше намерено време на страницата.");
            }
        }
        else
        {
            Console.WriteLine("Грешка при достъп до страницата. Статус код: " + response.StatusCode);
        }
    }
}
