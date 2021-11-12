const modal = document.querySelector('.modal');

// Open Modal when button was clicked
const openModal = () => {
    modal.style.display = "block";
    document.getElementById("registerButton").focus();
}

// Close Modal when close button was clicked
const closeModal = () => {
    modal.style.display = "none";
}

// Register Button Clicked Action
const registerBtnClicked = () => {
    document.querySelector('.registrationFormContent').style.display = "block";
    document.querySelector('.loginFormContent').style.display = "none";
}

// Login Button Clicked Action
const loginBtnClicked = () => {
    document.querySelector('.registrationFormContent').style.display = "none";
    document.querySelector('.loginFormContent').style.display = "block";
}


window.onclick = function(e) {
    // Close Modal when user click outside of the modal
    if(e.target == document.querySelector('.container')) {
        modal.style.display = "none";
    }
}