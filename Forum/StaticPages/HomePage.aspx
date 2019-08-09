<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Forum.StaticPages.HomePage" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/sb-admin-2.min.css" rel="stylesheet" />
        <link href="../Styles/style.css" rel="stylesheet" />
    <link href="../Styles/userPage.css" rel="stylesheet" />
    <link href="../css/all.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link href="../css/all.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../lib/font-awesome/css/all.css" />
   
    <link href="../Styles/style.css" rel="stylesheet" />
    <link rel="stylesheet/less" type="text/css" href="../Styles/postListStyle_less.less" />
    <link rel="stylesheet/less" type="text/css" href="../Styles/home.less" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/less.js/3.9.0/less.min.js" ></script>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
   
    <title></title>
</head>
<body>
    <uc1:Header runat="server" ID="Header" />
    <form id="form1" runat="server">
        <div class="showcase">
            <asp:Image ID="imgShowcase" runat="server" ImageUrl="~/Images/homepage.jpg" />
            <h2>:D We <3 to Help Students</h2>
            <p>THe NerdOverflow forum is a well-defined, fair and civilized web application for academic discussions in different areas
</p>
        </div>
        <div class="dev_box">
            <h2>Developers</h2>
            <div class="cards">
                <div class="card">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaY9MREBfQu8tOxMh5LFyiFXt5_jeqAtdjPSgTmDtCj2F0v8zkPg"/>
                    <h4>Gia Vien Banh</h4>
                </div>

                <div class="card">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaY9MREBfQu8tOxMh5LFyiFXt5_jeqAtdjPSgTmDtCj2F0v8zkPg"/>
                    <h4>Xuanchen Liu</h4>
                </div>

                <div class="card">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaY9MREBfQu8tOxMh5LFyiFXt5_jeqAtdjPSgTmDtCj2F0v8zkPg"/>
                    <h4>Jhon Jherick Maravilla</h4>
                </div>

                <div class="card">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaY9MREBfQu8tOxMh5LFyiFXt5_jeqAtdjPSgTmDtCj2F0v8zkPg"/>
                    <h4>Haoyue Wang</h4>
                </div>

            </div>

        </div>
        <uc1:Footer runat="server" id="Footer" />
    </form>
</body>
</html>
