<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgTrophy.aspx.cs" Inherits="e_sport_trial.admin.pgTrophy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <link rel="stylesheet" href="../css/trophy.css"/>
    <title>E-Sports Auction</title>
</head>
<body class="body">
    <div class="container">
        <div class="row">
            <div class="col">
                <form class="form" runat="server">
                    <h3 class="head">Trophy</h3>
                    <br/>
                    <label for="troname">Trophy Name</label><br/>
                    <asp:TextBox id="txtTroname" type="text" name="troname" runat="server"/>
                    <br/>
                    <label for="startdate">Start Date</label><br/>
                    <asp:TextBox id="txtStart" runat="server" placeholder="mm/dd/yyyy" Textmode="Date"/>
                    <br/>
                    <label for="enddate">End Date</label><br/>
                    <asp:TextBox id="txtEnd" runat="server" placeholder="mm/dd/yyyy" Textmode="Date"/>
                    <br/>
                    <label for="venue">Venue</label><br/>
                    <asp:TextBox id="txtVenue" type="text" name="vnue" runat="server"/>
                    <br/>
                    <label for="team">Team</label><br/>
                    <asp:DropDownList id="dplTeam" runat="server"  Enabled="true"  AutoPostBack="false"/>
                    <br/>
                    <label for="logo">Logo</label><br/>
                    <input type="file" name="logo" id="logo"/>
                    <br/>
                    <asp:Label ID="lblError" runat="server"/>
                    <asp:button id="btnCreate" Text="CREATE" runat="server"/>
                    <br/>
                    <asp:button id="btnCancel" runat="server" text="CANCEL"/>
                    <br/><br/>
                </form>
            </div>
            <div class="col">
                <table class="table">
                    <thead class="table-light">
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Logo</th>
                            <th scope="col">Name</th>
                            <th scope="col">Venue</th>
                            <th scope="col">Start date</th>
                            <th scope="col">End date</th>
                            <th scope="col">Teams</th>
                            <th scope="col">Edit</th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td><div class="logo"></div></td>
                            <td>Otto</td>
                            <td>Colombo</td>
                            <td>16/09/2022</td>
                            <td>16/12/2022</td>
                            <td><button class="btn1">View</button></td>
                            <td>
                                <button class="btnx">Edit</button>
                                <button class="btny">Delete</button>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">2</th>
                            <td><div class="logo"></div></td>
                            <td>Thornton</td>
                            <td>Galle</td>
                            <td>16/09/2022</td>
                            <td>16/12/2022</td>
                            <td><button class="btn1">View</button></td>
                            <td>
                                <button class="btnx">Edit</button>
                                <button class="btny">Delete</button>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">3</th>
                            <td><div class="logo"></div></td>
                            <td>Larry</td>
                            <td>Galle</td>
                            <td>16/09/2022</td>
                            <td>16/12/2022</td>
                            <td><button class="btn1">View</button></td>
                            <td>
                                <button class="btnx">Edit</button>
                                <button class="btny">Delete</button>
                            </td>
                          </tr>
                    </tbody>
                </table>
                <div class="team-list mt-5">
                    <div class="row mt-4">
                        <div class="col-3">
                            <div class="h">
                                <div class="log"></div>
                                <h5>Name</h5>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="tab">
                                <table> 
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="tab">
                                <table> 
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="tab">
                                <table> 
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                    <tr>
                                        <td><div class="lo"></div></td>
                                        <td>Royal</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <button class="btn2">Close</button>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
