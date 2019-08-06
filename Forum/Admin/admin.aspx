<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Forum.admin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            margin-left: 40px;
        }
        .auto-style3 {
            width: 857px;
            height: 242px;
            margin-right: 101;
        }
        .auto-style6 {
            width: 466px;
        }
        .auto-style8 {
            width: 184px;
            height: 38px;
        }
        .auto-style9 {
            height: 38px;
        }
        .auto-style10 {
            width: 184px;
        }
        .auto-style11 {
            width: 236px;
        }
        .auto-style12 {
            width: 236px;
            height: 38px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <!-- Page Wrapper -->
  <div id="wrapper">

    <!-- Sidebar -->
    <ul class="navbar-nav sidebar sidebar-dark accordion" id="accordionSidebar" style="background-color:#4e73df">

      <!-- Sidebar - Brand -->
      <a class="sidebar-brand d-flex align-items-center justify-content-center" href="#">
        <div class="sidebar-brand-icon">
          <i class="fas fa-user-shield"></i>
        </div>
        <div class="sidebar-brand-text mx-3">Admin </div>
      </a>

      <!-- Divider -->
      <hr class="sidebar-divider my-0">

      <!-- Nav Item - Dashboard -->
      <li class="nav-item active">
        <a class="nav-link" href="admin.aspx">
          <i class="glyphicon glyphicon-exclamation-sign"></i>
          <span>Dashboard</span></a>
      </li>

    

      <!-- Divider -->
      <hr class="sidebar-divider">

      <!-- Heading -->
      <div class="sidebar-heading">
        Addons
      </div>

      <!-- Nav Item - Charts -->
      <li class="nav-item">
        <a class="nav-link">
          <span> <i class="fas fa-users fa-2x"></i><asp:Button ID="btnViewUser" runat="server" Text="View All Account" class="navButton" OnClick="btnViewUser_Click"/></span></a>
      </li>

      <!-- Nav Item - Tables -->
      <li class="nav-item">
        <a class="nav-link">
          <span>  <i class="fas fa-comments fa-2x"></i><asp:Button ID="btnViewPost" runat="server" Text="View All Post" class="navButton" OnClick="btnViewPost_Click"/></span></a>
      </li>

    <li class="nav-item">
        <a class="nav-link">
          <span>  <i class="fas fa-ban fa-2x"></i><asp:Button ID="btnBanUser" runat="server" Text="User Banned" class="navButton" OnClick="btnBanUser_Click"/></span></a>
      </li>

      <!-- Divider -->
      <hr class="sidebar-divider d-none d-md-block">



    </ul>
    <!-- End of Sidebar -->

    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">

      <!-- Main Content -->
      <div id="content">

        <!-- Topbar -->
        <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

          <!-- Sidebar Toggle (Topbar) -->
          <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
            <i class="fa fa-bars"></i>
          </button>

          <!-- Topbar Search -->
          <form class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
            <div class="input-group">
              <input type="text" class="form-control bg-light border-0 small" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">
              <div class="input-group-append">
                <button class="btn btn-primary" type="button">
                  <i class="fas fa-search fa-sm"></i>
                </button>
              </div>
            </div>
          </form>

          <!-- Topbar Navbar -->
          <ul class="navbar-nav ml-auto">

            <!-- Nav Item - Search Dropdown (Visible Only XS) -->
            <li class="nav-item dropdown no-arrow d-sm-none">
              <a class="nav-link dropdown-toggle" href="#" id="searchDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <i class="fas fa-search fa-fw"></i>
              </a>
              <!-- Dropdown - Messages -->
              <div class="dropdown-menu dropdown-menu-right p-3 shadow animated--grow-in" aria-labelledby="searchDropdown">
                <form class="form-inline mr-auto w-100 navbar-search">
                  <div class="input-group">
                    <input type="text" class="form-control bg-light border-0 small" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">
                    <div class="input-group-append">
                      <button class="btn btn-primary" type="button">
                        <i class="fas fa-search fa-sm"></i>
                      </button>
                    </div>
                  </div>
                </form>
              </div>
            </li>



          

            <!-- Nav Item - User Information -->
            <li class="nav-item dropdown no-arrow">
              <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <span class="mr-2 d-none d-lg-inline text-gray-600 small">Jason Liu</span>
                <img class="img-profile rounded-circle" src="https://icon-library.net//images/icon-user/icon-user-6.jpg" width="5%">
              </a>
              <!-- Dropdown - User Information -->
              <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
                <a class="dropdown-item" href="#">
                  <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>
                  Profile
                </a>
                <a class="dropdown-item" href="#">
                  <i class="fas fa-cogs fa-sm fa-fw mr-2 text-gray-400"></i>
                  Settings
                </a>
                <a class="dropdown-item" href="#">
                  <i class="fas fa-list fa-sm fa-fw mr-2 text-gray-400"></i>
                  Activity Log
                </a>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item" href="#" data-toggle="modal" data-target="#logoutModal">
                  <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                  Logout
                </a>
              </div>
            </li>

          </ul>

        </nav>
        <!-- End of Topbar -->

          


<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <!-- Begin Page Content -->
        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>
            <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-download fa-sm text-white-50"></i> Generate Report</a>
          </div>

          <!-- Content Row -->
          <div class="row">



              <div class="col-xl-3 col-md-6 mb-4">
              <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-xs font-weight-bold text-info text-uppercase mb-1">Post checked</div>
                      <div class="row no-gutters align-items-center">
                        <div class="col-auto">
                          <div class="h5 mb-0 mr-3 font-weight-bold text-gray-800">
                              <asp:Label ID="lblPostStatus" runat="server"></asp:Label></div>
                        </div>
                        <div class="col">
                          <div class="progress progress-sm mr-2">
                            <div id= "progressbar" class="progress-bar bg-info" role="progressbar"  aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" runat="server"></div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>


            <div class="col-xl-3 col-md-6 mb-4">
              <div class="card border-left-danger shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-xs font-weight-bold text-primary text-uppercase mb-1"> User Banned</div>
                      <div class="h5 mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="lblBan" runat="server" Text=""></asp:Label></div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-ban fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
              <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Total User</div>
                      <div class="h5 mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="lblTotalUser1" runat="server"></asp:Label></div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-users fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            

            <div class="col-xl-3 col-md-6 mb-4">
              <div class="card border-left-warning shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Total Post</div>
                      <div class="h5 mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="lblTotalPost" runat="server"></asp:Label></div>
                    </div>
                    <div class="col-auto">
                      <i class="fas fa-comments fa-2x text-gray-300"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>


          <!-- Content Row -->
          <div class="row">

            <!-- Content Column -->
            <div class="col-lg-6 mb-4">

              <!-- Project Card Example -->
              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Status</h6>
                </div>
                <div class="card-body">
                  <h4 class="small font-weight-bold"> Bio <span class="float-right">20%</span></h4>
                  <div class="progress mb-4">
                    <div id="bio" class="progress-bar bg-danger" role="progressbar"  aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" runat="server"></div>
                  </div>
                  <h4  class="small font-weight-bold"> Chem <span class="float-right">40%</span></h4>
                  <div class="progress mb-4">
                    <div id="chem" class="progress-bar bg-warning" role="progressbar" style="width: 40%" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" runat="server"></div>
                  </div>
                  <h4  class="small font-weight-bold"> Math <span class="float-right">60%</span></h4>
                  <div class="progress mb-4">
                    <div id="math" class="progress-bar" role="progressbar" style="width: 60%" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" runat="server"></div>
                  </div>
                  <h4  class="small font-weight-bold"> Geo <span class="float-right">80%</span></h4>
                  <div class="progress mb-4">
                    <div id="geo" class="progress-bar bg-info" role="progressbar" style="width: 80%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" runat="server"></div>
                  </div>
                  <h4  class="small font-weight-bold"> Physic <span class="float-right">100%</span></h4>
                  <div class="progress">
                    <div id="physic" class="progress-bar bg-success" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" runat="server"></div>
                  </div>
                    <br />
                  <h4  class="small font-weight-bold"> Programming <span class="float-right">100%</span></h4>
                  <div class="progress">
                    <div id="programming" class="progress-bar bg-dark" role="progressbar" style="width: 100%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" runat="server"></div>
                  </div>
                </div>
              </div>


            </div>

            <div class="col-lg-6 mb-4">

              <!-- Illustrations -->
              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Illustrations</h6>
                </div>
                <div class="card-body">
                  <div class="text-center">
                    <img class="img-fluid px-3 px-sm-4 mt-3 mb-4" style="width: 25rem;" src="https://i2.wp.com/inquisiostudios.com/wp-content/uploads/2019/03/screens.png?w=1050&ssl=1" alt="">
                  </div>
  
                </div>
              </div>


            </div>
          </div>

        </div>
        <!-- /.container-fluid -->
        </asp:View>

    <asp:View ID="AccountView" runat="server">


        <table class="auto-style1" style="margin-left:20px;">
            <tr>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="user_id" DataSourceID="SqlDataSourceUserInfo" ForeColor="#333333" GridLines="None" AllowSorting="True" OnRowDataBound="GridView2_RowDataBound" AllowPaging="True" PageSize="12">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="user_id" HeaderText="User Id" InsertVisible="False" ReadOnly="True" SortExpression="user_id" />
                            <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" />
                            <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                            <asp:CheckBoxField DataField="isAdmin" HeaderText="Admin" SortExpression="isAdmin" />
                            <asp:BoundField DataField="created_at" HeaderText="Created_at" SortExpression="created_at" />
                            <asp:BoundField DataField="updated_at" HeaderText="Updated_at" SortExpression="updated_at" />
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/delete.png" ShowDeleteButton="True" ControlStyle-Height="30px" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceUserInfo" runat="server" ConnectionString="<%$ ConnectionStrings:ForumConnectionString %>" SelectCommand="SELECT [user_id], [username], [password], [isAdmin], [created_at], [updated_at] FROM [User]" DeleteCommand="DELETE FROM [User] WHERE [user_id] = @user_id" InsertCommand="INSERT INTO [User] ([username], [password], [isAdmin], [created_at], [updated_at]) VALUES (@username, @password, @isAdmin, @created_at, @updated_at)" UpdateCommand="UPDATE [User] SET [username] = @username, [password] = @password, [isAdmin] = @isAdmin, [created_at] = @created_at, [updated_at] = @updated_at WHERE [user_id] = @user_id">
                        <DeleteParameters>
                            <asp:Parameter Name="user_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="username" Type="String" />
                            <asp:Parameter Name="password" Type="String" />
                            <asp:Parameter Name="isAdmin" Type="Boolean" />
                            <asp:Parameter Name="created_at" Type="DateTime" />
                            <asp:Parameter Name="updated_at" Type="DateTime" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="username" Type="String" />
                            <asp:Parameter Name="password" Type="String" />
                            <asp:Parameter Name="isAdmin" Type="Boolean" />
                            <asp:Parameter Name="created_at" Type="DateTime" />
                            <asp:Parameter Name="updated_at" Type="DateTime" />
                            <asp:Parameter Name="user_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>

        </table>



    </asp:View>
    <asp:View ID="PostView" runat="server">
        <table class="auto-style1" style="margin-left:20px;">
            <tr>
                <td class="auto-style2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="post_id" DataSourceID="SqlDataSourcePostinfo" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" PageSize="12">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="post_id" HeaderText="Post Id" InsertVisible="False" ReadOnly="True" SortExpression="post_id" />
                            <asp:BoundField DataField="user_id" HeaderText="User Id" SortExpression="user_id" />
                            <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                            <asp:BoundField DataField="content" HeaderText="Content" SortExpression="content" Visible="False" />
                            <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                            <asp:BoundField DataField="created_at" HeaderText="Created at" SortExpression="created_at" />
                            <asp:BoundField DataField="updated_at" HeaderText="Updated at" SortExpression="updated_at" />
                            <asp:ButtonField HeaderText="Content" Text="Details" CommandName="postDetails" />
                            <asp:CommandField ButtonType="Image" ControlStyle-Height="30px" DeleteImageUrl="~/Images/delete.png" ShowDeleteButton="True">
                            <ControlStyle Height="30px" />
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourcePostinfo" runat="server" ConnectionString="<%$ ConnectionStrings:ForumConnectionString %>" DeleteCommand="DELETE FROM [Post] WHERE [post_id] = @post_id" InsertCommand="INSERT INTO [Post] ([user_id], [title], [content], [category], [status], [created_at], [updated_at]) VALUES (@user_id, @title, @content, @category, @status, @created_at, @updated_at)" SelectCommand="SELECT * FROM [Post]" UpdateCommand="UPDATE [Post] SET [user_id] = @user_id, [title] = @title, [content] = @content, [category] = @category, [status] = @status, [created_at] = @created_at, [updated_at] = @updated_at WHERE [post_id] = @post_id">
                        <DeleteParameters>
                            <asp:Parameter Name="post_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="user_id" Type="Int32" />
                            <asp:Parameter Name="title" Type="String" />
                            <asp:Parameter Name="content" Type="String" />
                            <asp:Parameter Name="category" Type="String" />
                            <asp:Parameter Name="status" Type="String" />
                            <asp:Parameter Name="created_at" Type="DateTime" />
                            <asp:Parameter Name="updated_at" Type="DateTime" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="user_id" Type="Int32" />
                            <asp:Parameter Name="title" Type="String" />
                            <asp:Parameter Name="content" Type="String" />
                            <asp:Parameter Name="category" Type="String" />
                            <asp:Parameter Name="status" Type="String" />
                            <asp:Parameter Name="created_at" Type="DateTime" />
                            <asp:Parameter Name="updated_at" Type="DateTime" />
                            <asp:Parameter Name="post_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="PostDetailsView" runat="server">
        


            <table class="auto-style1" style="margin-left:20px;">
                            <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label2" runat="server" Text="Post details" Font-Bold="True" Font-Size="X-Large" ForeColor="Black"></asp:Label></td>
            </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label1" runat="server" Text="User ID" ForeColor="Black" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:Label ID="lblUserID" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style10">
                                <asp:Label ID="Label3" runat="server" Text="Title" ForeColor="Black" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style10">
                                <asp:Label ID="Label4" runat="server" Text="Category" ForeColor="Black" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style10">
                                <asp:Label ID="Label5" runat="server" Text="Status" ForeColor="Black" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
       
            </table>
        <br />
           <table class="auto-style1" style="margin-left:20px;">
            <tr>
                <td class="auto-style6">
                    <textarea ID="details" runat="server" aria-disabled="True" class="auto-style3" disabled="disabled" style="font-family: Arial; font-size: 24px; font-weight: 500; font-style: normal; clip: rect(auto, auto, 5px, auto);"></textarea>    
                </td>
            
            </tr>
        
            <tr>
                <td class="auto-style6">  
                    <asp:Button ID="btnBack" runat="server" Text="< Back" class="btn btn-outline-dark" OnClick="btnBack_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBanUser1" runat="server" Text="Ban User" class="btn btn-outline-danger" OnClick="btnBanUser1_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnApprove1" runat="server" Text="Approve" class="btn btn-outline-success" OnClick="btnApprove1_Click"/>
                </td>
                
            </tr>
        </table>

    </asp:View>
    <asp:View ID="banUserView" runat="server">
        
        <table class="auto-style1">
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label7" runat="server" Text="User ID: "></asp:Label>

                </td>
                <td class="auto-style9">
                    <asp:Label ID="lblUserIdBan" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label8" runat="server" Text="Current Status"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCurrentStatus" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label9" runat="server" Text="Ban Start Date: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStartDate" runat="server" Enabled="False" ></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSelect" runat="server" Text="Select" class="btn btn-primary" OnClick="btnSelect_Click" />
                    &nbsp;&nbsp;<br />
                   
                </td>
                
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar1_SelectionChanged" Width="350px" Visible="False">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label10" runat="server" Text="Ban End Date: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndDate" runat="server" Enabled="False" ></asp:TextBox>
                   &nbsp;&nbsp;&nbsp;<asp:Button ID="btnselectEndDate" runat="server" Text="Select" class="btn btn-primary" OnClick="btnselectEndDate_Click" />
                    &nbsp;&nbsp;<br />

                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                        <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" Visible="False" OnSelectionChanged="Calendar2_SelectionChanged">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnConfirmBan" runat="server" Text="Confirm" class="btn btn-outline-danger" OnClick="btnConfirmBan_Click" />

                </td>
            </tr>
        </table>
        
    </asp:View>


    <asp:View ID="NavBanView" runat="server">
        
        <table class="auto-style1" style="margin-left:20px">
            <asp:Label ID="Label6" runat="server" Text="User Banned" Font-Size="XX-Large"></asp:Label>
            <tr>
                <td>&nbsp;
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ban_id" DataSourceID="SqlDataSourceBan" ForeColor="#333333" GridLines="None" AllowSorting="True" OnRowCommand="GridView3_RowCommand" AllowPaging="True" PageSize="12">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ban_id" HeaderText="Ban Id" InsertVisible="False" ReadOnly="True" SortExpression="ban_id" />
                            <asp:BoundField DataField="user_id" HeaderText="User Id" SortExpression="user_id" />
                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                            <asp:BoundField DataField="start_date" HeaderText="Start Date" SortExpression="start_date" />
                            <asp:BoundField DataField="end_date" HeaderText="End Date" SortExpression="end_date" />
                            <asp:BoundField DataField="created_at" HeaderText="Created at" SortExpression="created_at" />
                            <asp:ButtonField ButtonType="Image" Text="" ControlStyle-Height="30px" HeaderText="Unban" ImageUrl="~/Images/unban.png" ControlStyle-Width="30px" CommandName="Unbanned">
                            <ControlStyle Height="20px" />
                            </asp:ButtonField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceBan" runat="server" ConnectionString="<%$ ConnectionStrings:ForumConnectionString %>" DeleteCommand="DELETE FROM [Ban] WHERE [ban_id] = @ban_id" InsertCommand="INSERT INTO [Ban] ([user_id], [status], [start_date], [end_date], [created_at]) VALUES (@user_id, @status, @start_date, @end_date, @created_at)" SelectCommand="SELECT * FROM [Ban]" UpdateCommand="UPDATE [Ban] SET [user_id] = @user_id, [status] = @status, [start_date] = @start_date, [end_date] = @end_date, [created_at] = @created_at WHERE [ban_id] = @ban_id">
                        <DeleteParameters>
                            <asp:Parameter Name="ban_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="user_id" Type="Int32" />
                            <asp:Parameter Name="status" Type="String" />
                            <asp:Parameter Name="start_date" Type="DateTime" />
                            <asp:Parameter Name="end_date" Type="DateTime" />
                            <asp:Parameter Name="created_at" Type="DateTime" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="user_id" Type="Int32" />
                            <asp:Parameter Name="status" Type="String" />
                            <asp:Parameter Name="start_date" Type="DateTime" />
                            <asp:Parameter Name="end_date" Type="DateTime" />
                            <asp:Parameter Name="created_at" Type="DateTime" />
                            <asp:Parameter Name="ban_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:View>



</asp:MultiView>
      </div>
      <!-- End of Main Content -->

      <!-- Footer -->
      <footer class="sticky-footer bg-white">
        <div class="container my-auto">
          <div class="copyright text-center my-auto">
            <span>Copyright &copy;  2019</span>
          </div>
        </div>
      </footer>
      <!-- End of Footer -->

    </div>
    <!-- End of Content Wrapper -->

  </div>
  <!-- End of Page Wrapper -->

  <!-- Scroll to Top Button-->
  <a class="scroll-to-top rounded" href="#page-top">
    <i class="fas fa-angle-up"></i>
  </a>

  <!-- Logout Modal-->
  <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
        <div class="modal-footer">
          <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
          <a class="btn btn-primary" href="login.html">Logout</a>
        </div>
      </div>
    </div>
  </div>
    <asp:HiddenField ID="Categorybio" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
</asp:Content>
