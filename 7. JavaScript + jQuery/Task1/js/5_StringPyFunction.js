function foo(str) {
    if(str.substring(0, 2) === "Py") {
        return str.substring(2);
    } else {
        return "Py" + str;
    }
}