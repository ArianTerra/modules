function startClock() {
    const today = new Date();

    document.getElementById('clock').innerHTML = today.toLocaleString();

    let time = setTimeout(function(){ startClock() }, 500);
}

startClock();