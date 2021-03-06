﻿<%@ Page Title="Create Post" Language="C#" MasterPageFile="~/PostPage/PostPage.Master" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="Forum.PostPage.CreatePost" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/lib/CreatePost%20ckEditor/ckeditor/ckeditor.js"></script>
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
                <asp:ListItem>Maths</asp:ListItem>
                <asp:ListItem>Chem</asp:ListItem>
                <asp:ListItem>English</asp:ListItem>
                <asp:ListItem>Geo</asp:ListItem>
                <asp:ListItem>Arts</asp:ListItem>
                <asp:ListItem>Programming</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtContent">Post Content: </label>    
            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" class="form-control" Rows="8"></asp:TextBox>        
        </div>

        <div class="float-left">
            <asp:FileUpload ID="FileUpload1" runat="server" class="FileUpload" hidden="hidden" accept=".png,.jpg,.jpeg,.gif,.bmp"/>
            <button type="button" id="btnUpload" class="uploadStyle btn btn-success">Choose a file</button>
            <span id="custom-text">No file chosen.</span>
        </div>

        <div class="float-right">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Post" class="btn btn-outline-success" OnClick="btnSubmit_Click" />
        </div>


    </div>

    <!-- JAVASCRIPT AREA -->
    <script>

        // This code will change the format of the TextBox and add a toolbar. It will give the user a better way of formatting their posts.
        CKEDITOR.replace('<%= txtContent.ClientID %>');

        // These are instances of the fileuploader, the button to style it, and the name of the file the user uploads.
        const realFileBtn = document.getElementById('<%= FileUpload1.ClientID %>');
        const customBtn = document.getElementById("btnUpload");
        const customTxt = document.getElementById("custom-text");

        // Button eventListener
        customBtn.addEventListener("click", function () {
            realFileBtn.click();

        });

        // File upload eventListener. To change the default text value of the FileUpload button
        realFileBtn.addEventListener("change", function () {
            if (realFileBtn.value) {
                customTxt.innerHTML = realFileBtn.value.match(/[\/\\]([\w\d\s\.\-\(\)]+)$/)[1];
            } else {
                customTxt.innerHTML = "No file chosen, yet.";
            }
        });

        // To validate the submit button.
        $(document).ready(function () {
            SNButton.init('<%= btnSubmit.ClientID %>', {
                fields: ['<%= txtTitle.ClientID %>', '<%= ddCategory.ClientID %>']
            })
        });

    </script>

</asp:Content>
