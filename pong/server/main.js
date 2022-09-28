import http from 'http';
import RequestController from './controllers/requestController.js';
import { Server as ServerIO } from 'socket.io';
import IOController from './controllers/ioController.js';

const connectionsLimit = 2;

const server = http.createServer(
	(request, response) => new RequestController(request, response).handleRequest()
);

const io = new ServerIO(server);
const ioController = new IOController(io);

io.on('connection', socket => {
	if (io.engine.clientsCount <= connectionsLimit) {
		ioController.registerSocket(socket); 
	} else {
		socket.emit("no");
		console.log("There are too many player");
		socket.disconnect();
		ioController.setupListeners(socket);
	}
} );

server.listen(8080);
