require "zmq"
context =ZMQ::Context.new(1)
p "app de response"
respuestas= context.socket(ZMQ::REP)
respuestas.bind("tcp://127.0.0.1:9000")
loop do
	request = respuestas.recv
	p request
	respuestas.send(Time.now.to_s())
	p "Respuesta enviada"
end
	