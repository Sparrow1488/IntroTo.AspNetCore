const trainingDictionaries = [];
const startBtn = $(".start-btn");
$(document).ready(function () {
    $(".input-child-item").click(function (e) { 
        e.preventDefault();
        let input = $(this).prev();
        if(!input.hasClass("active")){
            trainingDictionaries.push($(this).html());
            input.prop("checked", true).toggleClass("active");
        }
        else {
            input.prop("checked", false).removeClass("active");
            removeArrayItem(trainingDictionaries, $(this).html());
        }
        console.log("Array of selected dictionaries", trainingDictionaries);
        displayArrayOfDictionaries(trainingDictionaries);
        if(!trainingDictionaries || trainingDictionaries.length < 1){
            startBtn.toggleClass("disabled-btn");
        }
        else startBtn.removeClass("disabled-btn");
    });
});

function removeArrayItem(array, item){
    const index = array.indexOf(item);
    if (index > -1) {
        array.splice(index, 1);
    }
}
function displayArrayOfDictionaries(array){
    $(".selected-dictionaries-list").html("");
    array.forEach(element => {
        $(".selected-dictionaries-list").append(`<span class='selected-dictionary text'><b class='text'>${element}</b></span>`);
        $(".selected-dictionaries-list").append("<span>         </span>");
    });
}