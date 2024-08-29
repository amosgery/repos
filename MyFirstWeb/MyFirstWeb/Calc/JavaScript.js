var num = 0;
var opr = "";


function digit(d) {
    
    var console = document.getElementById("console");
    console.innerHTML = console.innerHTML + d;
    //console.style.backgroundColor = "blue";
    return false;
}

function bsc() {
    var console = document.getElementById("console");
    var str = console.innerHTML;
    console.innerHTML = str.slice(0, -1);
    
    return false;
}

function ac() {
    document.getElementById("console").innerHTML = "";
    num = 0;
    opr = "";
    return false;
}

function operand(op) {

    var console = document.getElementById("console");
    num = Number(console.innerHTML);
    opr = op;
    console.innerHTML = "";

}

function equal() {
    var res = 0;
    var console = document.getElementById("console");
    var num2 = Number(console.innerHTML);
    if (opr == "x") {
        res = num * num2;

    } else if (opr == "+") {
        res = num + num2;
    } else if (opr == "-") {
        res = num - num2;
    }
    console.innerHTML = res;
    opr = "=";
    num = res;
    return false;
}