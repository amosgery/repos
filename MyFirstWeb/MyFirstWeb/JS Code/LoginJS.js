﻿
function submitFun() {
    var userName = document.getElementById("userName").value;
    var password = document.getElementById("pass").value;
    if (userName.length == 0 || password.length == 0) {
        document.getElementById("divMsg").innerHTML = "You must enter user name and password";
        document.getElementById("divMsg").style.color = "red";
        return false;
    }
    return true;
}