const setupListener = () => {
  askForItemToBuy();
  itemsAlreadyInSell();
  createbutton.addEventListener('click', askForItemCreation);
}
window.addEventListener('DOMContentLoaded', setupListener);

const askForItemCreation =
  async () => {
    const newItems = {
                      descr : descr.value,
                      price : price.value,
                      sold : false
                    };
    const bodyContent = JSON.stringify(newItems);
    const requestOptions = {
                             method :'POST',
                             headers : { "Content-Type": "application/json" },
                             body : bodyContent
                           };
    const response = await fetch('/item/create', requestOptions);
    const items = await response.json();
    const buton = buildMyElement(items);
    mine.appendChild(buton);
  }
  
const askForItemToBuy =
  async () => {
    const requestOptions = {
                             method :'GET'
                           };
    const response = await fetch('/item/others', requestOptions);
    const items = await response.json();
    items.forEach(item => {
      const buton = buildBuyableElement(item);
      buy.appendChild(buton);
    });
  }

const itemsAlreadyInSell =
  async () => {
    const requestOptions = {
                             method :'GET'
                           };
    const response = await fetch('/item/mine', requestOptions);
    const items = await response.json();
    items.forEach(item => {
      const buton = buildMyElement(item);
      mine.appendChild(buton);
    });
  }

const boughtItem = //Evenement à créé
  async (itemId, userId, button) => {
    const updateData = { sold : true };
    const body = JSON.stringify( updateData );
    // use method PUT for an  update request
    const requestOptions = {
                              method :'PUT',
                              headers : { "Content-Type": "application/json" },
                              body : body
                            };
    const response = await fetch(`/item/buy/${itemId}`, requestOptions)
    if (response.ok) {
      const item = await response.json();
      bought.innerHTML = `Last item bought : <ul>${item.descr} bought the ${item.date}</ul>`;
      transferMoney(item.price, userId, item.userId);
      button.parentNode.parentNode.removeChild(document.getElementById(itemId));
    }
    else {
      const error = await response.json();
      bought.textContent = `error : ${error.message}`;
    }
  }

const transferMoney = async (money, oldUser, newUser) =>{
  const userData = { money : money, seller : oldUser, buyer : newUser };
  const body = JSON.stringify(userData);
  const requestOptions = {
                         method :"PUT",
                         headers : { "Content-Type": "application/json" },
                         body : body
                         };
  const response = await fetch("/users/money", requestOptions);
  if (response.ok) 
  {
    const updatedUser = await response.json();
    username.textContent = `You are ${updatedUser.surname} ${updatedUser.firstname} and you possess ${updatedUser.money} €`;
  }
  else 
  {
    const error = await response.json();
    handleError(error);
  }
}

const removeItem = 
  async (itemId, button) => {
    const requestOptions = {
                             method :'GET'
                           };
    const response = await fetch(`/item/delete/${itemId}`, requestOptions);
    button.parentNode.parentNode.removeChild(document.getElementById(itemId));
  }

const buildMyElement =  (item) => {
  const itemElement = document.createElement('ul');
  itemElement.className = 'item';
  itemElement.id = item._id;
  itemElement.textContent = item.descr + "\t" +  item.price;
  const deleteButton = buildButton('Remove');
  deleteButton.addEventListener('click', () => removeItem(item._id, deleteButton));
  itemElement.appendChild(deleteButton);
  return itemElement;
}

const buildBuyableElement =  (item) => {
  const itemElement = document.createElement('ul');
  itemElement.className = 'item';
  itemElement.id = item._id;
  itemElement.textContent = item.descr + "\t" +  item.price;
  const deleteButton = buildButton('Buy');
  deleteButton.addEventListener('click', () => boughtItem(item._id, item.userId, deleteButton));
  itemElement.appendChild(deleteButton);
  return itemElement;
}

const buildButton = label  => {
  const button = document.createElement('button');
  button.textContent = label;
  return button;
}
 