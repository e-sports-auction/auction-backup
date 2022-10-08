<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pending-player-details.aspx.cs" Inherits="eSport.pending_player_details" %>

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
    <title>Player-Details</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <link rel="stylesheet" href="./styles/playerStyle.css">

</head>

<style>
    .FadeAway{
        margin-top: -100px;
    }

    .priceDiv{
        margin-top:-180px;
        margin-left:650px;
    }

    .heroPic{
        margin-left:-70px;
    }
    .blur{
        margin-top: -40px;
        margin-left:-30px;
    }
    .heroBgR{
        width:535px;
         margin-left: -35px;
    }
</style>


        
            <asp:DataList ID="dtl_playerDetails" runat="server">
                <ItemTemplate>
                    <body class="blur">
    <div class="container-fluid">
        <div class="row">
            <nav class="navbar navbar-expand-lg">
                <div class="container-fluid">
                  <a class="navbar-brand text-light" href="#">E-SPORT PVT LTD</a>
                  <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                  </button>
                  <div class="d-flex" id="navbarTogglerDemo02">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                          <li class="nav-item">
                        <a class="nav-link text-light" href="admin.aspx">Home </a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link active text-light" aria-current="page" href="pending-player.aspx">Back</a>
                      </li>
                        <li class="nav-item">
                        <a class="nav-link text-light" href="home.aspx">Logout </a>
                      </li>
                    </ul>
                  </div>
                </div>
              </nav>
                <div class="col heroPic">
                    <div class="FadeAway">
                       <asp:Image class="heroBgR" ID="Image1" runat="server" ImageUrl='<%#Eval("Image") %>' />
                    </div>
                </div>
                <div class="col" style="text-align:left;">
                    <div class="dis-name">
                        <%#Eval("FirstName") %> <%#Eval("LastName") %>
                        <div class="row attributes">
                            <div class="col-12"><%#Eval("Role") %></div>
                            <div class="col-12"><%#Eval("ArmStyle") %></div>
                        </div>
                    </div>
                    <table>
                        <tr>
                            <td>Matches</td>
                            <td>Runs</td>
                            <td>Wickets</td>

                        </tr>
                        <tr>
                            <td class="result"><%#Eval("Matches") %></td>
                            <td class="result"><%#Eval("Runs") %></td>
                            <td class="result"><%#Eval("Wickets") %></td>
                        </tr>
                    </table>

                </div>
                </div>
            </div>
        </body>
                </ItemTemplate>
            </asp:DataList>
            <div class="priceDiv">
                    <asp:TextBox ID="txt_price" class="priceInput" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSetPrice"  class="btn btn-warning" runat="server" Text="Set Base Price" OnClick="btnSetPrice_Click" />
                    <asp:Button ID="btnDecline"  class="btn btn-danger" runat="server" Text="Decline" OnClick="btnDecline_Click" />

            </div>
</html>
    </form>
</body>
</html>
