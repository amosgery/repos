
var sum = 0, num, i=0;

num = parseInt(prompt("enter number"));
while (num >= 0) {

    sum = sum + num;
    i++;
    num = parseInt(prompt("enter number"));
}

document.write("the sum is: " + sum);
document.write("<br /> the number of students is: " + i);
document.write("<br /> the everage is: " + sum/i);
