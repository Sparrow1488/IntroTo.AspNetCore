const $errorElem = $(".error-massage .error");
const $login = $(".login-box");
const $password = $(".password-box");

function writeMessage(message){
    $errorElem.html(message).slideDown(200);
}
function hideMessage(){
    $errorElem.slideUp(200);
}
function inputValidation(login, password){
    let inputResult = false;
    if(login && password){
        inputResult = true;
    }
    return inputResult;
}

$(document).ready(function(){
    $errorElem.hide();

    $login.keydown(function() { 
        hideMessage();
    });
    $password.keydown(function() {
        hideMessage();
    });

    $(".signin").click(function(e){
        e.preventDefault();
        let loginText = $login.val();
        let passwordText = $password.val();
        let inpValidateRes = inputValidation(loginText, passwordText);
        if(!inpValidateRes){
            writeMessage("Empty login or password!");
        }
        else {
            hideMessage();
            $(".auth-panel__form form").submit();
        }
    });
});