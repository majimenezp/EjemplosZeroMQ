using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMQ;
namespace Response01
{
    class Program
    {
        static void Main(string[] args)
        {
            Context contexto = new Context();
            Socket respuestas = contexto.Socket(SocketType.REP);
            respuestas.Bind("tcp://127.0.0.1:12345");
            while(true)
            {
                var pregunta=respuestas.Recv(Encoding.Unicode);
                if(pregunta=="FIN")
                {
                    break;
                }
                respuestas.Send(DateTime.Now.ToString(),Encoding.Unicode);
                Console.WriteLine("Respuesta para el mensaje:" +pregunta);
            }
            Console.ReadKey();
            respuestas.Dispose();
        }
    }
}
