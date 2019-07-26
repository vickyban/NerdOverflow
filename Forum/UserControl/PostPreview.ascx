<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostPreview.ascx.cs" Inherits="Forum.UserControl.PostPreview" %>
 <div class="post_detail">
        <div class="post_title">
            <asp:Label ID="lblTitle"  runat="server" Text="I feel stupid for being jealous over food"></asp:Label>
        </div>
        <div class="post_metadata">
            <div class="post_author">
                Post by
                <asp:Label ID="lblAuthor"  runat="server" Text="me"></asp:Label>
            </div>
            <div class="post_date">
                <asp:Label ID="lblPostDate"  runat="server" Text="July 2, 2019"></asp:Label>
            </div>
        </div>
 </div>