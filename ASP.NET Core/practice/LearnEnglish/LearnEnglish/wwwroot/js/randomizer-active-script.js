const numberTask = $(".number-of-tasks .text");
const confirmBtn = $(".confirm-btn");
let currentIndex = 0;
let currentQuestionWord = trainingWords[currentIndex];

function displayTask() {
    if (trainingWords.length < 1 || !trainingWords) {
        displayResults();
    }
    else {
        currentQuestionWord = trainingWords[currentIndex];
        $(numberTask).html(`Task ${currentIndex + 1}/${trainingWords.length}`);
        $(".translate-word").html(`${currentQuestionWord.value}`);
    }
}

function nextTask() {
    currentIndex++;
    moveProgressBar();
    if (currentIndex < trainingWords.length) {
        displayTask();
        resetInputValue();
    }
    else displayResults();
}

function displayResults() {
    alert("FINISH");
    setTimeout(function () {
        window.location.reload();
    }, 500);
}

function resetInputValue() {
    const answer = document.querySelector(".answer");
    answer.value = "";
}

function moveProgressBar() {
    let all = trainingWords.length;
    let current = currentIndex;
    let kaef = all / current;
    let result = 100 / kaef;
    console.log(`${all}/${current} = ${kaef}`);
    $(".progress .color").width(`${result}%`);
    console.log(result);
}

$(document).ready(function () {
    displayTask();
    $(confirmBtn).click(function () {
        const answer = document.querySelector(".answer");
        console.log(answer.value, currentQuestionWord);
        if (answer.value.toLowerCase().trim() == currentQuestionWord.translate.toLowerCase().trim()) {
            nextTask();
        }
        else alert("Incorrect answer!");
    });
});