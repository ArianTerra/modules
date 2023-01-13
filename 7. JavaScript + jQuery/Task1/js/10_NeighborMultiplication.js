function neighborMultiplication(arr) {
    let res = [];

    for(let i = 0; i < arr.length - 1; i++) {
        res.push(arr[i] * arr[i+1]);
    }

    let max = Math.max.apply(Math, res);
    let first = arr[res.indexOf(max)];
    let second = arr[res.indexOf(max) + 1];

    return max + " = " + first + " * " + second;
}