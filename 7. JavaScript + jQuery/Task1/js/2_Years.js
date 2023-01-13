let startDate = new Date(2014, 0, 0);
let endDate = new Date(2050, 0, 0);

let loop = new Date(startDate);

while(loop <= endDate) {
    if(loop.getDay() === 0) {
        console.log(loop.getFullYear())
    }

     loop.setFullYear(loop.getFullYear() + 1)
}