var express = require('express');
var router = express.Router();
const authMiddleware = require('../middlewares/authentication.middleware');
const indexController = require('../controllers/index.controller');

router.get('/', authMiddleware.validToken, indexController.home );
router.get('/about', authMiddleware.validToken, indexController.about );
router.get('/aboutadmin', authMiddleware.validToken, authMiddleware.isAdmin, indexController.about );

module.exports = router;
