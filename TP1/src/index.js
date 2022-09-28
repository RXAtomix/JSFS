import http from 'http';
import ResponseController from './responseController.js';

// création du serveur
const server = http.createServer(
  (request, response) => new ResponseController(request,response).buildResponse()
);

server.listen(8080);