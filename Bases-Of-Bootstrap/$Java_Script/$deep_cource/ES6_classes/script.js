// "use strict"

class Human {
    constructor(params){
        this.name = params.name;
        this.age = params.age;
        this.sex = params.sex;
    }
    doSomething(){
        console.log("I'm just human, I can do something");
    }
}
class Programmer extends Human {
    constructor(params){
        super(params);
        this.softSkills = params.softSkills;
    }
    // переопределяем родительский метод
    
    doSomething(){
        // чтобы вызвать родительский метод нужно 
        //обратиться к родительскому классу через 'super'
        super.doSomething(); 
        console.log(`I'm ${this.name} - programmer, I can write algorithms`);
    }
}
const human = new Human({
    name: "Vitaliy",
    age: 27,
    sex: "Male"
});
const programmer = new Programmer({
    name: "Valentin",
    age: 18,
    sex: "Male",
    softSkills: ["Speaker", "Leader", "Society"]
});
console.log(programmer);
console.log(human);