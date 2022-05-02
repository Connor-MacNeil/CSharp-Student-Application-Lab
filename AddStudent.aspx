<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
    <link rel="stylesheet" href="App_Themes\SiteStyles.css"/>
    <meta name="author" content="Connor MacNeil"/>
    <meta name="email" content="macn0180@algonquinlive.com"/>
    <title>Add Student</title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <h1>Students</h1>

            <div class="row">

                <div class="col-md-2">
                    <asp:label ID="nameLbl" runat="server" Text="Student Name: "></asp:label>   
                </div>

                <div class="col-md-2">
                    <asp:TextBox ID="StudentName" runat="server" CssClass="input" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Required Field" InitialValue=""
                        ControlToValidate="StudentName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="p-2"></div> 
            </div>

            <div class="row">
                <div class="col-md-2">
                    <asp:label ID="TypeLbl" runat="server" Text="Student Type: "></asp:label>
                </div>

                <div class="col-md-2">
                    <asp:DropDownList ID="TypeDropDownList" runat="server" CssClass="input" class="form-control">
                        <asp:ListItem Value="0">Select...</asp:ListItem>
                        <asp:ListItem Value="1">Full-Time</asp:ListItem>
                        <asp:ListItem Value="2">Part-Time</asp:ListItem>
                        <asp:ListItem Value="3">Co-op</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RangeValidator ID="rvType" runat="server" ControlToValidate="TypeDropDownList" 
                        ErrorMessage="You must select a student type"
                        InitialValue="0" MaximumValue="3" MinimumValue="1" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
                </div>
            </div>

            <div class="row">
                <asp:Table ID="table" runat="server" class="table"> 
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                        <asp:TableRow ID="warningRow" runat="server" Visible ="true">
                        <asp:TableCell ID="spacerCell" runat="server"></asp:TableCell>
                        <asp:TableCell ID="emptyWarning" runat="server" Style="color:red;">No Students Yet!</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>

            <div class="row">
                <asp:Button ID="AddButton" runat="server" CssClass="button" class="mt-3 btn btn-primary btn-lg" Text="Add" OnClick="AddButton_Click" />
            </div>

            <div class="row">
                <div class="p-2"></div> 
            </div>

            <div class="row">
                <asp:HyperLink id="linkToRegisterCourses" runat="server" NavigateUrl="~/RegisterCourse.aspx">Register Courses</asp:HyperLink>
            </div>
              
            </form>
        </div>
</body>
</html>
