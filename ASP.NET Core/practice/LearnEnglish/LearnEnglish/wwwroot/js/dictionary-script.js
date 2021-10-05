$(document).ready(function () {
    $(".word-panel__row")
    .find(".see-translate-btn")
    .click(function () {
        $(this).parent().find(".word-translate-item").slideToggle("fast");
    });
});