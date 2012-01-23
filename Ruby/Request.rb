require "zmq"
context =ZMQ::Context.new(1)
p "app de request"
envio=context.socket(ZMQ::REQ)
envio.connect("tcp://127.0.0.1:9000")
for i in 1..100 do
	envio.send(i.to_s() +".-Que horas son?")
	respuesta = envio.recv
	p respuesta
	p "enviado"
end
p "Termino el envio de mensajes"