<%@ Page Title="" Language="C#" MasterPageFile="~/PostPage/PostPage.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="Forum.PostPage.ViewPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="viewPostContent">
        <div class="row">
            <!-- VIew Post Section -->
            <div class="col-7">
                <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                <br /><br />
                <asp:Image ID="postImage" runat="server" CssClass="align-middle" />
                <br />
                <asp:Label ID="lblContentMessage" runat="server" Text="Label"></asp:Label>
            </div>

            <!-- Recent Post Section -->
            <div class="col-3 border-left recentPost">
                Recent Posts
            </div>
        </div>


   </div>
</asp:Content>
