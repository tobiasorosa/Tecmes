﻿/* eslint-disable no-undef */
document.getElementById('login-form').addEventListener('submit', async (event) => {
  event.preventDefault();
  const username = document.getElementById('username').value;
  const password = document.getElementById('password').value;

  try {
    const response = await axios.post('/api/auth/login', { username, password });
    console.log(response.data);
    if (response.data.result.isSuccess === true) {
      await alert('Login bem sucedido!');
      const token = response.data.result.value;
      localStorage.setItem('jwtToken', token);
        window.location.href = '/production-orders.html';
    } else {
      alert('Nome de usuário ou senha inválida.');
    }
  } catch (err) {
    console.error('Erro: ', err);
    alert('Um erro ocorreu ao tentar logar!');
  }
});
