
function alertNumber1() {
    alert("number 1 was pressed");
}

function textchanged() {
    alert("text was changed");
}

function selectFun() {
    alert("color was changed");
}

function textValidate(e) {
    //alert("key: " + e.key + " , keyCode: " + e.keyCode);

    if (e.key >= "0" && e.key <= "9") {
        //alert("number");
        return true;
    } else {
        //alert("not number");
        return false;
    }
   
}

function addD () {

    var console = document.getElementById("console");
    console.innerHTML = console.innerHTML + "2";
    return false;
}

function addDigit(t) {
    var console = document.getElementById("console");
   
    console.innerHTML = console.innerHTML + t.value;
    return false;
}

function changeColor() {

    var console = document.getElementById("console");
    var select = document.getElementById("colors");
    var i = select.selectedIndex;
    var color = select.options[i].value;
    console.innerHTML = color;
    console.style.color = "white";
    console.style.backgroundColor = color;

}

function bcs() {
    var console = document.getElementById("console");
    var str = console.innerHTML;
    str = str.slice(0, -1);
    console.innerHTML = str;
    return false;
}

function add1() {
    var console = document.getElementById("console");

    console.innerHTML = console.innerHTML + "1";
    
    return false;
}
