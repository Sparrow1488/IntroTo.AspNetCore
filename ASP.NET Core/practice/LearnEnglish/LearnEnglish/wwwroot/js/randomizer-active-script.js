const numberTask = $(".number-of-tasks .text");
const confirmBtn = $(".confirm-btn");
let currentIndex = 0;
let currentQuestionWord = trainingWords[currentIndex];

function displayTask() {
    currentQuestionWord = trainingWords[currentIndex];
    $(numberTask).html(`Task ${currentIndex + 1}/${trainingWords.length}`);
    $(".translate-word").html(`${currentQuestionWord.value}`);
}
function nextTask() {
    currentIndex++;
    if (currentIndex < trainingWords.length) {
        displayTask();
        resetInputValue();
    }
    else displayResults();
}
function displayResults() {
    alert("FINISH");
}
function resetInputValue() {
    const answer = document.querySelector(".answer");
    answer.value = "";
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