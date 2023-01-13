const min = 1;
const max = 20;

let random = Math.floor(Math.random() * (max - min + 1)) + min;
console.log(random)

while(true) {
    let input = prompt("Enter number:");
    let number = parseInt(input);

    if(isNaN(number)) {
        alert("Wrong input");
        continue;
    }

    if(number < random) {
        alert("Number is larger");
    } else if(number > random) {
        alert("Number is smaller");
    } else {
        alert("You Win!");
        break;
    }
}
