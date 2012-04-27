using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMQ;
namespace ClienteMensajes01
{
    class Program
    {
        static string servidor,nombre;
        static PollItem[] items = new PollItem[1];
        static Socket enviar, recibir;
        static void Main(string[] args)
        {
            Context contexto = new Context();
            enviar= contexto.Socket(SocketType.REQ);
            recibir = contexto.Socket(SocketType.REP);

            Console.WriteLine("Cual es el nombre del cliente");
            nombre=Console.ReadLine();
            recibir.Identity = Encoding.Unicode.GetBytes(nombre);
            enviar.Connect("tcp://127.0.0.1:5589");
            recibir.Connect("tcp://127.0.0.1:5590");
            enviar.Send(Encoding.Unicode.GetBytes(nombre));
            servidor=enviar.Recv(Encoding.Unicode);
            Console.WriteLine("Conectado");

            items[0] = recibir.CreatePollItem(IOMultiPlex.POLLIN);
            items[0].PollInHandler += new PollHandler(RecibirMensaje);
            while (true)
            {
                contexto.Poll(items, -1);
            }
            Console.ReadKey();
            enviar.Dispose();
        }

        static void RecibirMensaje(Socket socket, IOMultiPlex revents)
        {
            var mensaje=socket.Recv(Encoding.Unicode);
            socket.Send("Recibido:" +DateTime.Now.ToString(), Encoding.Unicode);
            Console.WriteLine("Se recibio el mensaje:"+mensaje);
        }
    }
}
