using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string url = "https://www.mediapool.bg/";

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string htmlContent = await response.Content.ReadAsStringAsync();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            var titleNodes = doc.DocumentNode.SelectNodes("//h3[@class='c-article-item__title']");

            if (titleNodes != null)
            {
                foreach (var titleNode in titleNodes)
                {
                    var title = titleNode.InnerText.Trim();

                    if (Regex.IsMatch(title, @"[ЕС]"))
                    {
                        continue;
                    }

                    Console.WriteLine("Заглавие: " + title);
                    Console.WriteLine("-----------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Не бяха намерени заглавия.");
            }
        }
        else
        {
            Console.WriteLine("Грешка при достъп до сайта. Статус код: " + response.StatusCode);
        }
    }
}
