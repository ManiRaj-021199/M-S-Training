// var day = 5;
// var period = 8;

// const rowInputClicked = e => {
//     e.target.removeAttribute("placeholder");
//     document.getElementById('rownodisplay').style.display = "block";
// }

// const rowInputChanged = e => {
//     if(!'readonly' in document.getElementById('rowInput').attributes) {
//         console.log('hello')
//         document.getElementById('rownodisplay').style.display = 'none';
//     }
// }

// const rowValueChanged = e => {
//     if(e.target.value.length == 1) {
//         e.target.setAttribute('readonly', "true");
//     }
// }

// const colInputClicked = e => {
//     e.target.removeAttribute("placeholder");
//     document.getElementById('colnodisplay').style.display = "block";
// }

// const colInputChanged = e => {
//     if(!'readonly' in document.getElementById('colInput').attributes) {
//         document.getElementById('colnodisplay').style.display = 'none';
//     }
// }

// const colValueChanged = e => {
//     if(e.target.value.length == 1) {
//         e.target.setAttribute('readonly', "true");
//     }
// }

// const generateTable = e => {
//     e.preventDefault();
    
//     day = document.getElementById('rowInput').value;
//     period = document.getElementById('colInput').value;
    
//     document.querySelector('.generateTimeTable').style.display = "none";
//     document.querySelector('.timetable').style.display = "flex";

//     generateTimeTable();
// }

// function generateTimeTable() {
//     var timetableContainer = document.querySelector('.tTable');
// }


// Drag and Drop
const drag = e => {
    e.dataTransfer.setData("text", e.target.id);
}

const allowDrop = e => {
    e.preventDefault();
}

const drop = e => {
    e.preventDefault();
    var data = e.dataTransfer.getData("text");
    
    if(document.getElementById(data).innerHTML === "Clear") {
        e.target.innerHTML = "";
    }
    else if(e.target.innerHTML === "") {
        e.target.append(document.getElementById(data).innerHTML);
    }
}


const downloadTimeTable = () => {
    html2canvas(document.querySelector('table')).then((canvas) => {
        const timetableImg = canvas.toDataURL("image/png");

        let a = document.createElement("a");
        a.href = timetableImg;
        a.download = timetableImg;
        a.click();
    });
}