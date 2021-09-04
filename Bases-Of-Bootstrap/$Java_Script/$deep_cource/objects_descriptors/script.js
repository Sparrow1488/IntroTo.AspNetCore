// "use strict"

const animal = {
    type: "Animal",
    age: 0
}

// первый аргумент - прототип; второй - новый объект
const pet = Object.create(animal, {
    name: {
        value: "Petty",
        // дескрипторы (по умолчанию false):
        writable: true,     // можно перезаписать (→object[key] = value)
        enumerable: true,   // можно перечислить  (→forein)
        configurable: true  // можно удалить      (→delete object[key])
    },
    color: {
        value: "black"
    }
});
pet.age = 11;
pet.type = "Dog";
pet.name = "Clara";
for (const key in pet) {
    if (Object.hasOwnProperty.call(pet, key)) {
        const element = pet[key];
        console.log("Key:", key, "; Value:", element);
    }
}

console.log("Can delete key 'color' of pet object", ":", delete pet["color"]);