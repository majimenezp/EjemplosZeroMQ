using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMQ;
namespace Response03
{
    class Program
    {
        static void Main(string[] args)
        {
            Context contexto = new Context();
            Socket respuestas = contexto.Socket(SocketType.REP);
            respuestas.Identity = Guid.NewGuid().ToByteArray() ;
            respuestas.Connect("tcp://127.0.0.1:5590");
            while (true)
            {
                var pregunta = respuestas.Recv(Encoding.Unicode);
                Console.WriteLine("Respuesta para el mensaje:" + pregunta);
                respuestas.Send(DateTime.Now.ToString(), Encoding.Unicode);
                
            }
            respuestas.Dispose();
        }
    }
}
