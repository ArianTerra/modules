function vowelCount(str) {
    const vowels = /[aeiou]/gi;
    let result = str.match(vowels);

    if(result !== null) {
        return result.length;
    } else {
        return 0;
    }
}