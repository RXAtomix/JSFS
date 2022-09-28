const mongoose = require('mongoose');

const itemSchema = new mongoose.Schema({
    descr : String,
    price : Number,
    userId : mongoose.ObjectId,
    sold : Boolean,
    date : Date
  });

module.exports = itemSchema;

const dbConnection = require('../controllers/db.controller');  // importation de l'objet qui gère la connexion

const Items = dbConnection.model('Item', itemSchema, 'items'); // création du modèle qui lie le schéma à la collection books

module.exports.model = Items;                     // export du modèle