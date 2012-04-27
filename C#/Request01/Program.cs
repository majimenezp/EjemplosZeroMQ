using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMQ;
namespace Request01
{
    class Program
    {
        static void Main(string[] args)
        {
            Context contexto = new Context();
            Socket enviar = contexto.Socket(SocketType.REQ);
            enviar.Connect("tcp://127.0.0.1:12345");
            for (var i = 0; i < 100; i++)
            {
                enviar.Send(i.ToString("###") + ".-¿Que horas son?", Encoding.Unicode);
                var respuesta = enviar.Recv(Encoding.Unicode);
                Console.WriteLine("Respuesta:" + respuesta);
            }
            enviar.Send("FIN", Encoding.Unicode);
            Console.ReadKey();
            enviar.Dispose();
        }
    }
}
