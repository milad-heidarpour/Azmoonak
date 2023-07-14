const onlineTest = document.getElementById("online-test"), testListhover = document.getElementById("test-listmenu");
const searchInpt = document.getElementById("search-inpt"), searchbox = document.getElementById("searh-box");
const onlineTestSliding = document.getElementById("onlineTest-sliding"), slidingbox = document.getElementById("sliding-box"),
    onlineTestIcon = document.getElementById("onlineTest-icon");
const Closebox = document.getElementById("close"), offcanvas = document.getElementById("offCanavas"),
    meunlists = document.getElementById("menusliding"), menubars = document.getElementById("menubar");



searchInpt.addEventListener("focus", () => {
    // searchbox.style.borderRadius="10px";
    searchbox.style.boxShadow = "3px 3px 9px orange";
    searchbox.style.outline = "1.3px solid orange"
    searchbox.style.transition = "all 0.5s"
    searchInpt.addEventListener("focusout", () => {
        searchbox.style.boxShadow = "none";
        searchbox.style.outline = "none";
    })
})

menubars.addEventListener("click", () => {
    offcanvas.style.visibility = "visible";
    Closebox.addEventListener("click", () => {
        offcanvas.style.visibility = "hidden";
    })
})


const Clicked = document.getElementById("AzmonlistClick");
const show = document.getElementById("hidden-Azmonlist");
const Clickedproposal = document.getElementById("proposalClick"),
    showproposal = document.getElementById("hidden-proposallist"),
    smaplequestionClick = document.getElementById("samplequestionClick"),
    showsamplequestion = document.getElementById("hidden-samplequestion");







Clicked.addEventListener("mousemove", () => {
    show.style.visibility = "visible";
    if (showproposal.style.visibility = "visible") {
        showproposal.style.visibility = "hidden"
        if (showsamplequestion.style.visibility = "visible") {
            showsamplequestion.style.visibility = "hidden"
        }
    }
    document.addEventListener("click", () => {
        show.style.visibility = "hidden"
    })
})


Clickedproposal.addEventListener("mousemove", () => {
    showproposal.style.visibility = "visible";
    if (show.style.visibility = "visible") {
        show.style.visibility = "hidden"
        if (showsamplequestion.style.visibility = "visible") {
            showsamplequestion.style.visibility = "hidden"
        }
    }
    document.addEventListener("click", () => {
        showproposal.style.visibility = "hidden"
    })
})
smaplequestionClick.addEventListener("mousemove", () => {
    showsamplequestion.style.visibility = "visible"
    if (show.style.visibility = "visible") {
        show.style.visibility = "hidden"
        if (showproposal.style.visibility = "visible") {
            showproposal.style.visibility = "hidden"
        }
    }
    document.addEventListener("click", () => {
        showsamplequestion.style.visibility = "hidden"
    })
})