const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    login : { type : String, required : true, unique : true},
    password : { type : String, required : true},
    admin : { type : Boolean, default: false },
    surname : String,
    firstname : String,
    money : Number
  });

module.exports = userSchema;

const dbConnection = require('../controllers/db.controller');  // importation de l'objet qui gère la connexion

const Users = dbConnection.model('User', userSchema, 'Users'); // création du modèle qui lie le schéma à la collection books

module.exports.model = Users;                     // export du modèle

userSchema.methods.fullName = function() {
  return `${this.firstname} ${this.surname}`;
}