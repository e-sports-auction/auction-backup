<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="player-dashboard.aspx.cs" Inherits="eSport.player_dashboard" %>

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
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <title>Player dashboard</title>
    <link rel="stylesheet" href="./styles/admin-style.css">

    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">

    <style>
         a{
            color:white;
        }
        a:hover{
            color:white;
            text-decoration:none;
        }
        .count-title{
            color:black;

        }
        .count-title:hover{
             color:black;
            text-decoration:none;
        }
    </style>


</head>
  <body class="bg">
    <div class="container-fluid">
        <div class="row">
            <div style="margin-left: 55px;" class="col-11 right-div">
                <div class="row first-row-right-div">
                    <nav class="navbar navbar-expand-lg">
                        <div class="container-fluid">
                          <a class="navbar-brand text-dark" href="#">Welcome Player</a>
                          <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                          </button>
                          <div class="d-flex" id="navbarTogglerDemo02">
                            <ul class="navbar-nav navBarList me-auto mb-2 mb-lg-0">
                              <li class="nav-item ">
                                <a class="nav-link active text-dark" aria-current="page" href="home.aspx">Home</a>
                              </li>
                              <li class="nav-item">
                                <a class="nav-link text-dark" href="players.aspx">Players</a>
                              </li>
                              <li class="nav-item">
                                <a class="nav-link text-dark" href="home.aspx">Logout</a>
                              </li>
                            </ul>
                          </div>
                        </div>
                      </nav>
                </div>
                <div class="second-row-right-div">
                    <div class="row">
                        <div class="col second-row-right-div-one">
                        <a class="count-title" href="viewTrophy.aspx">
                            Register For Trophy <br>
                            <span class="count-title">
                                Register into any trophy that you want
                            </span>
                        </a>
                        </div>
                        <div class="col second-row-right-div-two">
                            <img class="fit" src="./assets/ipl-cup.png" alt="">
                        </div>
                    </div>
                </div>
                <div style="margin-bottom: 55px;" class="third-row-right-div">
                    <asp:DataList ID="dtl_player" runat="server">
                        <ItemTemplate>
                    <div class="count-div-top row">
                        <div class="col options">
                                    <a href="player-details.aspx?id=<%#Eval("PlayerID") %>">
                                    <img class="obj-fit" src="./assets/crick.jpg" alt="">
                                    <div class="odj-text">ABOUT</div>
                                    </a>
                               
                        </div>
                        <div class="col options">
                            <a href="viewTrophyForPlayerStatus.aspx">
                            <img class="obj-fit" src="./assets/auction.jpg" alt="">
                            <div class="odj-text">AUCTION</div>
                            </a>

                        </div>
                        <div class="col options">
                            <a href="players.aspx" >
                            <img class="obj-fit" src="./assets/teams.jpg" alt="">
                            <div class="odj-text">PLAYERS</div>
                            </a>

                        </div>
                    </div>
                 </ItemTemplate>
               </asp:DataList>
                </div>
            </div>
        </div>
    </div>
  </body>
      

    <script src="./assets/script.js"></script>
</div>  
</html>
    </form>
</body>
</html>
