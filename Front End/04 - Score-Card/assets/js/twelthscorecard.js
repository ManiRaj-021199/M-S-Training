var throughError = false;
var tamilMark, engMark, mathMark, physicsMark, chemistryMark, biologyMark, totalMark, totalMarkPercentage;
var failedSubjects = [];


const twelthMarkCalculate = () => {
	failedSubjects = [];

	tamilMark = parseInt(document.getElementById('tamilMark').value);
	engMark = parseInt(document.getElementById('englishMark').value);
	mathMark = parseInt(document.getElementById('mathsMark').value);
	physicsMark = parseInt(document.getElementById('physicsMark').value);
	chemistryMark = parseInt(document.getElementById('chemistryMark').value);
	biologyMark = parseInt(document.getElementById('biologyMark').value);

	totalMark = tamilMark + engMark + mathMark + physicsMark + chemistryMark + biologyMark;
	totalMarkPercentage = (totalMark / 6).toFixed(2);

	if(tamilMark < 70) {
		failedSubjects.push("Tamil");
	}

	if(engMark < 70) {
		failedSubjects.push("English");
	}

	if(mathMark < 70) {
		failedSubjects.push("Maths");
	}

	if(physicsMark < 70) {
		failedSubjects.push("Physics");
	}

	if(chemistryMark < 70) {
		failedSubjects.push("Chemistry");
	}

	if(biologyMark < 70) {
		failedSubjects.push("Biology");
	}

	document.querySelector('.scoreCardContent').style.display = "none";
	document.querySelector('.scoreCardResult').style.display = "block";

	document.getElementById('totalMark').innerHTML = totalMark;

	if(failedSubjects.length === 0) {
		document.getElementById('totalMarkPercentage').innerHTML = totalMarkPercentage;

		document.getElementById('displayFailedSubjects').style.display = "none";
	}
	else {
		document.getElementById('totalMarkPercentage').innerHTML = "Fail";
		document.getElementById('totalMarkPercentage').style.color = "red";
	}

	failedSubjects.forEach(subject => 
		document.querySelector('.failedSubjects').innerHTML += `<li>${subject}</li>`
	);
}


const disableInput = (e, subName) => {
	if(e.target.value > 0 || e.target.value <= 200) {
		document.getElementById('errorMsg').style.display = "none";
	}

	if(e.target.value < 0 || e.target.value > 200) {
		document.getElementById('errorMsg').innerHTML = "Invalid Mark on " + subName;
		document.getElementById('errorMsg').style.display = "block";

		if(throughError) {
			var refreshPage = confirm("You Entered Invalid Marks. Want to Check Again?");
			if(refreshPage) {
				location.reload();
			}
		}

		throughError = true;
	}
}


const backToHome = () => {
	console.log('hello')
	window.location.href = "index.html";
}