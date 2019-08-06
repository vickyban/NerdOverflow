<%@ Page Title="" Language="C#" MasterPageFile="~/Registration/Registration.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Forum.Registration.Registration1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Create Account</h2>
		<p class="lead">It's free and hardly takes more than 30 seconds.</p>
        <div class="form-group">
			<div class="input-group">
				<span class="input-group-addon"><i class="fa fa-user"></i></span>
				<!--<input type="text" class="form-control" name="username" placeholder="Username" required="required">-->
                <asp:TextBox ID="txtUserName" runat="server" type="text" class="form-control" name="username" placeholder="Username" required="required"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
			<div class="input-group">
				<span class="input-group-addon"><i class="fa fa-paper-plane"></i></span>
				<!--<input type="email" class="form-control" name="email" placeholder="Email Address" required="required">-->
                <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control" name="email" placeholder="Email Address" required="required"></asp:TextBox>
            </div>
        </div>
		<div class="form-group">
			<div class="input-group">
				<span class="input-group-addon"><i class="fa fa-lock"></i></span>
				<!--<input type="text" class="form-control" name="password" placeholder="Password" required="required">-->
                <asp:TextBox ID="txtPassword" runat="server" type="text" class="form-control" name="password" placeholder="Password" required="required"></asp:TextBox>
            </div>
        </div>

		<div class="form-group">
			<div class="input-group">
				<span class="input-group-addon">
					<i class="fa fa-lock"></i>
					<i class="fa fa-check"></i>
				</span>
				<!--<input type="text" class="form-control" name="confirm_password" placeholder="Confirm Password" required="required">-->
                <asp:TextBox ID="txtConfirm" runat="server" type="text" class="form-control" name="confirm_password" placeholder="Confirm Password" required="required"></asp:TextBox>
            </div>
        </div>  

        <div class="form-group">
            <div class="input-group">
				<span class="input-group-addon">
				    <i class="fa fa-user-plus"></i>
                    
			    </span>
               
                <asp:DropDownList ID="ddlAdmin" runat="server" Height="25px" Width="50px">
                    <asp:ListItem>YES</asp:ListItem>
                    <asp:ListItem>NO</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
		
           <asp:TextBox ID="txtAdmin" runat="server" type="text" class="form-control" name="confirm_password" placeholder="Enter your Admin ID" required="required" Visible="False"></asp:TextBox>
            
        </div>

		<div class="form-group">
            <!--<button type="submit" class="btn btn-primary btn-block btn-lg">Sign Up</button>-->
            <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" type="submit" class="btn btn-primary btn-block btn-lg" OnClick="btnSignUp_Click"/>
        </div>
		<p class="small text-center">By clicking the Sign Up button, you agree to our <br><a href="#">Terms &amp; Conditions</a>, and <a href="#">Privacy Policy</a>.</p>
</asp:Content>
