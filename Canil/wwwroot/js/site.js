
const navSlide = () => {
    const burger = document.querySelector('.burger');
    const nav = document.querySelector('.nav-links');    
    const navLinks = document.querySelectorAll('.nav-links li');
    const fixTransitionBug = document.getElementById('transition1');
    //toggle nav
    burger.addEventListener('click', () => {
        fixTransitionBug.classList.add('transition-nav');
        nav.classList.toggle('nav-active');

           //animate links
        navLinks.forEach((link, index) => {
            if (link.style.animation) {
                link.style.animation = '';
                setTimeout(() => {
                    fixTransitionBug.classList.remove('transition-nav');
                }, 500);
            }
            else {
                if (index <= 5) {
                    link.style.animation = `navLinkFade 0.5s ease forwards ${index / 7 + 0.3}s`
                }
                else {
                    link.style.animation = `navLinkFade 0.5s ease forwards ${index / 7 - 0.9}s`
                }
            }
        });

        //burger animation
        burger.classList.toggle('toggle');
    });
}

navSlide();

//const app = () => {
//    navSlide();
//}