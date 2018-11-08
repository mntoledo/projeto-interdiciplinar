const zoomIn = document.querySelector('#zoomIn');
const zoomOut = document.querySelector('#zoomOut');
const zoomDefault = document.querySelector('#zoomDefault');
const blackWhite = document.querySelector('#blackWhite');
const whiteBlack = document.querySelector('#whiteBlack');
const blackYellow = document.querySelector('#blackYellow');
const yellowBlack = document.querySelector('#yellowBlack');
const corsDefault = document.querySelector('#corsDefault');
const btnLogin = document.querySelector('.w-100');
const header = document.querySelector('header');

let size = 1.2;
let nav = document.querySelector('nav');

zoomIn.addEventListener('click', (e) =>{
  e.preventDefault();
  document.body.style.fontSize = `${size+= 0.2}em`;
});

zoomDefault.addEventListener('click', (e) =>{
  e.preventDefault();
  size = 1.2;
  document.body.style.fontSize = `${size}em`;
});


zoomOut.addEventListener('click', (e) =>{
  e.preventDefault();
  document.body.style.fontSize = `${size-= 0.2}em`;
});

blackWhite.addEventListener('click', () => {
  // adiciona a classe `night-mode` ao html
  btnLogin.style.background = '#fff';
  header.style.background = '#fff';
  document.documentElement.classList.remove('blackYellow');
  document.documentElement.classList.remove('yellowBlack');
  document.documentElement.classList.remove('defaul-color');
  document.documentElement.classList.toggle('blackWhite');
});

blackYellow.addEventListener('click', ()=>{
  btnLogin.style.background = '#fff';
  header.style.background = '#fff';
  document.documentElement.classList.remove('blackWhite');
  document.documentElement.classList.remove('yellowBlack');
  document.documentElement.classList.remove('defaul-color');
  document.documentElement.classList.toggle('blackYellow');
});

yellowBlack.addEventListener('click', () =>{
  btnLogin.style.background = '#fff';
  header.style.background = '#fff';
  document.documentElement.classList.remove('blackYellow');
  document.documentElement.classList.remove('blackWhite');
  document.documentElement.classList.remove('defaul-color');
  document.documentElement.classList.toggle('yellowBlack');
});

corsDefault.addEventListener('click', () =>{
  btnLogin.style.background = '#fff';
  header.style.background = '#fff';
  document.documentElement.classList.remove('blackYellow');
  document.documentElement.classList.remove('blackWhite');
  document.documentElement.classList.remove('yellowBlack');
  document.documentElement.classList.toggle('defaul-color');
});