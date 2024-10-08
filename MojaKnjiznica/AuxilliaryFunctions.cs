using System.Net.Http;

namespace MojaKnjiznica
{
    public class AuxilliaryFunctions
    {
        /// <summary>
        /// Funkcija vrne posebno vsoto.
        /// </summary>
        public static int Vsota(int x, int y)
        {
            return 2 * x + y;
        }

        /// <summary>
        /// Za dani števili funkcija vrne njun največji skupni delitelj.
        /// </summary>
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Za dani števili funkcija vrne njun najmanjši skupni večkratnik.
        /// </summary>
        public static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }

        /// <summary>
        /// Prebere vir spletne strani na naslovu url in ga vrne.
        /// </summary>
        public static string ReadWebPageSource(string url)
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync(url).Result;

            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
