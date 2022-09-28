Binôme: LE GUEN Romain, AMAND Virginie

# Projet Pong

## Avancée

Fini

## Présentation du projet

Ce projet porte sur un mini jeu-vidéo en serveur réalisé en javascript. Voici le déroulement qui va vous permettre d'y jouer.

### Pour commencer

Avant de s'occuper du TP il faut d'abord récupérer le projet en entrant la commande
```sh
git pull 
```
ou 
```sh
git clone [copier coller le lien du dépot distant avec clone]
```

si vous n'avez pas encore de dépot local, puis placez vous dans le dossier **pong/client**.

### Installation des fichiers

Maintenant, vous pouvez exécuter la commande suivante qui va installer les modules:
```sh
npm install
```

### Production du bundle

Vous pouvez maintenant installer le bundle en exécutant la commande:
```sh
npm run build
```

###  Installation des fichiers 2

Maintenant, dans le dossier **pong/server**, exécutez la commande:
```sh
npm install
```

### Exécution

Pour finir, exécuter la commande:
```sh
nodemon
```

Voilà! Vous pouvez jouez!

## Annexe

Comme fait dans la vidéo, la raquette du joueur est toujours celle de gauche car nous avons trouvé que c'était la solution la plus facile à implémenter.

Les deux raquettes se remettent à leur position initiale à chaque but.