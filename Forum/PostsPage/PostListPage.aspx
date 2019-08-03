<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostListPage.aspx.cs" Inherits="Forum.PostsPage.PostListPage" %>

<%@ Register Src="~/UserControl/PostPreviewWithActions.ascx" TagPrefix="uc1" TagName="PostPreviewWithActions" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Styles/style.css" rel="stylesheet" />
    <link href="../Styles/userPage.css" rel="stylesheet" />
    <link href="../css/all.min.css" rel="stylesheet" />
    <link href="../css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link href="../css/all.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../lib/font-awesome/css/all.css" />
   
    <link href="../Styles/style.css" rel="stylesheet" />
    <link href="../Styles/postPreview.css" rel="stylesheet" />

    <link rel="stylesheet/less" type="text/css" href="../Styles/postListStyle_less.less" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/less.js/3.9.0/less.min.js" ></script>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
   
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="search_bar">
            <div class="sortBy">
                <label class="smallFont">SORT</label>
                <asp:DropDownList ID="dlistSortBy" runat="server">
                    <asp:ListItem Value="DESC">Newest</asp:ListItem>
                    <asp:ListItem Value="ASCE">Oldest</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="filter"> 
                <label id="filter_toggle" class="lnk smallFont">FILTER <i class="fas fa-ellipsis-v"></i></label>
            
                <asp:Panel ID="panelCatrgories" runat="server">
                    <div>
                        <label>Category</label>
                    </div>
                    <div>
                    <asp:CheckBox ID="cbAll" CssClass="all" runat="server" Text="All" Checked="True" />
                    </div>
                    <div>
                        <asp:CheckBox ID="cbMath" CssClass="opt" runat="server" Text="Maths" />
                    </div>
                    <div>
                        <asp:CheckBox ID="cbBio" CssClass="opt"  runat="server" Text="Bio" />
                    </div>
                    <div>
                         <asp:CheckBox ID="cbPhysic" CssClass="opt"  runat="server" Text="Physic" />
                    </div>
                    <div>
                         <asp:CheckBox ID="cbChem" CssClass="opt"  runat="server" Text="Chemistry" />
                    </div>       
                    <div>
                        <asp:CheckBox ID="cbHistory" CssClass="opt"  runat="server" Text="History" />
                    </div>
                    <div>
                         <asp:CheckBox ID="cbProgram" CssClass="opt"  runat="server" Text="Programing" />
                    </div>
                   <div>
                        <asp:CheckBox ID="cbOther" CssClass="opt other"  runat="server" Text="Other" />
                        <div id="other_value">
                            <asp:TextBox ID="txtOther" runat="server" placeholder="Please be specifc..."></asp:TextBox>
                        </div>
                   </div>
               
                </asp:Panel>
            </div>
    
            <div class="search_input">
                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search ..."></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" />
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
                         <a class="lnk"><i class="fas fa-user"></i> Profile</a>
                         <a class="lnk"><i class="fas fa-bookmark"></i> Bookmarks</a>
                         <a class="lnk"><i class="fas fa-file"></i> My posts</a>
                        <hr />
                         <asp:HyperLink ID="lnkLogout" runat="server" class="lnk"><i class="fas fa-sign-out-alt"></i> Logout</asp:HyperLink>
                        </div>
                    </div>
                </div>
                <%} %>
            </div>
        </div>

       <div class="content">
           <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
       </div>
    
    
    </form>



    <script type="text/javascript">
        $("#filter_toggle").on("click", e => {
            if ($("#panelCatrgories").css("display") == "block") {
                $("#panelCatrgories").css("display", "none");
            } else {
                $("#panelCatrgories").css("display", "block");
            }
        })

        $("#cbAll").change(e => {
            if ($("#cbAll").prop("checked")) {
                $(".opt input").prop("checked", false);
            }
        })
        $(".opt").change(e => {
            if ($("#cbAll").prop("checked")) {
                $("#cbAll").prop("checked", false);
            }
        })

        $("#cbOther").change(e => {
            if ($("#cbOther").prop("checked")) {
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
</body>
</html>
