<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sms.aspx.cs" Inherits="IDS.sms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="description" content="author:udit agrawal" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
<link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />   
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
<script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <title>SMS</title>
    <style>
        body {
    background-color : whitesmoke;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div><br /><br />
        <div class="container">
            <div class="row">
                <div class="col-md-offset-4 col-md-1"><asp:Button ID="Button1" runat="server" Text="Contact List" CssClass="btn btn-primary" Enabled="true" OnClick="Button1_Click" /></div>
         &nbsp;&nbsp;<div class="col-md-offset-1 col-md-1"><asp:Button ID="Button2" runat="server" Text="Sent Messages list" CssClass="btn btn-default" Enabled="true" OnClick="Button2_Click" /></div>
            </div>
     <br /><br />
            <div class="row">
                <div class="col-md-offset-3 col-md-6 text-center">
                <table class="table table-condensed table-bordered table-responsive lead">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </table>
                    </div>
            </div>
        
            </div>
    </div>
    </form>
</body>
</html>
