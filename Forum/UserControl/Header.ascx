<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Forum.UserPage.Header" %>
<header>
    <a href="/">
        <img ID="imgLogo" runat="server" src="~/Images/logo.png" />
    </a>
</header>
<div class="search_bar">
    <form method="get" action="/posts/">
        <input id="sortValue" type="hidden" name="sort" value="DESC" />
    <div class="sortBy">
        <label class="smallFont">SORT</label>
        <select ID="dlistSortBy">
            <option value="DESC">Newest</option>
            <option value="ASC">Olderest</option>
        </select>
    </div>
    <div class="filter"> 
        <label id="filter_toggle" class="lnk smallFont">FILTER <i class="fas fa-ellipsis-v"></i></label>
            
        <div ID="panel1" class="filter_panel">
            <div>
                <label class="hightlight">Category</label>
            </div>
            <div>
                <input id="cbAll" type="checkbox"  name="filters" value="" class="cbAll all" checked="checked" />
                <label>All</label>
            </div>
            <div>
                <input id="cbMath" type="checkbox"  name="filters" value="maths" class="opt" />
                <label>Maths</label>
            </div>
            <div>
                <input id="cbBio" type="checkbox"  name="filters" value="bio" class="opt" />
                <label>Bio</label>
            </div>
            <div>
                <input id="cbPhysic" type="checkbox"  name="filters" value="physic" class="opt"/>
                <label>Physic</label>
            </div>
            <div>
                <input id="cbChem" type="checkbox"  name="filters" value="chemistry" class="opt"/>
                <label>Chemistry</label>
            </div>       
            <div>
                <input id="cbHistory" type="checkbox"  name="filters" value="history" class="opt"  />
                <label>History</label>
            </div>
            <div>
                <input id="cbProgram" type="checkbox"  name="filters" value="programming" class="opt"/>
                <label>Programing</label>
            </div>
            <div>
                <input id="cbOther" type="checkbox"  name="filters" value="" class="opt other" />
                <label>Other</label>
                <div id="other_value">
                    <input id="other_input" type="text" placeholder="Please be specifc..."/>
                </div>
            </div>
               
        </div>
    </div>
    
    <div class="search_input">
        <input type="text" id="txtSearch" name="keyword" placeholder="Search ..."/>
        <input type="submit" value="Search"/>
    </div>

    <div class="account">
        <%if (Session["userId"] == null){ %>
                <a class="lnk">Register</a>
                <a class="lnk">Sign In</a>
        <%}else{ %>
        <a ID="linkAdmin" class="lnk smallFont"><i class="fas fa-user-cog"></i> ADMIN</a>
        <a class="lnk smallFont" href="/posts/new"><i class="far fa-edit"></i> NEW</a>
        <div class="profile">
            <label id="profileToggle">Poyocat</label>
            <div id="account_opts">
                <div>
                    <a class="lnk" href="<%= $"/users/{Session["userId"]}/" %>"><i class="fas fa-user"></i> Profile</a>
                    <a class="lnk" href="<%= $"/users/{Session["userId"]}/bookmarks/" %>"><i class="fas fa-bookmark"></i> Bookmarks</a>
                    <a class="lnk" href="<%= $"/users/{Session["userId"]}/posts/" %>"><i class="fas fa-file"></i> My posts</a>
                <hr />
                    <a id="lnkLogout" class="lnk" href="/UserPage/LogoutPage.aspx"><i class="fas fa-sign-out-alt"></i> Logout</a>
                </div>
            </div>
        </div>
        <%} %>
    </div>

    </form>
</div>

<script type="text/javascript">

    $("#dlistSortBy").change(e => {
        $("#sortValue").val($("#dlistSortBy").val)
    })

    $("#filter_toggle").on("click", e => {
        if ($(".filter_panel").css("display") == "block") {
            $(".filter_panel").css("display", "none");
        } else {
            $(".filter_panel").css("display", "block");
        }
    })

    $("input.cbAll").change(e => {
        if ($(".cbAll").prop("checked")) {
            $(".opt").prop("checked", false);
        }
    })
    $("input.opt").change(e => {
        if ($(".cbAll").prop("checked")) {
            $(".cbAll").prop("checked", false);
        }
    })

    $(".other").change(e => {
        if ($(".other").prop("checked")) {
            console.log("check")
            $("#other_value").css("display", "block");
        } else {
            $("#other_value").css("display", "none")
        }
    })
    $("#profileToggle").click(e => {
        if ($("#account_opts").css("display") == "block") {
            $("#account_opts").css("display", "none");
        } else {
            $("#account_opts").css("display", "block");
        }
    })
    $("#other_input").change(e => {
        let value = $("#other_input").val();
        $("#cbOther").val(value);
    })

</script>
