// Date
var currentDate = document.getElementById('currentDate');

var date = new Date();

var day = date.getDate();
var month = date.getMonth() + 1;
var year = date.getFullYear();


setInterval(myTimer, 1000);

function myTimer() {
  const d = new Date();
  currentDate.innerHTML = "Date: " + day + "/" + month + "/" + year + " - " + d.toLocaleTimeString();
}


// Open DropDown
const openDropDown = () => {
    setTimeout(document.getElementById("nameDropDown").classList.add("show"), 2000);
}

window.onclick = function(e) {
    var dropDown = Array.from(document.getElementById("nameDropDown").classList);

    if(dropDown.indexOf("show") !== -1) {
        if(Array.from(e.target.classList).indexOf("nameContainer") === -1) {

            let id = e.target.id;

            if(id == 1) {
                document.querySelector('.okContainer').classList.remove('disabled');
                document.querySelector('.notOkContainer').classList.add('disabled');

                document.getElementById('liveImg').src = "./images/object1.jpeg";
                document.getElementById('previewImg').src = "./images/object1.jpeg";

                document.querySelector('.partName').innerHTML = e.target.innerHTML;
                document.getElementById('partNumber').innerHTML = "LT RH";
            }
            else if(id == 2) {
                document.querySelector('.okContainer').classList.add('disabled');
                document.querySelector('.notOkContainer').classList.remove('disabled');

                document.getElementById('liveImg').src = "./images/object2.jpg";
                document.getElementById('previewImg').src = "./images/object2.jpg";
                
                document.querySelector('.partName').innerHTML = e.target.innerHTML;
                document.getElementById('partNumber').innerHTML = "LT LH";
            }

            if(id !== "neverClose") {
                document.getElementById("nameDropDown").classList.remove("show");
            }
        }
    }
}
