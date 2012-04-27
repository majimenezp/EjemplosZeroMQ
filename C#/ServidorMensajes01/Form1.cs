using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZMQ;
using System.Threading;
namespace ServidorMensajes01
{
    public partial class Form1 : Form
    {
        private Context contexto;
        private Socket handShake;
        private Socket envioMensajes;
        private byte[] nombreServidor;
        private PollItem[] items = new PollItem[1];
        Thread hiloPoller;
        public Form1()
        {
            InitializeComponent();
            nombreServidor = Encoding.Unicode.GetBytes("ServidorMensajeria");
            contexto = new Context();
            handShake = contexto.Socket(SocketType.REP);
            handShake.Identity = nombreServidor;
            handShake.Bind("tcp://*:5589");
            envioMensajes = contexto.Socket(SocketType.ROUTER);
            envioMensajes.Bind("tcp://*:5590");
            

            items[0] = handShake.CreatePollItem(IOMultiPlex.POLLIN);
            items[0].PollInHandler += new PollHandler(RecepcionHandShake);
            hiloPoller = new Thread(StartReceiver);
            hiloPoller.Start(new StartParameters { context = this.contexto, pollitems = this.items });
            Console.WriteLine("Inicio recepcion");
        }

        void RecepcionHandShake(Socket socket, IOMultiPlex revents)
        {
            var idcliente = socket.Recv();
            socket.Send(nombreServidor);
            MethodInvoker action=delegate { listanodos.Items.Add(Encoding.Unicode.GetString(idcliente));};
            listanodos.BeginInvoke(action);

        }
        private void StartReceiver(object parameters)
        {
            StartParameters pollerParameters = (StartParameters)parameters;
            Console.WriteLine("Se inicio el poller");
            while (true)
            {
                pollerParameters.context.Poll(pollerParameters.pollitems, 0);
            }
        }

        private void btnenviar_Click(object sender, EventArgs e)
        {
            if (listanodos.SelectedIndex < 0)
            {
                if (listanodos.Items.Count > 0)
                {
                    listanodos.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Seleccione un nodo de destino");
                }
            }
            var idDestino=Encoding.Unicode.GetBytes(listanodos.SelectedItem.ToString());
            envioMensajes.SendMore(idDestino);
            envioMensajes.SendMore();
            envioMensajes.Send(txtmensaje.Text,Encoding.Unicode);
            var origen=envioMensajes.Recv(Encoding.Unicode);
            envioMensajes.Recv();
            var registro = envioMensajes.Recv(Encoding.Unicode);
            txtregistro.Text += string.Format("El cliente {0} confirmo de recibido:{1}{2}",origen,registro,Environment.NewLine);
        }
    }
}
