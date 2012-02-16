require "zmq"
context =ZMQ::Context.new(1)
p "app de request"
envio=context.socket(ZMQ::REQ)
envio.connect("tcp://127.0.0.1:9001")
for i in 1..5 do
    envio.send(i.to_s() +".-Que horas son?")
    p "Peticion enviada"
    respuesta = envio.recv
    p respuesta
end
p "Termino el envio de mensajes"
