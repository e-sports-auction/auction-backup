﻿    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="eSport.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <link rel="stylesheet" href="./styles/style.css">

    <title>Home Page</title>
    <style>
        .dropdownL{
            background-color:transparent;
            color:white;
            border:none;
        }
        .dropdown-item{
            color:black;
        }
    </style>
</head>
<body class="abc">
    <nav class="navbar navbar-expand-lg">
        <div class="container-fluid">
          <a class="navbar-brand text-light" href="#">E-SPORT PVT LTD</a>
          <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="d-flex" id="navbarTogglerDemo02">
              <li class="nav-item">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <a class="nav-link active text-light" aria-current="page" href="#">Home</a>
              </li>
              <li class="nav-item dropdownlist">
                <a class="nav-link active text-light" aria-current="page" href="#">
                <asp:DropDownList class="nav-item dropdownL" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                    
                    <asp:ListItem Selected="true" class="dropdown-item" Text="Login">Login</asp:ListItem>
                    <asp:ListItem class="dropdown-item" Value="pgLogin_admin.aspx?id=admin">Admin</asp:ListItem>
                    <asp:ListItem class="dropdown-item" Value="pgLogin_admin.aspx?id=player">Player</asp:ListItem>
                    <asp:ListItem class="dropdown-item" Value="pgLogin_admin.aspx?id=owner">Owner</asp:ListItem>
                  </asp:DropDownList>
                    </a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <div class="row text-light">
        <div class="col heading">
            <h1>Champions will<br>  
              play with <br>
                 greate matches.</h1>
            <p>Tournament of cricket encounters.</p>
            <asp:Button ID="btn_Reg" class="btn2" runat="server" Text="Register" OnClick="btn_Reg_Click" />
        </div>
      
      </div>
</body>
</html>
    </form>
</body>
</html>
