<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UserPageMaster.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Forum.UserPage.ProfilePage" %>
<%@ MasterType VirtualPath="~/UserPage/UserPageMaster.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profile_content">
        <div class="password_form">
            <h4>Change Password</h4>
            <asp:Label class="err" ID="txtPassErr" runat="server" Text=""></asp:Label>
            <div>
            <table>
                <tr>
                    <td><label>Old password</label></td>
                    <td><asp:TextBox class="password" ID="txtOldPass" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>New password</label></td>
                    <td><asp:TextBox class="password" ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Confirmed password</label></td>
                    <td><asp:TextBox class="password" ID="txtConfirmedPass" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
            </table>
            <asp:ValidationSummary class="err" ID="ValidationSummary1" runat="server" ValidationGroup="pass_form" HeaderText="Please correct the following errors" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOPass" runat="server" ErrorMessage="Old password is required" ControlToValidate="txtOldPass" ValidationGroup="pass_form" Display="None" Font-Bold="True" ForeColor="#0E6394"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNPass" runat="server" ErrorMessage="New password is required" ValidationGroup="pass_form" ControlToValidate="txtNewPass" Display="None" ForeColor="#0E6394"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorPass" runat="server" ErrorMessage="Confirmed and new passwords must match" ControlToValidate="txtNewPass" ControlToCompare="txtConfirmedPass" ValidationGroup="pass_form" ForeColor="#0E6394" Display="None"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCPass" runat="server" ErrorMessage="Confirmed password is required" ValidationGroup="pass_form" ControlToValidate="txtConfirmedPass" Display="None" ForeColor="#0E6394"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="btnUpdatePass" runat="server" Text="Change Password" ValidationGroup="pass_form" OnClick="btnUpdatePass_Click" />
        </div>
        <hr />

        <h4>Profile image</h4>
        <p>Images must be .png or .jpg format</p>

        <div id="drop_zone"> 
            <i class="fas fa-upload"></i>
            <label for="ContentPlaceHolder1_FileUpload1">Drag and drop image here</label>
            <label id="file_label"  for="ContentPlaceHolder1_FileUpload1">Choose a file...</label> 
            <label id="result_msg"></label>
            <asp:FileUpload ID="FileUpload1" runat="server" accept=".jpg, .jpeg, .png" CssClass="input_file"/>
    
            <img id="previewImage" src=""/>
        </div>
        <div class="profile_btn_box">
            <asp:Button ID="btnUpload" runat="server" Text="Upload Image" OnClick="btnUpload_Click" CssClass="btnUpload"/>
        </div>
    </div>
    <script type="text/javascript">

        $(".password").on("change textInput input", e => {
            $("label.err").text("");
        });

        $("#ContentPlaceHolder1_FileUpload1").change(e => {
            let input = e.target;
            if (input.files && input.files[0]) {
                showPreview(input.files[0]);
            }
        });
        $("#drop_zone").on("dragover", e => {
            e.preventDefault();
            e.stopPropagation();
        });
        $("#drop_zone").on("drop", e => {
            e.preventDefault();
            e.stopPropagation();    
            let files = e.originalEvent.dataTransfer.files;
            console.log(files)
            if (validateFile(files[0])) {
                document.getElementById("ContentPlaceHolder1_FileUpload1").files = files;
                showPreview(files[0]);
            } else {
                $("#previewImage").hide();
                $("#result_msg").text("Must be .png or.jpg")
            }
        });

        function showPreview(file) {
            $("#previewImage").attr('src', window.URL.createObjectURL(file));
            $("#previewImage").show();
            $("#result_msg").text(file.name);
        }

        function validateFile(file) {
            let type = file.type;
            return type === "image/png" || type === "image/jpeg" || type === "image/jpg"
        }
    </script>
</asp:Content>
