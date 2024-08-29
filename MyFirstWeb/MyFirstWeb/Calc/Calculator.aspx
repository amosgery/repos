<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calculator.aspx.cs" Inherits="Calc_Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Calculator.css" rel="stylesheet" />
    <script src="JavaScript.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="4">מחשבון</td>
            </tr>
            <tr>
                <td colspan="4" id="operTd"></td>
            </tr>
            <tr>
                <td id="console" colspan="4"></td>

            </tr>
            <tr>
                <td>
                    <input type="button" value="%" />
                </td>
                <td>
                    <input type="button" value="AC" onclick="return ac()"/>
                </td>
                <td>
                    <input type="button" value="&lArr;" onclick="return bsc()" />
                </td>
                <td>
                    <input type="button" value="/" onclick="return operand(this.value) " />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" value="7" onclick="return digit(this.value)" />
                </td>
                <td>
                    <input type="button" value="8" onclick="return digit(this.value)" />
                </td>
                <td>
                    <input type="button" value="9" onclick="return digit(this.value)" />
                </td>
                <td>

                    <input type="button" value="x" onclick="return operand('x') "/>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" value="4" onclick="return digit(this.value)" />
                </td>
                <td>
                    <input type="button" value="5" onclick="return digit('5')" />
                </td>
                <td>
                    <input type="button" value="6" onclick="return digit('6')" />
                </td>
                <td>
                    <input type="button" value="-" onclick="return operand('-') " />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" value="1" onclick="return digit('1')"/>
                </td>
                <td>
                    <input type="button" value="2" onclick="return digit('2')" />
                </td>
                <td>
                    <input type="button" value="3" onclick="return digit('3')" />
                </td>
                <td>
                    <input type="button" value="+" onclick="return operand('+') " />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" value="+/-" />
                </td>
                <td>
                    <input type="button" value="0" onclick="return digit(this.value)" />
                </td>
                <td>
                    <input type="button" value="." onclick="return digit(this.value)" />
                </td>
                <td>
                    <input type="button" value="=" onclick ="return equal()"/>
                </td>
            </tr>


        </table>
    </form>
</body>
</html>
