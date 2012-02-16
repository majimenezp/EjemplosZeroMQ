require "zmq"
context =ZMQ::Context.new(1)
p "app de request"
envio=context.socket(ZMQ::REQ)
envio.bind("tcp://127.0.0.1:9001")
for i in 1..50 do
    envio.send(i.to_s() +".-Que horas son?")
    p "Peticion enviada"
    respuesta = envio.recv
    if envio.getsockopt(ZMQ::RCVMORE)
        identClient=envio.recv
    end
    p "Enviada por:" + identClient +" Resp:" +respuesta
    sleep(0.5)
end
p "Termino el envio de mensajes"
