let userlogin;
let userpassword;
let username;

const setup = () => {
  username = document.getElementById('user');
  getUser();
  document.getElementById('logout').addEventListener('click', logout);
}
window.addEventListener('DOMContentLoaded', setup);

const getUser = async () => {
  const requestOptions = {
                           method :'GET',
                         };
  const response = await fetch('/users/me', requestOptions);
  if (response.ok) {
    const user = await response.json();
    username.textContent = `You are ${user.surname} ${user.firstname} and you possess ${user.money} €`;
  }
  else {
    const error = await response.json();
    handleError(error);
  }
}

const logout = async () => {
  const requestOptions = {
                         method :'GET',
                       };
  const response = await fetch(`/access/logout`, requestOptions);
  if (response.ok) {
    window.location.href= '/';
  }
}

const handleError = error => {
  if (error.redirectTo)
    window.location.href= error.redirectTo;
  else
    console.log(`erreur : ${error.message}`);
}
