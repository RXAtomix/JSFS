const User = require('../models/user.model').model;

module.exports.home = (_,res) => res.redirect('/item/create');

module.exports.me =
  async (req, res) =>  {
    const user = await User.findById(req.userId);
    console.log(user);
    console.log(req.userId);
    res.status(200).json({ surname : user.surname,
                           firstname : user.firstname,
                           money : user.money });
  }

module.exports.transferMoney = async (req, res) =>
  {
    try
    {
      console.log(req.body.buyer);
      console.log(req.body.seller);
      const userToAdd = await User.findById(req.body.seller);
      const userToSup = await User.findById(req.body.buyer);
      console.log("Price = " + req.body.money);
      if (userToSup.money >= req.body.money){ 
          const updatedData1 = { money : userToSup.money - req.body.money };
          const otherUser = await User.findByIdAndUpdate(req.body.buyer, updatedData1, { new : true });
          const updatedData2 = { money : userToAdd.money + req.body.money };
          const otherUser2 = await User.findByIdAndUpdate(req.body.seller, updatedData2, { new : true });
          if (otherUser)
            res.status(200).json(otherUser);
          else
            res.status(500).json({ message : "Paiement echoué" });
      } 
      else
          res.status(402).json({message : "You don't have enough money !"});
    }
    catch (error)
    {
        console.log("Problem when buying : " + error.message);
        res.status(500).redirect("/login.html");
    }
  }
  