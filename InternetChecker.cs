using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

class InternetChecker
{
    private static async Task<bool> IsInternetAvailableAsync()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(2);
                HttpResponseMessage response = await client.GetAsync("https://clients3.google.com/generate_204");
                return response.IsSuccessStatusCode;
            }
        }
        catch
        {
            return false;
        }
    }

    public static async Task EnsureInternetAsync()
    {
        while (!await IsInternetAvailableAsync())
        {
            MessageBox.Show(
                "No internet connection detected. Please connect to the internet and click OK to retry.",
                "Internet Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }
}
