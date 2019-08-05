<%@ Page Title="Create Post" Language="C#" MasterPageFile="~/PostPage/PostPage.Master" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="Forum.PostPage.CreatePost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h2 class="text-primary">Create a post</h2>
        <hr />

        <div class="form-group">
            <label for="txtTitle">Title: </label>
            <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="ddCategory">Category: </label>
            <asp:DropDownList ID="ddCategory" runat="server" class="form-control">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Math</asp:ListItem>
                <asp:ListItem>Science</asp:ListItem>
                <asp:ListItem>English</asp:ListItem>
                <asp:ListItem>Health</asp:ListItem>
                <asp:ListItem>Arts</asp:ListItem>
                <asp:ListItem>Music</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group ">
            <label for="txtContent">Post Content: </label>
            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" class="form-control" Rows="7"></asp:TextBox>
        </div>
        <br />

        <div class="upload">
            <asp:FileUpload ID="FileUpload1" runat="server" class="FileUpload" hidden="hidden"/>
            <button type="button" id="btnUpload" class="uploadStyle btn btn-success">Choose a file</button>
            <span id="custom-text">No file chosen.</span>
        </div>


        <br />

    </div>

    <script>
        CKEDITOR.replace("txtContent");
    </script>

</asp:Content>
