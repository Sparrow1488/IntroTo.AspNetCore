const numberTask = $(".number-of-tasks .text");
const confirmBtn = $(".confirm-btn");
const allTaskCount = trainingWords.length;
let currentTask = 0;
let currentQuestionWord = trainingWords[currentTask];
let completedIndexes = [];

function displayTask() {
    if (trainingWords.length < 1 || !trainingWords) {
        displayResults();
    }
    else {
        currentQuestionWord = getRandomWord();
        $(numberTask).html(`Task ${currentTask + 1}/${allTaskCount}`);
        $(".translate-word").html(`${currentQuestionWord.value}`);
    }
}

function nextTask() {
    currentTask++;
    moveProgressBar();
    if (currentTask < allTaskCount) {
        removeArrayItem(trainingWords, currentQuestionWord);
        console.log("trainingWords:", trainingWords);
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

function getRandomWord() {
    const rndIndex = Math.floor(Math.random() * (trainingWords.length - 1));
    return trainingWords[rndIndex];
}

function moveProgressBar() {
    const kaef = allTaskCount / currentTask;
    const result = 100 / kaef;
    $(".progress .color").width(`${result}%`);
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