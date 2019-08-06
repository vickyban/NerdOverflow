<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentExample.aspx.cs" Inherits="Forum.WebForm2" %>

<%@ Register Src="~/UserControl/CommentSection.ascx" TagPrefix="uc1" TagName="CommentSection" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link href="../css/all.min.css" rel="stylesheet">
  <link href="../css/sb-admin-2.min.css" rel="stylesheet">
  <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
  <link href="../css/all.min.css" rel="stylesheet" type="text/css">
  <link rel="stylesheet" href="../lib/font-awesome/css/all.css" />

    <link href="Styles/commentSection.css" rel="stylesheet" />

     <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
  
                <uc1:CommentSection runat="server" id="CommentSection" />
        
        </div>
    </form>
</body>
</html>
