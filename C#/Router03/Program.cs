using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMQ;
using System.Threading;
namespace Router03
{
    class Program
    {
        private static PollItem[] items = new PollItem[2];
        private static Thread hiloPoller;
        private static Socket router,dealer;
        static void Main(string[] args)
        {
            
            Context contexto = new Context();
            router = contexto.Socket(SocketType.ROUTER);
            dealer = contexto.Socket(SocketType.DEALER);
            router.Identity = Guid.NewGuid().ToByteArray();
            router.Bind("tcp://*:5589");
            dealer.Bind("tcp://*:5590");
            items[0] = router.CreatePollItem(IOMultiPlex.POLLIN);
            items[1] = dealer.CreatePollItem(IOMultiPlex.POLLIN);

            items[0].PollInHandler += new PollHandler(RecepcionRouter);
            items[1].PollInHandler+= new PollHandler(RecepcionDealer);
            //hiloPoller = new Thread(IniciarRecepcion);
            //hiloPoller.Start(new ParametrosInicio { context = contexto, pollitems = items });
            while (true)
            {
                contexto.Poll(items, -1);
            }
        }

        private static void IniciarRecepcion(Object parametros)
        {
            ParametrosInicio parametroPoller = (ParametrosInicio)parametros;
            Console.WriteLine("Se inicio el poller del router");
            while (true)
            {
                parametroPoller.context.Poll(parametroPoller.pollitems, -1);
            }
        }

        static void RecepcionRouter(Socket socket, IOMultiPlex revents)
        {
            //Repetidor(socket, dealer);
            var datos = socket.Recv();
            Guid identidad = new Guid(datos);
            if (socket.RcvMore)
            {
            //    //delimitador vacio
                socket.Recv();
                var mensaje = socket.Recv(Encoding.Unicode);
                Console.WriteLine("Se recibio el mensaje en el router:" + mensaje);
                EnviarAWorker(identidad, mensaje);
            }
        }

        private static void Repetidor(Socket origen, Socket destino)
        {
            bool faltan = true;
            while (faltan)
            {
                var mensaje = origen.Recv();
                faltan = origen.RcvMore;
                destino.Send(mensaje, faltan ? SendRecvOpt.SNDMORE : SendRecvOpt.NONE);
            }
        }

        private static void EnviarAWorker(Guid identidad, string mensaje)
        {
            //Envio la identidad del origen
            dealer.SendMore(identidad.ToByteArray());
            //delimitador
            dealer.SendMore(string.Empty, Encoding.Unicode);
            dealer.Send(mensaje, Encoding.Unicode);
        }

        static void RecepcionDealer(Socket socket, IOMultiPlex revents)
        {
            //Repetidor(socket,router );
            var datos = socket.Recv();
            string mensaje = string.Empty;
            Guid identidad = new Guid(datos);
            if (socket.RcvMore)
            {
                //delimitador vacio
                socket.Recv();
                mensaje = socket.Recv(Encoding.Unicode);
                Console.WriteLine("Se recibio el mensaje en el dealer:" + mensaje);
            }
            router.SendMore(datos);
            router.SendMore(string.Empty, Encoding.Unicode);
            router.Send(mensaje, Encoding.Unicode);
        }
    }
}
