<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UserPageMaster.Master" AutoEventWireup="true" CodeBehind="PostHistoryPage.aspx.cs" Inherits="Forum.UserPage.PostHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="posts scrollbar">
           <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div> 
</asp:Content>
