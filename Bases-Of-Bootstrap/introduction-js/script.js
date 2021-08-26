let word = "Hello Джава-скрипт ебаный";
console.log(word);
let element = document.getElementById("id-num");
element.hidden = true;

let btn = document.getElementById("send-data-btn");
btn.addEventListener("click", () => {
    alert("[Server]: Data received");
});

const man = {
    name: "Valentos",
    age: 228,
    job: "full-stack senior team-lead manager",
    cash: 10000000
}
console.log(man);
man.age = 1488;
console.log(man);
console.log("age type is number : " + !isNaN(man.age));
function isValidObject(){

}