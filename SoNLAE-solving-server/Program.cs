using SoNLAE_solving_server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving_server
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            if (args != null && args.Length > 0)
                listener.Prefixes.Add(args[0]);
            else
                listener.Prefixes.Add("http://127.0.0.1/");

            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            while (true)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    response.ContentType = "application/json";

                    string result = new StreamReader(request.InputStream).ReadToEnd();
                    RestDTO requestDTO = RestDTO.Deserialize(result);

                    string responseString = RestDTO.Serialize(new CalculationLogic(requestDTO).Run());
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
                catch(Exception exc) {  }
            }
        }
    }
}
