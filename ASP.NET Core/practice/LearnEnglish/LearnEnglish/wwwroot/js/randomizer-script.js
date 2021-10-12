const baseURL = "https://localhost:44372/";

const trainingDictionaries = [];
const startBtn = $(".start-btn");

let trainingWords = [];


function removeArrayItem(array, item) {
    const index = array.indexOf(item);
    if (index > -1) {
        array.splice(index, 1);
    }
}
function displayArrayOfDictionaries(array) {
    $(".selected-dictionaries-list").html("");
    array.forEach(element => {
        $(".selected-dictionaries-list").append(`<span class='selected-dictionary text'><b class='text'>${element}</b></span>`);
        $(".selected-dictionaries-list").append("<span>         </span>"); //   space
    });
}
async function receiveDictionaries(listOfId) {
    const params = buildURLParams("identies", listOfId);
    const url = baseURL + "Training/Randomizer?handler=DictionariesJson";
    const response = await fetch(url + params);
    const responseJson = await response.json();
    return responseJson;
}
async function receiveRandomizerActivePage() {
    const response = await fetch(baseURL + "Randomizer-active.html");
    //const pageDocument = new DOMParser().parseFromString(response.text(), "text/html");
    return response.text();
}

function buildURLParams(key, values) {
    let row = "&";
    values.forEach(function (elem) {
        row += key + "=" + elem + "&";
    });
    console.log("Row", row);
    return row;
}

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

    $(startBtn).click(async function () {
        let responseJson = await receiveDictionaries([1, 2, 3, 4]);
        if (responseJson.result == "ok") {
            console.log("Words GET Success");
            console.log(responseJson.values);
            trainingWords = responseJson.values;
            const randomiserActive = await receiveRandomizerActivePage();
            $("#content").html(randomiserActive);
        }
    });
});

