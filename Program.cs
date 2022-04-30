using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

namespace Operating_System_Task3
{
    class Program
    {

        public static void Answer(object AAA)
        {
            HttpListenerContext context = (HttpListenerContext)AAA;
            HttpListenerResponse response = context.Response;

            string page = @"../../index.html";

            TextReader txtrt = new StreamReader(page);
            string outPut = txtrt.ReadToEnd();

            byte[] buffer = Encoding.UTF8.GetBytes(outPut);

            response.ContentLength64 = buffer.Length;
            Stream strm = response.OutputStream;
            strm.Write(buffer, 0, buffer.Length);

            context.Response.Close();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Thread complete, sleeping.");
            Console.ResetColor();
            Thread.Sleep(5000);
            return;
        }
        static void Main(string[] args)
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://127.0.0.1:8888/");
            server.Prefixes.Add("http://localhost:8888/");

            server.Start();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Listening...\n");
            Console.ResetColor();


            while (true)
            {
                HttpListenerContext context = server.GetContext();

                Thread r = new Thread(Program.Answer);
                r.Start(context);
            }
        }
    }
}





