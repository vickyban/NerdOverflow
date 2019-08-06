<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Forum.UserPage.Header" %>
<header>
    <a href="/">
        <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/logo.png" />
    </a>
</header>
<div class="search_bar">
    <div class="sortBy">
        <label class="smallFont">SORT</label>
        <asp:DropDownList ID="dlistSortBy" runat="server">
            <asp:ListItem Value="DESC">Newest</asp:ListItem>
            <asp:ListItem Value="ASC">Oldest</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="filter"> 
        <label id="filter_toggle" class="lnk smallFont">FILTER <i class="fas fa-ellipsis-v"></i></label>
            
        <asp:Panel ID="panel1" CssClass="filter_panel" runat="server">
            <div>
                <label class="hightlight">Category</label>
            </div>
            <div>
            <asp:CheckBox ID="cbAll" class="cbAll all" runat="server" Text="All" Checked="True" />
            </div>
            <div>
                <asp:CheckBox ID="cbMath" class="opt" runat="server" Text="Maths" />
            </div>
            <div>
                <asp:CheckBox ID="cbBio" class="opt"  runat="server" Text="Bio" />
            </div>
            <div>
                    <asp:CheckBox ID="cbPhysic" class="opt"  runat="server" Text="Physic" />
            </div>
            <div>
                    <asp:CheckBox ID="cbChem" class="opt"  runat="server" Text="Chemistry" />
            </div>       
            <div>
                <asp:CheckBox ID="cbHistory" class="opt"  runat="server" Text="History" />
            </div>
            <div>
                    <asp:CheckBox ID="cbProgram" class="opt"  runat="server" Text="Programing" />
            </div>
            <div>
                <asp:CheckBox ID="cbOther" class="opt other"  runat="server" Text="Other" />
                <div id="other_value">
                    <asp:TextBox ID="txtOther" runat="server" placeholder="Please be specifc..."></asp:TextBox>
                </div>
            </div>
               
        </asp:Panel>
    </div>
    
    <div class="search_input">
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Search ..."></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>

    <div class="account">
        <%if (Session["userId"] == null){ %>
                <a class="lnk">Register</a>
                <a class="lnk">Sign In</a>
        <%}else{ %>
        <asp:HyperLink ID="linkAdmin" cssClass="lnk smallFont" runat="server" Visible="True"><i class="fas fa-user-cog"></i> ADMIN</asp:HyperLink>
        <a class="lnk smallFont"><i class="far fa-edit"></i> NEW</a>
        <div class="profile">
            <label id="profileToggle">Poyocat</label>
            <div id="account_opts">
                <div>
                    <a class="lnk" href="<%= $"/users/{Session["userId"]}/" %>"><i class="fas fa-user"></i> Profile</a>
                    <a class="lnk" href="<%= $"/users/{Session["userId"]}/bookmarks/" %>"><i class="fas fa-bookmark"></i> Bookmarks</a>
                    <a class="lnk" href="<%= $"/users/{Session["userId"]}/posts/" %>"><i class="fas fa-file"></i> My posts</a>
                <hr />
                    <asp:HyperLink ID="lnkLogout" runat="server" class="lnk" NavigateUrl="~/UserPage/LogoutPage.aspx"><i class="fas fa-sign-out-alt"></i> Logout</asp:HyperLink>
                </div>
            </div>
        </div>
        <%} %>
    </div>
</div>

<script type="text/javascript">
    $("#filter_toggle").on("click", e => {
        if ($(".filter_panel").css("display") == "block") {
            $(".filter_panel").css("display", "none");
        } else {
            $(".filter_panel").css("display", "block");
        }
    })

    $(".cbAll input").change(e => {
        if ($(".cbAll input").prop("checked")) {
            $(".opt input").prop("checked", false);
        }
    })
    $(".opt input").change(e => {
        if ($(".cbAll input").prop("checked")) {
            $(".cbAll input").prop("checked", false);
        }
    })

    $(".other input[type='checkbox']").change(e => {
        if ($(".other input[type='checkbox']").prop("checked")) {
            console.log("check")
            $("#other_value").css("display", "block");
        } else {
            $("#other_value").css("display", "none")
        }
    })
    $("#profileToggle").click(e => {
        if ($("#account_opts").css("display") == "block") {
            $("#account_opts").css("display","none");
        } else{
            $("#account_opts").css("display","block");
        }
    })
</script>