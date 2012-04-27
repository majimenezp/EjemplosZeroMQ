using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMQ;
namespace Request03
{
    class Program
    {
        static void Main(string[] args)
        {
            Context contexto = new Context();
            Socket enviar = contexto.Socket(SocketType.REQ);
            enviar.Identity = Guid.NewGuid().ToByteArray();
            enviar.Connect("tcp://127.0.0.1:5589");
            for (var i = 0; i < 1000; i++)
            {
                enviar.Send(i.ToString("###") + ".-¿Que horas son?", Encoding.Unicode);
                var respuesta = enviar.Recv(Encoding.Unicode);
                Console.WriteLine("Respuesta:" + respuesta);
            }
            Console.ReadKey();
            enviar.Dispose();
        }
    }
}
