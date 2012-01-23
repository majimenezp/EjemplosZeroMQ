require "zmq"
contexto = ZMQ::Context.new(1)

envio=contexto.socket(ZMQ::PUSH)
envio.bind("tcp://127.0.0.1:9000")

for i in 1..100000 do
	envio.send("Mensaje numero:" +i.to_s())
end
envio.send("TERMINADO")
p "Envio terminado"