const Item = require('../models/item.model').model;
const Users = require('../models/user.model').model;

module.exports.createItem =
  async (req, res) =>  {
    const newItemData = { ...req.body,
                          userId : req.userId };
    const item = await Item.create(newItemData);
    res.status(200).json(item);
  }

module.exports.otherItems = 
  async (req, res) => {
    const toBuy = await Item.find();
    const buy = toBuy.filter(item => JSON.stringify(item.userId) != JSON.stringify(req.userId));
    res.status(200).json(buy);
  }

module.exports.myItems = 
  async (req, res) => {
    const items = await Item.find();
    const mine = items.filter(item => JSON.stringify(item.userId) == JSON.stringify(req.userId));
    console.log(mine);
    res.status(200).json(mine);
  }

module.exports.buy = 
  async (req,res) => {
    const updatedItemData = { ...req.body, userId : req.userId, date : new Date() };            // new value for Item is received from client
    try {
      const updatedItem = await Item.findByIdAndUpdate(
                                                        req.params.itemId,
                                                        updatedItemData,         // updating is done
                                                        { new : true }           // to get modified Item as result
                                                      );
      res.status(201).json( updatedItem ) ;
      Item.findByIdAndRemove(req.params.itemId);
    }
    catch( error ) {
      res.status(400).json(error);
    }
  }

module.exports.delete =
  async (req,res) => {
    try {
      await Item.findByIdAndRemove( req.params.itemId );
      res.status(301).redirect('/item/create');
    }
    catch(error) {
      throw error ;
    }
  }

const createForm = (_,res) => res.render('item');
module.exports.createForm = createForm;