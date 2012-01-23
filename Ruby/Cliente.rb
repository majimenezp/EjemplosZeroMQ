require "zmq"
context = ZMQ::Context.new(1)
identidad=ARGV[0]
p "iniciando cliente:" +identidad
recepcion= context.socket(ZMQ::PULL)
recepcion.connect("tcp://127.0.0.1:9000")
loop do
	mensaje=recepcion.recv
	recepcion.send(Time.now.to_s())
	p "Respuesta enviada"
end