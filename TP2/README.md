# TP2

## Question 5

Au début, dans mon code, lorsque plusieurs clients été connectés, tous les clients ne recevaient pas le même nombre "au même moment".

Pour que tous les clients reçoivent la même information il a fallu faire en sorte qu'un seule information soit envoyé à tout les clients en même temps au lieu d'en envoyé une nouvelle à chaque clients.
Pour cela, `socket.emit` est devenu `this.#io.emit`.

## Question 6.2

Le message continue de s'afficher dans la console même après la déconnexion

## Changement de version

Actuellement nous sommes en version où lorsque plusieurs clients sont connectés, tous les clients ne reçoivent pas le meme nombre "au meme moment".
Pour passer à la méthode de réception "au même moment" il suffit de mettre les lignes 18 et 19 du fichier `controllers/ioController.js` en commentaire et de démmenter la ligne 20.
Et inversement.