<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="BulkEmailApp.Email" ValidateRequest="false"
 %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>VISHAL KHACHANE</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script src="https://cdn.ckeditor.com/4.16.1/standard/ckeditor.js"></script>
  <style>
    /* Remove the navbar's default margin-bottom and rounded borders */ 
    .navbar {
      margin-bottom: 0;
      border-radius: 0;
    }
    
    /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
    .row.content 
    {
       
        height: 550px;
        background-color: seashell

    }
    
    /* Set gray background color and 100% height */
    .sidenav {
      padding-top: 20px;
      background-color: #f1f1f1;
      height: 100%;
    }
    
    /* Set black background color, white text and some padding */
    footer {
      background-color: #555;
      color: white;
      padding: 15px;
    }
    
    td, th {
  border: 1px solid #999;
  padding: 0.5rem;
}
    
    /* On small screens, set height to 'auto' for sidenav and grid */
    @media screen and (max-width: 767px) {
      .sidenav {
        height: auto;
        padding: 15px;
      }
      .row.content {height:auto;} 
    }
  </style>
</head>
<body >
    <form id="form1" runat="server" >
    <div>
    
        
        <asp:content>
	<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" href="#">VISHAL</a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
        <li class="active"><a href="#">Home</a></li>
         <li><a href="#">ShowCandidates</a></li>
        <li><a href="#">About</a></li>
       
      </ul>
      </div>
  </div>
</nav>
  
<div class="container-fluid text-center" style="margin-top:22px;" >    
  <div class="row content">
    <div class="col-sm-2 sidenav" >
        
       
 
    </div>
    <div class="col-sm-8"> 
        <div class="table-responsive-sm">
        <table class="table table-sm" style="border:2px; background-color:burlywood;">
            
            <tr class="bg-info color-red">
                 <td colspan="2" >
                    <asp:Label ID="lblheading" Font-Bold="true" runat="server" Text="Send Multiple Email With Attachment" Font-Size="Larger"></asp:Label>

                </td>
            </tr>

            <tr>
                
               <td>
                    <asp:Label ID="Label4" runat="server" Style="font-weight: 700" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
             <tr>
                
               <td>
                    <asp:Label ID="Label7" runat="server" Style="font-weight: 700" Text="SMTP Host:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                
               <td>
                    <asp:Label ID="Label8" runat="server" Style="font-weight: 700" Text="Port No.::"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
            
            
            <tr>
                
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Email Address Select Excel File" Style="font-weight: 700"></asp:Label>
                    
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" style="background-color:darkgoldenrod;"/><br />
                    <asp:Button ID="Button2" runat="server" Text="Show all the Members" OnClick="king_Click" class="btn btn-info"/>
                </td>
            </tr>
          
            <tr>
                
               <td>
                    <asp:Label ID="Label3" runat="server" Style="font-weight: 700" Text="Subject"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txt_Subject" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                
                <td>
                    <asp:Label ID="Label6" runat="server" Style="font-weight: 700" Text="Email Body Content"></asp:Label>
                </td>
                <td>

                    <asp:TextBox ID="Txt_Bodycontent" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
               
                <td>
                    <asp:Label ID="fuAttachment" runat="server" Style="font-weight: 700" Text="Attach a file"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" class="form-control" style="background-color:darkgoldenrod;"/>
                </td>
            </tr>



            <tr>
                
               <td>
                    <asp:Label ID="Label5" runat="server" Style="font-weight: 700" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" TextMode="Password" runat="server" class="form-control"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                
                <td colspan="2">
                   <asp:Button ID="Button3" runat="server" Text="Show all the Members" OnClick="king_Click" class="btn btn-info"/>
                    <asp:Button ID="Sendbtn" runat="server" Text="Send Email" OnClick="Sendbtn_Click" class="btn btn-primary" />
                    <asp:Label ID="cnfrm" runat="server" class="label label-success"></asp:Label>    
                </td>

            </tr>
            

           
        </table>
   
        
       
        
        
         

         
        
        <div>
            <p>Click on Show all Members and Check All Email Address and Total Count if correct then Click on Send Email Button To Send Mail To All.</p>
        </div><br />
           
         
             
            
            <br />
          
        <asp:Label ID="kinglbl" runat="server" Text="Total Members: "></asp:Label>
        <asp:Label ID="Label2" runat="server" Text=" " Style="font-weight: 700"></asp:Label> 
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView><br /><br />
<div style="margin-bottom:100px;">
    <asp:Button ID="Button1" runat="server" Text="Send Email" OnClick="Sendbtn_Click" class="btn btn-primary"  /> 
</div>
        
        
        

</div>
    </div>
  </div>
</div>

<footer class="container-fluid text-center">
  <!-- Copyright -->
  <div class="footer-copyright text-center py-3">© 2021 Created By:
    <a href="#"> VISHAL KHACHANE</a>
  </div>
  <!-- Copyright -->
</footer>
</asp:content>
    </div>
    </form>

    <script>
        CKEDITOR.replace( 'Txt_Bodycontent' );
    </script>
</body>

</html>
