<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewTrophyForPlayerStatus.aspx.cs" Inherits="eSport.viewTrophyForPlayerStatus" %>

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
    <title>Teams</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <link rel="stylesheet" href="./styles/playerStyle.css">
    <style>
        .title{
            color: white;
            font-size: 45px;
            font-weight: 600;
            margin-top: 25px;
            margin-left: 15px;
        }
        .btn{
            border-radius:10px;
            background-color:white;
            
        }
        .btn:hover{
            border-radius:10px;
            background-color:white;
            cursor:pointer;            
        }
    </style>

</head>
<body class="">
    <div class="banner">
        <img class="team-bg" src="./assets/ipl-banner.jpg" alt="">
    </div>
     <div class="container team-content">


        <nav class="navbar navbar-expand-lg">
            <div class="container-fluid">
              <a class="navbar-brand text-light" href="#">E-SPORT PVT LTD</a>
              <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="d-flex" id="navbarTogglerDemo02">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                </ul>
              </div>
            </div>
          </nav>
        <div class="title">
            <span class="">TROPHY</span>
        </div>
            <asp:DataList ID="dtl_player" runat="server" RepeatColumns="4" CellPadding="0" > 
                <ItemTemplate>
        <div class="row">
            <div class="">
                <a href="soldAndunsold-players.aspx?id=<%#Eval("TrophyID") %>">
                    <div class="">
                        <div class="row text-center">
                            <div class="col">
                                <div>
                                    <asp:Image class="profilepic" ID="Image1" runat="server" ImageUrl='<%#Eval("Logo") %>' />
                                </div>
                                <p class="playerName moveTo" style="text-decoration: none; font-size:15px;"><%#Eval("Name") %> </p>
                                <p class="playerName moveTo" style="text-decoration: none; font-size:15px;"><%#Eval("StartDate") %>-<%#Eval("EndDate") %> </p>
                            </div>
                        </div>
                    </div>
                </a>
            </div>
        </div>
                </ItemTemplate>     
            </asp:DataList>
    </div>
</body>
</html>
    </form>
</body>
</html>
