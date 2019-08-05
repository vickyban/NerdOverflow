<%@ Page Title="" Language="C#" MasterPageFile="~/PostPage/PostPage.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="Forum.PostPage.ViewPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="viewPostContent">
        <div class="row">
            <div class="col-7">
                <h2 class="text-primary">View Post</h2>
            </div>
            <div class="col-3 border-left recentPost">
                Recent Posts
            </div>
        </div>


   </div>
</asp:Content>
