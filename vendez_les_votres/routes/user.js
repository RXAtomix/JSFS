var express = require('express');
var router = express.Router();

const authMiddleware = require('../middlewares/authentication.middleware');

// import controller for index
const userController = require('../controllers/user.controller');

router.get('/', authMiddleware.validToken, userController.home );
router.get('/me', authMiddleware.validToken, userController.me );
router.put('/money', authMiddleware.validToken, userController.transferMoney );

module.exports = router;
