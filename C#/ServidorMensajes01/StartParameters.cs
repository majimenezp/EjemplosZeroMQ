using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMQ;

namespace ServidorMensajes01
{
    class StartParameters
    {
        public Context context { get; set; }
        public PollItem[] pollitems { get; set; }
    }
}
