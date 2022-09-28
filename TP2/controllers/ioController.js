export default class IOController {

    #io;
    #clients;

    constructor(io) {
        this.#io = io;
        this.#clients = new Map();        
    }
    
    randomInt() { 
        console.log("Un nombre a été envoyé au(x) client(s)");
        return Math.floor(Math.random() * 8) + 2; 
    }
    
    registerSocket(socket) {
        console.log(`connection done by ${socket.id}`);
        let sid = setInterval(() => socket.emit('random', this.randomInt()),2000); // Version lorsque plusieurs clients sont connectés, tous les clients ne reçoivent pas le meme nombre "au meme moment"
        this.#clients.set(socket.id,sid);
        // this.ping(); Version lorsque plusieurs clients sont connectés, tous les clients reçoivent le meme nombre "au meme moment"
        this.setupListeners(socket);
    }

    setupListeners(socket) {
        socket.on('disconnect', () => { this.leave(socket) });
    }

    leave(socket) {
        console.log(`disconnection of ${socket.id}`);
        clearInterval(this.#clients.get(socket.id));
        this.#clients.delete(socket.id);
    }
    
    ping () {
        setInterval(() => this.#io.emit('random', randomInt()),2000);
    }
}