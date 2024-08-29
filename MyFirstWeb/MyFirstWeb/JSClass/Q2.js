

var sum = 0; j = 0;
var num;

var n = parseInt(prompt("enter number of integers"));
for (var i = 0; i < n; i++) {
    num = parseInt(prompt("enter"));
    if (num > 0) {
        j++;
        sum += num;
        document.write("the number is: " + num);
    }
}

sum -= num;
document.write(j);
document.write(sum);