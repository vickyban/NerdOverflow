<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostPreviewWithActions.ascx.cs" Inherits="Forum.UserControl.PostPreviewWithActions" %>
<div class="post">

    <div class="post_title">
            <asp:Label ID="lblTitle"  runat="server" Text=""></asp:Label>
    </div>
    <div class="post_metadata">
        <div class="post_category">
            <asp:Label ID="lblCategory"  runat="server" Text=""></asp:Label> 
        </div>
        <div class="post_author">Post by 
            <asp:Label ID="lblAuthor"  runat="server" Text=""></asp:Label> 
        </div>
        <div class="post_date">
            <asp:Label ID="lblPostDate"  runat="server"></asp:Label>
        </div>
    </div>
    <div class="post_others">
        <div class="post_comment">
            <asp:ImageButton ID="btnCommentIcon" runat="server" ImageUrl="~/Images/commentIcon.png" ImageAlign="Left" Width="22px" Height="17px" />
            <asp:Label ID="lblComment" runat="server" Text="Comment"></asp:Label>
        </div>
        <div class="post_delete">
            <asp:ImageButton ID="btnDeleteIcon" runat="server" ImageUrl="~/Images/deleteIcon.png" Width="22px" />
            <asp:Button ID="btnDelte" runat="server" Text="Delete" />
        </div>
        <div class="post_edit">
            <asp:ImageButton ID="btnEditIcon" runat="server" ImageUrl="~/Images/editIcon.png" Width="22px" />
            <asp:Button ID="btnEdit" runat="server" Text="Edit" />
        </div>
    </div>

</div> 