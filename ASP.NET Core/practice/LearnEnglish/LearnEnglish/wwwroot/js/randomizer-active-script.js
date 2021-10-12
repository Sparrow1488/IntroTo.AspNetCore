const numberTask = $(".number-of-tasks .text");
const confirmBtn = $(".confirm-btn");

$(document).ready(function () {
    $(numberTask).html(`Task 1/${trainingWords.length}`);
    $(".translate-word").html(`${trainingWords[0].value}`);

    $(confirmBtn).click(function () {
        alert("ХЭЛЛООУУ!!!");
        console.log(trainingWords);
    });
});