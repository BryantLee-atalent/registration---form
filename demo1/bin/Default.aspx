<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Head.Master" CodeBehind="Default.aspx.cs" Inherits="demo1.head" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <style type="text/css">
        .fieldLabel {
            color: #EE7621
        }

        .nameTextField {
            border-top: 0px solid;
            border-left: 0px solid;
            border-right: 0px solid;
            border-bottom: 1px solid;
            margin-top: 10px;
            margin-bottom: 10px;
            outline: none;
            margin-right: 12px;
        }

        .textField {
            border-top: 0px solid;
            border-left: 0px solid;
            border-right: 0px solid;
            border-bottom: 1px solid;
            margin-top: 10px;
            margin-bottom: 10px;
            outline: none;
        }

        .btnRegister {
            background-color: white;
            background-position: right center;
        }
    </style>
    <asp:Label runat="server" ForeColor="#FF6347" Text="Ready to learn how to Attract,Recruit & Retain Talent with WeChat?" Font-Size="XX-Large"></asp:Label>
    <div style="margin-top: 22px">
        <asp:Label runat="server" Text="Please fill in the following details to register for ther WeChat Recruitment 2.0 Seminar:" Font-Size="Large"></asp:Label>
    </div>
    <div>
        <div style="margin-top: 13px" runat="server">
            <asp:Label runat="server" CssClass="fieldLabel" Text="Name/姓名:" ID="name" Width="60%"></asp:Label><asp:Label runat="server" Text="Title/职位:" CssClass="fieldLabel" ID="title" Width="40%"></asp:Label><br />

            <asp:TextBox runat="server" CssClass="nameTextField" ID="nameText" Width="58%"></asp:TextBox><asp:DropDownList runat="server" ID="titleCombo" CssClass="textField" Width="40%">
                <asp:ListItem Text="HRD" Value="HRD"></asp:ListItem>
                <asp:ListItem Text="HRVP" Value="HRVP"></asp:ListItem>
                <asp:ListItem Text="Senior HR manager" Value="Senior HR manager"></asp:ListItem>
            </asp:DropDownList><br />

            <asp:Label runat="server" Text="Industry/行业:" CssClass="fieldLabel"></asp:Label><br />

            <asp:DropDownList runat="server" ID="industryCombo" CssClass="textField" Width="100%">
                <asp:ListItem Text="Automotive" Value="Automotive"></asp:ListItem>
                <asp:ListItem Text="Chemical" Value="Chemical"></asp:ListItem>
                <asp:ListItem Text="Consulting" Value="Consulting"></asp:ListItem>
                <asp:ListItem Text="Education" Value="Education"></asp:ListItem>
                <asp:ListItem Text="FMGG" Value="FMGG"></asp:ListItem>
                <asp:ListItem Text="Hospitality" Value="Hospitality"></asp:ListItem>
                <asp:ListItem Text="Insurance" Value="Insurance"></asp:ListItem>
                <asp:ListItem Text="Pharmaceutical" Value="Pharmaceutical"></asp:ListItem>
                <asp:ListItem Text="Technology" Value="Technology"></asp:ListItem>
                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
            </asp:DropDownList><br />

            <asp:Label runat="server" Text="Company/公司:" CssClass="fieldLabel"></asp:Label><br />

            <asp:TextBox runat="server" ID="companyText" Width="100%" CssClass="textField"></asp:TextBox><br />

            <asp:Label runat="server" Text="Email Address/邮件:" CssClass="fieldLabel"></asp:Label><br />

            <asp:TextBox runat="server" ID="emailText" Width="100%" CssClass="textField"></asp:TextBox><br />

            <asp:Label runat="server" Text="Confirm Email Address/确认邮件:" CssClass="fieldLabel"></asp:Label><br />

            <asp:TextBox runat="server" ID="confirmText" Width="100%" CssClass="textField"></asp:TextBox><br />
        </div>

    </div>
    <div style="margin-top: 18px">
        <asp:Button runat="server" CssClass="btnRegister" Text="Register now." OnClick="Register_Click" />
    </div>
</asp:Content>

