require "zmq"
context =ZMQ::Context.new(1)
identidad=ARGV[0]
p "app de response:" +identidad
respuestas= context.socket(ZMQ::REP)
respuestas.connect("tcp://127.0.0.1:9000")
loop do
	request = respuestas.recv
	p request
	respuestas.send(Time.now.to_s(),ZMQ::SNDMORE)
	respuestas.send(identidad)

	p "Respuesta enviada"
end
	