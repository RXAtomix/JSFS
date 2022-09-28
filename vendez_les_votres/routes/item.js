var express = require('express');
var router = express.Router();

const authMiddleware = require('../middlewares/authentication.middleware');

const itemController = require('../controllers/item.controller');

router.get('/mine', authMiddleware.validToken, itemController.myItems );
router.get('/others', authMiddleware.validToken, itemController.otherItems );
router.get('/create', itemController.createForm );
router.post('/create', authMiddleware.validToken, itemController.createItem );
router.put('/buy/:itemId', authMiddleware.validToken, itemController.buy );
router.get('/delete/:bookId', itemController.delete );

module.exports = router;
