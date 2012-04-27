using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMQ;
using System.Threading;
namespace Request02
{
    class Program
    {
        static void Main(string[] args)
        {
            Context contexto = new Context();
            Socket enviar = contexto.Socket(SocketType.REQ);
            enviar.Bind("tcp://127.0.0.1:12345");
            for (var i = 0; i < 100; i++)
            {
                enviar.Send(i.ToString("###") + ".-¿Que horas son?", Encoding.Unicode);
                Thread.Sleep(100);
                var respuesta = enviar.Recv(Encoding.Unicode);
                Console.WriteLine("Respuesta al mensaje " +i.ToString("###") + " "+ respuesta);
            }
            enviar.Send("FIN", Encoding.Unicode);
            Console.ReadKey();
            enviar.Dispose();
        }
    }
}
