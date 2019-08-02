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
        <asp:Panel ID="panelActions" runat="server">
            <div class="comment_action">
                <label class="btnReplyToggle" onclick="onReplyToggle(event)">
                    <i class="fas fa-comment-alt"></i>
                    Reply
                </label>
            </div>
            <div class="comment_form">
                <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" CssClass="textArea box" Rows="5"></asp:TextBox>
                <div class="textArea toolbar">
                    <button class="toolbar_btn btnCancel" onclick="onCancelBtn(event)">Cancel</button>
                    <asp:Button ID="btnSendReply" runat="server" Text="Reply" class="toolbar_btn btnReply" disabled="disabled" OnClick="btnSendReply_Click" />
                </div>
            </div>
        </asp:Panel>
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
    function onReplyToggle(e) {
        let isblock = $(e.target).parent().siblings(".comment_form").css('display') === 'block' ? true : false;
        let display = "block";
        if (isblock) {
            display = "none";
        }
        $(e.target).parent().siblings(".comment_form").css('display', display);
    }
    function onCancelBtn(e) {
        e.preventDefault();
        $(e.target).parent().parent().css("display", "none");
        $(e.target).parent().siblings(".box").val("");
        $(e.target).siblings(".btnReply").prop("disabled", true);
    }
    $(".comment_form .box").on("change textInput input", e => {
        if ($(e.target).val() == '' && !$(e.target).siblings(".toolbar").children(".btnReply").prop("disabled")) {
            $(e.target).siblings(".toolbar").children(".btnReply").prop("disabled", true);
        } else if ($(e.target).val() != '' && $(e.target).siblings(".toolbar").children(".btnReply").prop("disabled")) {
            $(e.target).siblings(".toolbar").children(".btnReply").prop("disabled", false);
        }
    })
</script>