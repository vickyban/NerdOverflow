<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UserPageMaster.Master" AutoEventWireup="true" CodeBehind="PostHistoryPage.aspx.cs" Inherits="Forum.UserPage.PostHistoryPage" MaintainScrollPositionOnPostback="True" %>
<%@ MasterType VirtualPath="~/UserPage/UserPageMaster.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="display_opts">
        <div class="sort border_right">
            <label>Sort</label>
            <asp:DropDownList ID="sortOpt" runat="server">
                <asp:ListItem Selected="True">New</asp:ListItem>
                <asp:ListItem>Old</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="filter">
            <label id="filter">Filter</label>
            <div class="filter_box" id="filter_box">
                <div class="filter_opts" id="">
                    <div>
                        <asp:CheckBox ID="cbReview" runat="server" Text="In Review" Checked="True" />
                    </div>
                    <div>
                        <asp:CheckBox ID="cbPublic" runat="server" Text="Public" Checked="True" />
                    </div>
                 </div>
            </div>
        </div>
        <div class="display_btn">
            <asp:Button ID="btnFilter" runat="server" Text="Apply" OnClick="btnFilter_Click" />
        </div>
    </div>
    
    <div class="posts scrollbar">
           <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>

    <script type="text/javascript">
        document.getElementById("filter").addEventListener('click', () => {
            let opts = document.getElementById("filter_box");
            if (opts.style.display == "block") {
                opts.style.display = "none";
            } else {
                opts.style.display = "block";
            }
        })
        document.getElementById("filter_box").addEventListener('mouseleave', (e) => {
            if (e.target.style.display == "block")
                e.target.style.display = "none";
        })
    </script>
</asp:Content>
