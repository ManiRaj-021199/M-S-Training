// Global Variables
var images = ["1.jpg", "2.jpg", "3.jpg"];
var allData = {
    "birth": `Steven Paul Jobs was born on February 24, 1955, to Abdulfattah Jandali and Joanne Schieble, and was adopted by Paul and Clara Jobs. Schieble became pregnant with Jobs in 1954, when she and Jandali spent the summer with his family in Homs, Syria. According to Jandali, Schieble deliberately did not involve him in the process: "without telling me, Joanne upped and left to move to San Francisco to have the baby without anyone knowing, including me."`,
    "childhood": `Paul worked in several jobs that included a try as a machinist, several other jobs, and then "back to work as a machinist."Paul and Clara adopted Jobs's sister Patricia in 1957 and by 1959 the family had moved to the Monta Loma neighborhood in Mountain View, California. It was during this time that Paul built a workbench in his garage for his son in order to "pass along his love of mechanics."Jobs, meanwhile, admired his father's craftsmanship "because he knew how to build anything. If we needed a cabinet, he would build it. When he built our fence, he gave me a hammer so I could work with him ... I wasn't that into fixing cars ... but I was eager to hang out with my dad."By the time he was ten, Jobs was deeply involved in electronics and befriended many of the engineers who lived in the neighborhood."`,
    "apple": `By March 1976, Wozniak completed the basic design of the Apple I computer and showed it to Jobs, who suggested that they sell it; Wozniak was at first skeptical of the idea but later agreed. In April of that same year, Jobs, Wozniak, and administrative overseer Ronald Wayne founded Apple Computer Company (now called Apple Inc.) as a business partnership in Jobs's parents' Crist Drive home on April 1, 1976.The operation originally started in Jobs's bedroom and later moved to the garage. Wayne stayed only a short time, leaving Jobs and Wozniak as the active primary cofounders of the company. The two decided on the name "Apple" after Jobs returned from the All One Farm commune in Oregon and told Wozniak about his time spent in the farm's apple orchard.`,
    "awards": `1985: awarded by US President Ronald Reagan<br>1987: Jefferson Award for Public Service<br>1989: Entrepreneur of the Decade by Inc.<br>1991: Howard Vollum Award from Reed College<br>2007: Named the most powerful person in business by Fortune magazine<br>2007: Inducted into the California Hall of Fame<br>2012: Grammy Trustees Award<br>2012: Posthumously honored with an Edison Achievement Award<br>2013: Posthumously inducted as a Disney Legend<br>2017: Steve Jobs Theatre opens at Apple Park<br>`,
    "death": `Jobs died at his Palo Alto, California home around 3 p.m. (PDT) on October 5, 2011, due to complications from a relapse of his previously treated islet-cell pancreatic neuroendocrine tumor, which resulted in respiratory arrest. He had lost consciousness the day before and died with his wife, children, and sisters at his side. His sister, Mona Simpson, described his death thus: "Steve's final words, hours earlier, were monosyllables, repeated three times. Before embarking, he'd looked at his sister Patty, then for a long time at his children, then at his life's partner, Laurene, and then over their shoulders past them. Steve's final words were: 'Oh wow. Oh wow. Oh wow.'" He then lost consciousness and died several hours later. A small private funeral was held on October 7, 2011.`
}

// Selectors
var imageSlider = document.getElementById('imageSlider');
var bioData = document.querySelector('.bioData');
var detailedData = document.querySelector('.detailedData');
var bioHeadId = document.getElementById('bioHeadId');
var bioDetailId = document.getElementById('bioDetailId');

// Sliding Image
var startingPosition = 0;

imageSlider.innerHTML = `<img src="./images/${images[startingPosition]}" alt="">`

setInterval(() => {
    if(startingPosition >= images.length - 1) {
        startingPosition = 0;
        imageSlider.innerHTML = `<img src="./images/${images[startingPosition]}" alt="">`;
    }
    else {
        startingPosition += 1;
        imageSlider.innerHTML = `<img src="./images/${images[startingPosition]}" alt="">`;
    }
}, 4000);


// Show Bio
const showDetail = (want) => {
    bioData.classList.add('nodisplay');
    detailedData.classList.remove('nodisplay');

    bioHeadId.innerHTML = want.toUpperCase();
    bioDetailId.innerHTML = allData[want];
}

// Close Bio
const closeDetail = () => {
    bioData.classList.remove('nodisplay');
    detailedData.classList.add('nodisplay');
}


// Play Video
const playVideo = () => {
    document.querySelector('.tributePage').classList.add('nodisplay');
    document.querySelector('.playVideoContainer').classList.remove('nodisplay');
}

// Close Video
const closeVideo = () => {
    document.querySelector('.tributePage').classList.remove('nodisplay');
    document.querySelector('.playVideoContainer').classList.add('nodisplay');
}