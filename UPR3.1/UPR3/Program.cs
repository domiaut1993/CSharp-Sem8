using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Въведете IP адрес:");
        string ipAddress = Console.ReadLine();

        if (string.IsNullOrEmpty(ipAddress) || !Uri.IsWellFormedUriString($"http://{ipAddress}", UriKind.Absolute))
        {
            Console.WriteLine("Невалиден IP адрес.");
            return;
        }

        string url = $"https://ipapi.co/{ipAddress}/country/";

        await GetCountryFromUrl(url);

        await Task.Delay(2000);

        await GetCountryFromUrl(url);
    }

    static async Task GetCountryFromUrl(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"Държава за IP {url}: {content.Trim()}");
                }
                else
                {
                    Console.WriteLine($"Грешка при достъп до {url}. Статус код: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Възникна грешка: {ex.Message}");
            }
        }
    }
}
