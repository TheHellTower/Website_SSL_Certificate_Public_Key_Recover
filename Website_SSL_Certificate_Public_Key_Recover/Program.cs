using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Website_SSL_Certificate_Public_Key_Recover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Website(ex: https://google.com): ");
            string website = Console.ReadLine();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(website);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();

            X509Certificate2 cert = new X509Certificate2(request.ServicePoint.Certificate);
            File.WriteAllText("target_key.txt", cert.GetPublicKeyString());
        }
    }
}
