$(document).ready(function () {
    $(".word-panel__row")
    .find(".see-translate-btn")
    .click(function () {
        $(this).parent().find(".word-translate-item").slideToggle("fast");
    });

    const addWordBtn = $(".add-word-btn");
    addWordBtn.click(function () {
        const inputWord = document.getElementsByName("word")[0];
        console.log(inputWord);
        const inputWordValue = inputWord.value;
        console.log(inputWordValue);
        const modalWordValue = document.getElementsByName("wordValue")[0];
        console.log(modalWordValue);
        modalWordValue.value = inputWordValue;
    });

});