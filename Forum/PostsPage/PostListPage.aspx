<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostListPage.aspx.cs" Inherits="Forum.PostsPage.PostListPage" MaintainScrollPositionOnPostback="True" %>

<%@ Register Src="~/UserControl/PostPreviewWithActions.ascx" TagPrefix="uc1" TagName="PostPreviewWithActions" %>
<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Styles/style.css" rel="stylesheet" />
    <link href="../Styles/userPage.css" rel="stylesheet" />
    <link href="../css/all.min.css" rel="stylesheet" />
    <link href="../css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link href="../css/all.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../lib/font-awesome/css/all.css" />
   
    <link href="../Styles/style.css" rel="stylesheet" />

    <link rel="stylesheet/less" type="text/css" href="../Styles/postListStyle_less.less" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/less.js/3.9.0/less.min.js" ></script>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
   
    <title></title>
</head>
<body>
    <script type="text/javascript" src='<% = ResolveUrl("~/js/alertBox.js")%>'></script>
    <uc1:Header runat="server" id="Header" />
    <form id="form1" runat="server">
       <div class="content">
           <div class="content_left">
               <a href="/posts/?keyword=&filters=bio&sort=DESC">
                   <asp:Image ID="imgBio" runat="server" ImageUrl="~/Images/bacteria.png" />
                   Bio
               </a>
                <a href="/posts/?keyword=&filters=27chem&sort=DESC">
                   <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/flasks.png" />
                   Chem
               </a>
                <a href="/posts/?keyword=&filters=maths&sort=DESC">
                   <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/axis.png" />
                   Maths
               </a>
            <a href="/posts/?keyword=&filters=geo&sort=DESC">
                   <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/earth.png" />
                   Geo
               </a>
                <a href="/posts/?keyword=&filters=physic&sort=DESC">
                   <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/apple.png" />
                   Physic
               </a>
                <a href="/posts/?keyword=&filters=programming&sort=DESC">
                   <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/programming.png" />
                   Programming
               </a>

           </div>

            <div class="content_mid">
               <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>

           <div class="content_rule">
               <h5><strong>Rules</strong></h5>
               <ul>
                   <li>Be Nice to Everyone</li>
                   <li>No Discrimation</li>
                   <li>Do NOT ask to do homework/assigments</li>
                   <li>Ask specific questions</li>
               </ul>
           </div>
       </div> 

        <uc1:Footer runat="server" id="Footer" />
    
    </form>

</body>
</html>
