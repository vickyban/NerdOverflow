<%@ Page Title="View Post" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/PostPage/PostPage.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="Forum.PostPage.ViewPost" ValidateRequest="false" %>

<%@ Register Src="~/UserControl/CommentSection.ascx" TagPrefix="uc1" TagName="CommentSection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../lib/Comment%20ckEditor/ckeditor/ckeditor.js"></script>
    <style>
        .btnPosts:hover {
            color: #fff;
            background-color: #286090;
            border-color: #204d74;
        }
        .btnPosts{
            height: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="viewPostContent">
        <div class="row">
            <!-- VIew Post Section -->
            <div class="col-7">
                <asp:Label ID="lblDate" runat="server" Text="Label" class="date"></asp:Label>
                <br />
                <br />

                <asp:Image ID="postImage" runat="server" class="image rounded " />
                <br />
                <br />

                <asp:Label ID="lblContentMessage" runat="server" Text="Label"></asp:Label>
                <br />
                <br />

                <div class="afterPost">
                    <i class="fas fa-comments">
                        <asp:Label ID="lblComment" runat="server" Text=" 0 "></asp:Label>
                    </i>&nbsp; &nbsp;&nbsp;
                    <button id="btnReport" class="btnReport" data-toggle="modal" data-target="#myModal" onclick="return false;">
                        <i class="fas fa-flag"></i>
                        Report
                    </button>
                </div>
                <br />
                <br />
                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" class="form-control commentContent"></asp:TextBox>
                <div class="float-right">
                    <asp:Button ID="btnComment" runat="server" Text="Comment" class="btn btn-outline-primary btn-sm btnComment" OnClick="btnComment_Click" Enabled="false" CssClass="btn btn-outline-primary btn-sm btnComment" />
                </div>
                <br />
                <br />
                <hr />

                <!-- Comments -->
                <uc1:CommentSection runat="server" ID="CommentSection" />

            </div>

            <!-- Recent Post Section -->
            <div class="col-3 border-left recentPost">
                Recent Posts
                <br />
                <br />
                <div class="container ">
                    <div class="row">
                        <div class="col-sm">
                            <asp:Button ID="btnPost1" runat="server" Text="" class="btn btn-outline-primary btnPosts" />
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-sm">
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-sm">
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-sm">
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-sm">
                        </div>
                    </div>
                </div>

                <!-- Modal -->
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title">Report Post </h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="txtReason">What do you think this post violated? </label>
                                    <asp:TextBox ID="txtReason" runat="server" class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                                <button type="button" class="btn btn-outline-primary" data-dismiss="modal">cancel</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    
   

            <script>
                var editor = CKEDITOR.replace('<%= txtComment.ClientID %>');
                CKEDITOR.config.height = 100;


                // Comment box validation
                editor.on('change', function (evt) {
                    if (evt.editor.getData().length == 0) {
                        document.getElementById('<%= btnComment.ClientID %>').disabled = true;
                    } else {
                        document.getElementById('<%= btnComment.ClientID %>').disabled = false;
                    }
                });

                $(document).ready(function () {
                    SNButton.init('<%= btnSubmit.ClientID %>', {
                        fields: ['<%= txtReason.ClientID %>']
                    })
                });





            </script>
</asp:Content>
