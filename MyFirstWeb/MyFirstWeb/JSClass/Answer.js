
var name, length, qualified;
var perticipents;
var qualifiedNum = 0;
var lengthSum = 0;
var bestLength = -10, bestName;


perticipents = parseInt(prompt("Enter number of perticipents"));

for (var i = 0; i < perticipents; i++) {
    name = prompt("enter your name");
    qualified = prompt("is qualified y/n ?");
    length = parseFloat(prompt("enter length of jump"));

    if (qualified == "n") {
        document.write(name);
        document.write("<br />");
    } else {
        qualifiedNum++;
        legthSum += length;
        if (bestLength < length) {
            bestLength = length;
            bestName = name;
        }
    }
}

if (qualifiedNum > perticipents / 3) {
    document.write("the number of qualified jumps are bigger then shlish <br />");
}
document.write(lengthSum / qualifiedNum);
document.write("<br />");

document.write("The best jumber is " + bestName + "jumped: " + bestLength + "m");
