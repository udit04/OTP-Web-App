<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="IDS.info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />   
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

    <title>Contact Info</title>
     <style>
        body {
    background-color : lightslategrey;
}
    </style>
    <script>
        function validate() {
            var temp = document.getElementById("<%=txtOtp.ClientID %>");
            otp = temp.value;           
            if (otp == "") {
                alert("Please Enter OTP");
                temp.focus;
                return false;
            }
            else if(otp.length < 6)
            {
                alert("Please Enter a 6 digit OTP");
                return false;
            }
            else
                return true;
        }

        function CheckLength(currentValue)
        {
            var temp = document.getElementById("<%=txtOtp.ClientID %>");
            if (currentValue.length > 6) {
                temp.value = temp.value.substring(0, 6);
                alert("Only 6 digit otp is allowed");
                
            }
        }

    </script>
</head>
    
<body >
    <form id="form1" runat="server">
    <div class="container">
        <div class="row text-center" style="margin-top:20%" >
            <div class="col-md-offset-4 col-md-4" >
                <div class="panel panel-primary" >
                    <div class="panel-heading">Contact Info</div>
                    <div class="panel-body">
                       <label>Name:&nbsp;&nbsp;</label><span style="font-weight:bolder;font-size:x-large"><asp:PlaceHolder ID="namePlc" runat="server"></asp:PlaceHolder></span><br />
                           <label>Contact No:&nbsp;&nbsp; </label><span style="font-weight:bolder;font-size:x-large"><asp:PlaceHolder ID="contactPlc" runat="server"></asp:PlaceHolder></span><br />
                        <br /><button type="button" class="btn btn-primary btn-md" data-toggle="modal" data-target="#myModal">Send Message</button>          
                    </div>
                     <div class="panel-footer">
                         <a href="sms.aspx" class="btn btn-link">Home</a>
                     </div>
                </div>
            </div>
        </div>
    </div>

        <!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Message</h4>
      </div>
      <div class="modal-body">
          <label>OTP: </label>&nbsp;&nbsp;<asp:TextBox ID="txtOtp" runat="server" MaxLength="6" onkeyup="CheckLength(this.value);" CausesValidation="true" TextMode="Number"></asp:TextBox><br /><br />
          <asp:Button ID="btnSend" runat="server" CssClass="btn btn-success" Text="Send" OnClick="btnSend_Click" OnClientClick="javascript:return validate()" />
          <asp:Label ID="msgStatus" runat="server" Text=""></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>
         <!-- Modal -->
    </form>
</body>
</html>
