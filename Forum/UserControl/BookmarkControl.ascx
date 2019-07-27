<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookmarkControl.ascx.cs" Inherits="Forum.UserControl.BookmarkControl" %>
<div class="post">
    <asp:HiddenField ID="bookmarkId" runat="server" />
    <div class="post_title">
        <asp:HyperLink ID="postUrl" runat="server" BorderStyle="None" NavigateUrl="https://www.google.ca/">
                <asp:Label ID="lblTitle"  runat="server" Text=""></asp:Label>
        </asp:HyperLink>
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
            <asp:Button ID="btnDelte" runat="server" Text="UnSave" OnClick="btnDelte_Click" />
        </div>
    </div>

</div>