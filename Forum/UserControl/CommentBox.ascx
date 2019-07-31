<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentBox.ascx.cs" Inherits="Forum.UserControl.CommentBox" %>


<li class="comment_box">
    <asp:HiddenField ID="fcommentId" runat="server" />
    <asp:HiddenField ID="fpostId" runat="server" />
    <asp:HiddenField ID="fuserId" runat="server" />

    <label class="comment_toggle" onclick="onToggle(event)">-</label>
    
    <div class="comment_metadata">
        <asp:Label ID="lblAuthor" runat="server" Text="Poyo"></asp:Label>
        <asp:Label ID="lblCreatedAt" runat="server" Text="Today"></asp:Label>
    </div>
    <div class="comment_toggle_box">
        <div class="comment_content">
            <asp:Label ID="lblContent" runat="server" Text="This will be a long day"></asp:Label>
        </div>
        <div class="comment_action">
            <div>
                <i class="fas fa-comment-alt"></i>
                <asp:Button ID="btnReply" runat="server" Text="Reply" />
            </div>
        </div>
        <ul class="comment_replies">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </ul>
    </div>
</li>

<script type="text/javascript">
    function onToggle(e) {
        let isblock = $(e.target).siblings(".comment_toggle_box").css('display') === 'block' ? true : false;
        let display = "block";
        let sign = "-";
        if (isblock) {
            display = "none";
            sign = "+";
        }
        $(e.target).html(sign);
        $(e.target).siblings(".comment_toggle_box").css('display', display);
     
    }
</script>
