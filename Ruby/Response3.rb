require "zmq"
context =ZMQ::Context.new(1)
respuestas= context.socket(ZMQ::PULL)
inicio = Time.now
respuestas.connect("tcp://127.0.0.1:9000")
mensajes=0
loop do
	dato = respuestas.recv
	mensajes+=1
	break if dato=="TERMINADO"	
end
fin = Time.now
p "Se procesaron " + (mensajes/(fin-inicio)).to_s() +" mensajes/segundo"