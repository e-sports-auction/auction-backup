<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="eSport.admin" %>

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
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <title>Admin dashboard</title>
    <link rel="stylesheet" href="./styles/admin-style.css">

    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">

    <style>
        .moveTo{
            color: aliceblue;
        }
        .moveTo:hover{
            color: aliceblue;
        }
        .moveToBlack{
            color: black;
        }
        .moveToBlack:hover{
            color: black;
            text-decoration: none;
        }
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
            <div class="col-3 left-div">
                <div class="left-div-top">
                    <a class="moveTo" href="pgTrophy.aspx">
                        <img class="obj-fit" src="./assets/trophy.jpg" alt="">
                        <div class="odj-text"> <a class="odj-text" href="">TROPHY</a> </div>
                    </a>
                </div>
                <div class="left-div-bottom">
                    <div class="count-div-top row">
                        <div class="col count-of-div">
                            <asp:Label class="counts" style="color:rgb(118, 189, 118);" ID="lb_playerCount" runat="server" Text="Label"></asp:Label>
                            <span class="count-title">No.Player</span>
                        </div>
                        <div class="col count-of-div">
                            <asp:Label ID="lb_teamCount" class="counts" style="color:rgb(241, 105, 105);" runat="server" Text="Label"></asp:Label>
                            <span class="count-title">No.Team</span>
                        </div>
                    </div>
                    <div class="count-div-bottom row">
                        <div class="col count-of-div">
                            <asp:Label ID="lb_ownerCount" class="counts" style="color:rgb(102, 119, 194);" runat="server" Text="Label"></asp:Label>
                            <span class="count-title">No.Owners</span>
                        </div>
                        <div class="col count-of-div">
                            <asp:Label ID="lb_trophtCount" class="counts" style="color:rgb(224, 183, 94);" runat="server" Text="Label"></asp:Label>
                            <span class="count-title">No.Trophy</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-8 right-div">
                <div class="row first-row-right-div">
                    <nav class="navbar navbar-expand-lg">
                        <div class="container-fluid">
                          <a class="navbar-brand text-dark" href="#">Welcome Admin</a>
                          <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                          </button>
                          <div class="d-flex" id="navbarTogglerDemo02">
                            <ul class="navbar-nav navBarList me-auto mb-2 mb-lg-0">
                              <li class="nav-item ">
                                <a class="nav-link active text-dark" aria-current="page" href="#">Home</a>
                              </li>
                              <li class="nav-item">
                                <a class="nav-link text-dark" href="crudTeams.aspx">Teams</a>
                              </li>
                                 <li class="nav-item">
                                <a class="nav-link text-dark" href="/reports/report.aspx">Reports</a>
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
                    <a  class="moveToBlack" href="">
                    <div class="row">
                        <div class="col second-row-right-div-one">
                        <a href="pending-player.aspx" class="count-title">

                            Pending Players <asp:Label class="counts" style="color:rgb(118, 189, 118);" ID="lb_pendingPlayerCount" runat="server" Text="0"></asp:Label> <br>
                            <span class="count-title">
                                Accept or Decline All Your Pending Players Here
                            </span>
                        </a>
                        </div>
                        <div class="col second-row-right-div-two">
                            <img class="fit" src="./assets/virat-kholi.png" alt="">
                        </div>
                    </div>
                </a>
                </div>
                <div class="third-row-right-div">
                    <div class="count-div-top row">
                        <div class="col options">
                            <a class="moveTo"  href="trophyAuction.aspx">               
                            <img class="obj-fit" src="./assets/auction.jpg" alt="">
                            <div class="odj-text">AUCTION</div>
                        </a>
                        </div>
                        <div class="col options">
                            <a class="moveTo"  href="crudOwner.aspx">                   
                            <img class="obj-fit" src="./assets/owners.jpg" alt="">
                            <div class="odj-text">OWNERES</div>

                        </a>
                        </div>
                        <div class="col options">
                            <a class="moveTo"  href="viewTrophyForPlayerStatus.aspx">                   
                            <img class="obj-fit" src="./assets/teams.jpg" alt="">
                            <div class="odj-text">STATUS</div>
                        </a>
                        </div>
                    </div>
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
