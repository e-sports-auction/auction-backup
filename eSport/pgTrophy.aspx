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
    <style>
        #btnAdd {
            width: 215px;
            height: 35px;
            border-style: none;
            background-color: #f0ad4e;
            color: white;
            font-weight: bold
        }

        td {
            width: 1500px;
            padding-left: 10px;
        }

        th {
            width: 1500px;
            padding: 10px;
        }
    </style>
</head>
<body class="body">
    <div class="container">
        <form id="form" runat="server">
        <div class="row">
            <div class="col">
                <div class="form">
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
                    <label for="price">Team Price</label><br/>
                    <asp:TextBox id="txtPrice" type="number" name="price" runat="server"/>
                    <br/>
                    <label for="logo">Logo</label><br/>
                    <asp:FileUpload ID="fileLogo" runat="server" />
                    <br/>
                    <asp:Label ID="lblError" runat="server"/>
                    <asp:button id="btnCreate" Text="CREATE" runat="server" OnClick="btnCreate_Click"/>
                    <br/>
                     <asp:button id="btnUpdate" runat="server" text="UPDATE" OnClick="btnUpdate_Click"/>
                    <br />
                    <asp:button id="btnCancel" runat="server" text="CANCEL"/>
                    <br/><br/>
                </div>
            </div>
            <div class="col">
                     <table class="table">
                          <thead class="table-light">
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Logo</th>
                            <th scope="col">Name</th>
                            <th scope="col">Start date</th>
                            <th scope="col">End date</th>
                            <th scope="col">Venue</th>
                            <th scope="col">Price</th>
                            <th scope="col">Teams</th>
                            <th scope="col">Edit</th>
                        </tr>
                    </thead>
                        <asp:DataList ID="dtl_Trophy" RepeatColumns="7" runat="server">
                            <ItemTemplate>
          
                           <tbody>
                            <tr>
                                <th scope="row"> <%#Eval("TrophyID") %></th>
                                <td>
                                    <div >
                                     <asp:Image class="logo" ID="logo" runat="server" ImageUrl='<%#Eval("Logo") %>' />
                                    </div>
                                </td>
                                <td> <%#Eval("Name") %></td>
                                <td> <%#Eval("StartDate") %></td>
                                <td> <%#Eval("EndDate") %></td>
                                <td> <%#Eval("Venue") %></td>
                                <td> <%#Eval("TeamPrice") %></td>
                                <asp:Button ID="btnView" class="btn1" runat="server" Text="View" CommandArgument='<%#Eval("TrophyID") %>' OnClick="btnView_Click" />
                                <td>
                                    <asp:Button ID="btnEdit" class="btnx" runat="server" Text="Edit"  CommandArgument='<%#Eval("TrophyID") %>' OnClick="btnEdit_Click" />
                                    <asp:Button ID="btnDelete" class="btny" runat="server" Text="Delete" CommandArgument='<%#Eval("TrophyID") %>' OnClick="btnDelete_Click"/>
                                </td>
                             </tr>
                            </tbody>
                                      
                            </ItemTemplate>
                        </asp:DataList>
                   </table>
                
                <div class="team-list mt-5">
                    <div class="row mt-4">
                        <div class="col-3">
                            <div class="h">
                                <asp:Image class="log" ID="logoTrophy" runat="server" ImageUrl='<%#Eval("Logo") %>' />
                                 <asp:Label class="tid" ID="lblTrophyid" runat="server" />
                                <asp:Label class="h5" ID="lblTrophyname" runat="server" />
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="tab">
                            <asp:DataList ID="dtlTeams" RepeatColumns="3" runat="server">
                            <ItemTemplate>                                
                                <table> 
                                    <tr>
                                        <td><asp:Image class="lo" ID="logoTeam" runat="server" ImageUrl='<%#Eval("Logo") %>' /><div class="lo"></div></td>
                                        <td><%#Eval("Name") %></td>
                                    </tr>
                                 </table>
                               </ItemTemplate>
                            </asp:DataList>
                                </div>
                            </div>
                        </div>
                    <label for="team">Team</label><br/>
<%--                    <asp:DropDownList id="dplTeam" runat="server"/>--%>
                    <asp:DropDownList ID="dplTeam" runat="server"></asp:DropDownList>
                     <asp:Label ID="lblTError" runat="server"/>
                    <asp:Button id="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
                    <br/>
                    <button class="btn2">Close</button>
                </div>
            </div>
        </div>
     </form>
    </div>
</body>
</html>