<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
    <link rel="stylesheet" href="App_Themes\SiteStyles.css"/>
    <meta name="author" content="Connor MacNeil"/>
    <meta name="email" content="macn0180@algonquinlive.com"/>
    <title>Register Course</title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <h1>Registrations</h1>
            <div class="row">

                <div class="col-md-1">
                    <asp:Label ID="lblStudent" runat="server">Student:</asp:Label>
                </div>

                <div class="col-md-2">
                    <asp:DropDownList ID="studentDropDown" runat="server" OnSelectedIndexChanged="studentDropDown_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="">Select...</asp:ListItem>
                    </asp:DropDownList>

                     <asp:RequiredFieldValidator ID="rfvstudentDropDown" runat="server" 
                        ErrorMessage="Select a student!" ForeColor="Red" ControlToValidate="studentDropDown" InitialValue="0" Display="Dynamic">
                     </asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="row">
                <h3 id="registrationSummary" runat="server" style="color:blue;"></h3>
            </div>

            <div class="row">
                <h3 id="subTitle" runat="server" visible ="true" >The following courses are currently available for registration</h3>
            </div>

            <div class="row">
                <h3 id="errorMsg" runat="server" visible ="false" class="emphsis"></h3>
            </div>

            <div class="row">
                <asp:CheckBoxList ID="courseSelection" runat="server"></asp:CheckBoxList>
            </div>

            <div class="row">
                <div class="p-2"></div> 
            </div>

            <div class="row">
                <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="button" OnClick="saveButton_Click" />
            </div>

            <div class="row">
                <div class="p-2"></div> 
            </div>

            <div class="row">
                <asp:HyperLink id="linkToAddStudent" runat="server" NavigateUrl="~/AddStudent.aspx">Add Students</asp:HyperLink>
            </div>
        </form>
    </div>
</body>
</html>
