// Global Variables
var codeArea = document.querySelector('.codingPart');
var outputArea = document.querySelector('.outputPart');

var htmlCodePart = document.getElementById("htmlCode");
var cssCodePart = document.getElementById("cssCode");
var jsCode = document.getElementById("jsCode");


function runProgram() {
	var htmlTextArea = document.getElementById("htmlCode").value;
	var cssTextArea = "<style>" + document.getElementById("cssCode").value + "</style>";
	var jsTextArea = document.getElementById("jsCode").value;
	var outputFrame = document.getElementById("outputFrame");

	outputFrame.contentDocument.body.innerHTML = htmlTextArea + cssTextArea;
	outputFrame.contentWindow.eval(jsTextArea);
}


// Open Editor Or Output View
function openEditorView() {
	codeArea.style.display = "flex";

	codeArea.style.height = "90%";
	outputArea.style.display = "none";
}

function openOutputView() {
	outputArea.style.display = "block";

	codeArea.style.display = "none";
	outputArea.style.height = "90%";
}

function openDetailedView() {
	codeArea.style.display = "flex";
	outputArea.style.display = "block";

	codeArea.style.height = "50%";
	outputArea.style.height = "40%";
}


// Change Theme
function changeTheme(val) {
	var bodyTag = document.querySelector("body");
	var textAreaTag = document.querySelectorAll("textarea");

	var isDarkModeEnabled = document.querySelector('body').classList.value.split(" ").indexOf('darkMode');

	if(val === "lightTheme") {
		if(isDarkModeEnabled != -1) {
			bodyTag.classList.remove('darkMode');
			textAreaTag.forEach(e => e.classList.remove('darkMode'));
		}
	}
	else if(val === "darkTheme") {
		if(isDarkModeEnabled == -1) {
			bodyTag.classList.add('darkMode');
			textAreaTag.forEach(e => e.classList.add('darkMode'));
		}
	}

	outputArea.style.backgroundColor = "white";
}


// Change Font Size
function changeFontSize(val) {
	var textAreaTag = document.querySelectorAll("textarea");
	
	textAreaTag.forEach(e => e.style.fontSize = val + "px");
}

// Extend or Collapse Editor
var htmlCodeArea = document.querySelector('.htmlCodeArea');
var cssCodeArea = document.querySelector('.cssCodeArea');
var jsCodeArea = document.querySelector('.jsCodeArea');
var htmlSpanTag = document.getElementById('htmlSpan');
var cssSpanTag = document.getElementById('cssSpan');
var jsSpanTag = document.getElementById('jsSpan');

var isOpen = false;

function extendSpan(id) {
	switch(id) {
		case 'htmlSpan':
			if(!isOpen) {
				htmlCodeArea.style.width = "90%";
				cssCodeArea.style.width = "3%";
				jsCodeArea.style.width = "3%";

				htmlSpanTag.style.left = "98%";
				cssSpanTag.style.display = "none";
				jsSpanTag.style.display = "none";

				isOpen = true;
			}
			else {
				htmlCodeArea.style.width = "32%";
				cssCodeArea.style.width = "32%";
				jsCodeArea.style.width = "32%";

				htmlSpanTag.style.left = "94.5%";
				cssSpanTag.style.display = "inline-block";
				jsSpanTag.style.display = "inline-block";

				isOpen = false;
			}
			break;
		case 'cssSpan':
			if(!isOpen) {
				cssCodeArea.style.width = "90%";
				htmlCodeArea.style.width = "3%";
				jsCodeArea.style.width = "3%";

				htmlSpanTag.style.display = "none";
				cssSpanTag.style.left = "98%";
				jsSpanTag.style.display = "none";

				isOpen = true;
			}
			else {
				cssCodeArea.style.width = "32%";
				htmlCodeArea.style.width = "32%";
				jsCodeArea.style.width = "32%";

				cssSpanTag.style.left = "94.5%";
				htmlSpanTag.style.display = "inline-block";
				jsSpanTag.style.display = "inline-block";

				isOpen = false;
			}
			break;
		case 'jsSpan':
			if(!isOpen) {
				jsCodeArea.style.width = "90%";
				cssCodeArea.style.width = "3%";
				htmlCodeArea.style.width = "3%";

				cssSpanTag.style.display = "none";
				htmlSpanTag.style.display = "none";
				jsSpanTag.style.left = "98%";

				isOpen = true;
			}
			else {
				htmlCodeArea.style.width = "32%";
				cssCodeArea.style.width = "32%";
				jsCodeArea.style.width = "32%";

				jsSpanTag.style.left = "94.5%";
				cssSpanTag.style.display = "inline-block";
				htmlSpanTag.style.display = "inline-block";

				isOpen = false;
			}
			break;
	}
}