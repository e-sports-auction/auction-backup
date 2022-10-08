﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="eSport.reports.report" %>

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
    <title>Players</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <link rel="stylesheet" href="../styles/playerStyle.css">
    <style>
         a{
            color:black;
            text-decoration:none;

        }
        a:hover{
            color:black;
            text-decoration:none;
        }
        .title{
            color: white;
            font-size: 45px;
            font-weight: 600;
            margin-top: 25px;
            margin-left: 15px;
        }

    </style>


</head>
<body class="banner">
  
    <div class="banner">
        <img class="team-bg" src="../assets/ipl-banner.jpg" alt="">
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
                  <li class="nav-item">
                    <a class="nav-link active text-light" aria-current="page" href="../admin.aspx">Home</a>
                  </li>
                   <li class="nav-item">
                        <a class="nav-link text-light" href="../home.aspx">Logout </a>
                      </li>
                </ul>
              </div>
            </div>
          </nav>
        <div class="title">
            <span class="">REPORTS</span>
        </div>
            <br />
            <br />
    
            <div class="card">
                <a href="playersReport.aspx?player=pending">
                  <div class="card-body">
                    <h4>Pending Players Report</h4>
                  </div>
                </a>
            </div>
            <br />

             <div class="card">
                 <a href="playersReport.aspx?player=accepted">
                     <div class="card-body">
                       <h4>Accepted Player Report</h4>
                     </div>
                 </a>
            </div>
            <br />


               <div class="card">
                 <a href="playersReport.aspx?player=decline">
                    <div class="card-body">
                        <h4>Declined Players Report</h4>
                    </div>
                 </a>
            </div>

            <br />
             <div class="card">
                 <a href="teamReport.aspx">
                    <div class="card-body">
                         <h4>Teams Report</h4>
                    </div>
                 </a>
            </div>
            <br />
    </div>
</body>
</html>
    </form>
    
</body>
</html>