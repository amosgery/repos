
var name, perticepents, qualified, length, qualifiedNum = 0, sumLength = 0, maxLength=0, maxName;

num = parseInt(prompt("enter number of perticepents"));

for (var i = 1; i <= num; i++) {
    name = prompt("enter name of jumper");
    qualified = prompt("Is qualified ? (y/n) ");
    length = parseFloat(prompt("enter length"));

    if (qualified == "n") {
        document.write(name + " is disqualified");
        document.write("<br />");
    } else {
        qualifiedNum++;
        sumLength += length;

        if (maxLength < length) {
            maxLength = length;
            maxName = name;
        }
    }
}

if (qualifiedNum / num >= 1 / 3) {
    document.write("More then 1/3 of jumps are qualified");
    document.write("<br />");
}

document.write("everage of jumps " + sumLength / qualifiedNum);
document.write("<br />");

document.write("the winner is: " + maxName + " jumped: " + maxLength);
