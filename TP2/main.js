import http from 'http';
import RequestController from './controllers/requestController.js';
import { Server as ServerIO } from 'socket.io';
import IOController from './controllers/ioController.js';

const server = http.createServer(
	(request, response) => new RequestController(request, response).handleRequest()
);

const io = new ServerIO(server);
const ioController = new IOController(io);
io.on('connection', socket => ioController.registerSocket(socket)  );

// setInterval(() => io.emit('random', randomInt()),2000);

server.listen(8080);
