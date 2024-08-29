<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="WebPages_Main" Title="Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/MainStyle.css" rel="stylesheet" />
    <link href="../CSS/HorizonalBar.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img src="../Img/game-of-thrones_Logo.jpg" class="logo" />
        </div>

        <ul>
            <li><a class="active" href="../GameOfThrones/MainPage.html">Main Page</a> </li>
            <li><a href="../GameOfThrones/DaenerysPage.html">Daenerys</a> </li>
            <li><a href="../GameOfThrones/JonSnow.html">Jon Snow</a> </li>
            <li><a href="../GameOfThrones/Arya.html">Arya</a> </li>
            <li><a href="../GameOfThrones/NedStark.html">Ned Stark</a> </li>
            <li class="dropDown">
                <a href="https://en.wikipedia.org/wiki/Game_of_Thrones">Wikipedia </a>
                <div class="dropDownContent">
                    <a href="https://en.wikipedia.org/wiki/Game_of_Thrones_(season_1)">season 1</a>
                    <a href="https://en.wikipedia.org/wiki/Game_of_Thrones_(season_2)">season 2</a>
                    <a href="https://en.wikipedia.org/wiki/Game_of_Thrones_(season_3)">season 3</a>
                    <a href="https://en.wikipedia.org/wiki/Game_of_Thrones_(season_4)">season 4</a>
                    <a href="https://en.wikipedia.org/wiki/Game_of_Thrones_(season_5)">season 5</a>
                </div>
            </li>
            <li><a href="../GameOfThrones/Login.html">Login</a></li>
            <li><a href="../GameOfThrones/CharactersTable.html">CharactersTable</a> </li>
        </ul>

        <div>

            <hr />

            <h1 class="center">Game <span>Of</span> Thrones</h1>


            <p dir="rtl">משחקי הכס היא היא סדרת פנטזיה טלוויזיונית אמריקאית מצליחה. </p>
            <p dir="rtl">
                הסדרה מבוססת על "שיר של אש ושל קרח" – סדרת ספרי פנטזיה אפית מאת הסופר האמריקאי ג'ורג' ר. ר. מרטין.
            <br />
                עלילת הסדרה המתרחשת בעולם בדיוני המדמה את תקופת ימי הביניים ומשולבת במוטיבים של פנטזיה.
            היא נושאת את שם הכרך הראשון של סדרת הספרים הזאת "משחקי הכס".
            </p>
        </div>

        <div style="display: none">
        </div>


    </form>
</body>
</html>
