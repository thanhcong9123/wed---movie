// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var header = document.querySelector('.navbar');
var origOffsetY = header.offsetTop;

function onScroll(e) {
    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
        window.scrollY >= origOffsetY ? header.classList.add('sticky') :
            header.classList.remove('sticky');
    }
    else {
        header.classList.remove('sticky');
    }
}

document.addEventListener('scroll', onScroll);
