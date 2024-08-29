<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventsHtml.aspx.cs" Inherits="JSLesson_EventsHtml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="EventsHTML.css" rel="stylesheet" />
    <script src="EventsHTML.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="3" id="console">

                    </td>

                </tr>
                <tr>
                    <td>
                        <input type="text" id="text" name="text" onkeypress="return textValidate(event)"/></td>
                    <td>
                        <select id="colors" name="colors" onchange="changeColor()">
                            <option value="null" selected="selected"></option>
                            <option value="red">Red</option>
                            <option value="blue">Blue</option>
                            <option value="green">Green</option>
                            <option value="yellow">Yellow</option>
                        </select></td>
                    <td>
                        <button id="bks" name="bks" onclick="return bcs()"><=</button></td>
                </tr>
                <tr>
                    <td>
                        <button id="btn1" name="btn1" value="1" onclick="return add1()">1</button>
                    </td>
                    <td>
                        <button id="btn2" name="btn2" value="2" onclick="return addDigit(this)">2</button></td>
                    <td>
                        <button id="btn3" name="btn3" value="3" onclick="return addDigit(this)">3</button></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
