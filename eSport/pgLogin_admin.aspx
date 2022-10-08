<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgLogin_admin.aspx.cs" Inherits="e_sport_trial.admin.pgLogin_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <link rel="stylesheet" href="../css/login.css"/>
    <title>E-Sports Auction</title>
        <script>
            function showPassword() {
                // Get the checkbox
                var checkBox = document.getElementById("myCheck");

                // If the checkbox is checked, display the output text
                if (checkBox.checked == true) {
                    txtPassword.type = "text";
                } else {
                    txtPassword.type = "password";
                }
            }
        </script>
        <style>
            .checkB{
                width:20px
            }
            .btnContainer{
                display: flex;
                justify-content:flex-end;
                margin-top:8px;
            }

        
        </style>
</head>

<body class="body">
    <div class="container">
        <div class="main">
            <form class="form" id="form" runat="server">
                <h3 class="head">Login</h3>
                <br/>
                <label for="email">Email</label><br/>
                <asp:TextBox id="txtEmail" type="email" name="email" runat="server"/>
                <asp:Label ID="lblError_mail" Text="enter the email" runat="server"/>
                <br/>
                <label for="password">Password</label><br/>
                <asp:TextBox id="txtPassword"  type="password" name="password" runat="server"/>
                <asp:Label ID="lblError_pass" Text="enter the password" runat="server"/>
                <div class="btnContainer">
                <input id="myCheck" class="checkB B" onclick="showPassword()" type="checkbox"/>
                <label class="check B">Show Password</label>
                </div>
                <br/><br/>
                <asp:Label ID="lblError" Text="Incorrect Password or Email" runat="server"/>
                <asp:button id="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click"/>
                <br/>
                <asp:button id="btnCancel" runat="server" text="CANCEL"/>
                <br/><br/>
                <div class="link">
                    <label >E-Sports (pvt) Ltd.</label>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
