//the new header website




const btnHumburgerMenu = document.getElementById("showslider");
const closedMenuSlider = document.getElementById("closed");
const backgroundMenuSlider = document.getElementById("background-slider");





btnHumburgerMenu.addEventListener("click", () => {
    document.querySelector(".menu-slider").classList.add("show");
    document.querySelector(".background-slider").classList.remove("d-none");
    closedMenuSlider.addEventListener("click", () => {
        document.querySelector(".menu-slider").classList.remove("show");
        document.querySelector(".background-slider").classList.add("d-none");
    })
})