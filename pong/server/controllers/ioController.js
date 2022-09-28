const connectionsLimit = 2;
export default class IOController {

    #io;
    #clients;

    constructor(io) {
        this.#io = io; 
        this.#clients = [];   
    }
    
    registerSocket(socket) {
        console.log(`connection done by ${socket.id}`);
        if(this.#io.engine.clientsCount == connectionsLimit) {
            this.#clients[1] = socket;
            this.#clients[1].emit("second");
            console.log("Vous êtes le second joueur !");
            this.#io.emit("nb");
        } else {
            this.#clients[0] = socket;
            this.#clients[0].emit("first");
            console.log("Vous êtes le premier joueur !");
        }
        this.setupListeners(socket);
    }

    setupListeners(socket) {
        socket.on('ball', (shiftX, shiftY, x, y) => {
            if (this.#clients.length > 1){
                this.#clients[1].emit('changeSh', shiftX, shiftY, x, y);
            }
        });
        socket.on('disconnect', () => { 
            socket.broadcast.emit('other');
            socket.disconnect();
            this.leave(socket);
        });
        socket.on('move', (y) => {
            socket.broadcast.emit('move',y);
        });
        socket.on ('replay', () => {
            this.#io.emit('replay');
        });
        socket.on ('start', () => {
            this.#io.emit('start');
        })
        socket.on('collision', (shiftX, shiftY, x, y) => {
            socket.broadcast.emit('changeSh', shiftX, shiftY, x, y);
        });
    }

    leave(socket) {
        this.#clients.length = 0;
        console.log(`disconnection of ${socket.id}`);
    }

}
