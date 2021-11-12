var throughError = false;
var tamilMark, engMark, mathMark, scienceMark, socialMark, totalMark, totalMarkPercentage;
var failedSubjects = [];

const tenthMarkCalculate = () => {
	failedSubjects = [];

	tamilMark = parseInt(document.getElementById('tamilMark').value);
	engMark = parseInt(document.getElementById('englishMark').value);
	mathMark = parseInt(document.getElementById('mathsMark').value);
	scienceMark = parseInt(document.getElementById('scienceMark').value);
	socialMark = parseInt(document.getElementById('socialMark').value);

	totalMark = tamilMark + engMark + mathMark + scienceMark + socialMark;
	totalMarkPercentage = totalMark / 5;

	if(tamilMark < 35) {
		failedSubjects.push("Tamil");
	}

	if(engMark < 35) {
		failedSubjects.push("English");
	}

	if(mathMark < 35) {
		failedSubjects.push("Maths");
	}

	if(scienceMark < 35) {
		failedSubjects.push("Science");
	}

	if(socialMark < 35) {
		failedSubjects.push("Social");
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
	if(e.target.value > 0 || e.target.value <= 100) {
		document.getElementById('errorMsg').style.display = "none";
	}

	if(e.target.value < 0 || e.target.value > 100) {
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