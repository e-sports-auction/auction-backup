<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crudTeams.aspx.cs" Inherits="eSport.crudTeams" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <link rel="stylesheet" href="../css/trophy.css"/>
    <title>E-Sports Teams</title>

    <style>
        .hide{
            display:none;
        }

        .btnUpdate {
            width: 70px;
            height: 30px;
            background-color: transparent; 
            color: white;
            font-size: small;
            font-weight: bold;
            border: 1px solid white;
            border-radius: 5px;
            opacity: 0.7;
        }

        .btnUpdate:hover {
            background-color: #008080;
            border-color:#008080;
            opacity: 1;
        }
        .btnDelete {
            width: 70px;
            height: 30px;
            background-color: transparent; 
            color: #DC3545;
            font-size: small;
            font-weight: bold;
            border: 2px solid #DC3545;
            border-radius: 5px;
            margin-left:5px;
        }

        .btnDelete:hover {
            background-color: #DC3545;
            color: white;
        }

        td{
            padding-left:25px;
            margin-left:15px;
        }

        .btnContainer{
            display: flex;
        }

        .btn{
            justify-content: center;
        }

        .trID{
            margin-left:25px;
        }

    </style>
</head>
<body class="body">
    <div class="container">
        <div class="row">
            <div class="col">

                <form class="form" runat="server">
                    <h3 class="head">Team</h3>
                    <br/>
                    <label for="troname">Team Name</label><br/>
                    <asp:TextBox id="txtTeamName" type="text" name="txtTeamName" runat="server"/>
                    <asp:Label class="hide" ID="lb_teamID" runat="server"/>
                    <br/>
                     <label for="troname">Team Ambassador</label><br/>
                    <asp:TextBox id="txtAmbassador" type="text" name="txtAmbassador" runat="server"/>
                    <br/>
                    <label for="image">Logo</label><br/>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                    <label for="team">Owner</label><br/>
                    <asp:DropDownList id="dplOwner" runat="server"  Enabled="true"  AutoPostBack="false"/>
                    <br/>
                     <label for="team">Trophy</label><br/>
                    <asp:DropDownList id="dplTrophy" runat="server"  Enabled="true"  AutoPostBack="false"/>
                    <br/>
                    <asp:Label ID="lblError" runat="server"/>
                    <asp:button id="btnCreate" Text="CREATE" runat="server" OnClick="btnCreate_Click"/>
                    <br/>
                    <asp:button id="btnEdit" runat="server" text="UPDATE" OnClick="btnEdit_Click"/>
                    <br/><br/>
            </div>
            <div class="col">
                <table class="table">
                    <thead class="table-light">
                        <tr>
                            <th scope="col">Logo</th>
                            <th scope="col">Name</th>
                            <th scope="col">Owner</th>
                            <th scope="col">Ambassador</th>
                            <th scope="col">Trophy</th>
                            <th scope="col">Edit</th>
                            <th scope="col">Delete</th>

                        </tr>
                    </thead>
                    <asp:DataList RepeatColumns="5" ID="dl_teams" runat="server">
                        <ItemTemplate>
                            <tbody>
                        <tr>
                            <td>
                                <div>
                                <asp:Image class="logo" ImageUrl='<%#Eval("Logo") %>' ID="Image1" runat="server" />
                                </div>
                            </td>
                            <td><%#Eval("Name") %></td>
                            <td><%#Eval("OwnerID") %></td>
                            <td><%#Eval("Ambassador") %></td>
                            <td class="trID"><%#Eval("TrophyID") %></td>
                            <td class="btnContainer">
                                <asp:Button ID="btnUpdate" class=" btn btnUpdate" runat="server" Text="EDIT"  CommandArgument='<%#Eval("TeamID") %>' OnClick="btnUpdate_Click"/>
                                <asp:Button ID="btnDelete"  class="btn btnDelete" runat="server" Text="Delete"  CommandArgument='<%#Eval("TeamID") %>' OnClick="btnDelete_Click"/>
                            </td>
                        </tr>
                    </tbody>
                        </ItemTemplate>
                    </asp:DataList>
                    
                    
                </table>
            </div>
        </div>
    </div>
    </form>

</body>
</html>
