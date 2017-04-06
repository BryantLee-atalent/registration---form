<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Head.Master" CodeBehind="Default.aspx.cs" Inherits="demo1.head" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<%--    <script type="text/javascript">
        
        wx.config({
            debug: false,
                appId: '<%=AppId %>',
                timestamp:  '<%=Timestamp %>', // 必填，生成签名的时间戳--->系统自己生成的时间戳。
                nonceStr:  '<%=NonceStr %>', // 必填，生成签名的随机串--->系统本地生成的UUID。
                signature: '<%=Signature %>',// 必填，签名，见附录1
                jsApiList: ["", "" ] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2--->一大串CC+CV
            });

        wx.ready(function () { });
    </script>--%>

    <style type="text/css">
        .fieldLabel {
            color: #EE7621;
            font-size: medium;
            width: auto;
        }

        .comboField {
            border-top: 0px solid;
            border-left: 0px solid;
            border-right: 0px solid;
            border-bottom: 1px solid;
            outline: none;
            font-size: medium;
            border-radius: 0;
            width: 100%
        }

        .textField {
            border-top: 0px solid;
            border-left: 0px solid;
            border-right: 0px solid;
            border-bottom: 1px solid;
            outline: none;
            font-size: medium;
            border-radius: 0;
            width: 95%
        }

        .btnRegister {
            align-items: center;
            border-radius: 0;
            width: auto;
            height: auto;
            background-repeat: no-repeat;
            background-position: right center;
            background-color: white;
            height: 30px;
            text-align: left;
            width: 40%;
            background-image: url('image/btn.png')
        }
    </style>
    <asp:Label runat="server" ForeColor="#FF6347" Text="Ready to learn how to Attract, Recruit & Engage Talent with WeChat?" Font-Size="X-Large"></asp:Label>
    <div style="margin-top: 12px">
        <asp:Label runat="server" Text="Please fill in the following details to register for the &#34;WeChat Recruitment 2.0&#34;: " Font-Size="Medium"></asp:Label>
    </div>
    <div>
        <div style="margin-top: 13px" runat="server">
            <asp:Label runat="server" CssClass="fieldLabel" Text="Name / 姓名:" ID="name"></asp:Label><br />

            <asp:TextBox runat="server" CssClass="textField" ID="nameText"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="The name field must be filled in." ControlToValidate="nameText" ForeColor="Red"></asp:RequiredFieldValidator><br />

            <asp:Label runat="server" Text="Title / 职位:" CssClass="fieldLabel" ID="title"></asp:Label><br />

            <asp:DropDownList runat="server" ID="titleCombo" CssClass="comboField">
                <asp:ListItem Text="---Please Select---" Value="1"></asp:ListItem>
                <asp:ListItem Text="HRD" Value="HRD"></asp:ListItem>
                <asp:ListItem Text="HRVP" Value="HRVP"></asp:ListItem>
                <asp:ListItem Text="Senior HR manager" Value="Senior HR manager"></asp:ListItem>
                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ErrorMessage="The name field cannot be empty！" ControlToValidate="titleCombo" ForeColor="Red"></asp:RequiredFieldValidator><br />

            <asp:Label runat="server" Text="Industry / 行业:" CssClass="fieldLabel"></asp:Label><br />

            <asp:DropDownList runat="server" ID="industryCombo" CssClass="comboField">
                <asp:ListItem Text="---Please Select---" Value="1"></asp:ListItem>
                <asp:ListItem Text="Automotive" Value="Automotive"></asp:ListItem>
                <asp:ListItem Text="Consulting" Value="Consulting"></asp:ListItem>
                <asp:ListItem Text="Electronics" Value="Electronics"></asp:ListItem>
                <asp:ListItem Text="Education" Value="Education"></asp:ListItem>
                <asp:ListItem Text="Finance" Value="Finance"></asp:ListItem>
                <asp:ListItem Text="FMCG" Value="FMCG"></asp:ListItem>
                <asp:ListItem Text="Manufacturing" Value="Manufacturing"></asp:ListItem>
                <asp:ListItem Text="Retail" Value="Retail"></asp:ListItem>
                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ErrorMessage="The name field cannot be empty！" ControlToValidate="industryCombo" ForeColor="Red"></asp:RequiredFieldValidator><br />

            <asp:Label runat="server" Text="Company / 公司:" CssClass="fieldLabel"></asp:Label><br />

            <asp:TextBox runat="server" ID="companyText" CssClass="textField"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ErrorMessage="The company field must be filled in." ControlToValidate="companyText" ForeColor="Red"></asp:RequiredFieldValidator><br />

            <asp:Label runat="server" Text="Email Address / 邮件:" CssClass="fieldLabel"></asp:Label><br />

            <asp:TextBox runat="server" ID="emailText" CssClass="textField"></asp:TextBox><br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" runat="server" ErrorMessage="Please enter the correct email !" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailText"></asp:RegularExpressionValidator><br />

            <asp:Label runat="server" Text="Confirm Email Address / 确认邮件:" CssClass="fieldLabel"></asp:Label><br />
            <asp:TextBox runat="server" ID="confirmText" CssClass="textField"></asp:TextBox><br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ErrorMessage="Input do not match the email field !" ControlToValidate="confirmText" ControlToCompare="emailText"></asp:CompareValidator><br />
        </div>

    </div>
    <div style="margin-top: 18px">
        <asp:Button runat="server" CssClass="btnRegister" Text="Register now." ID="btnSubmit" OnClick="Register_Click" OnClientClick="this.disabled=true;"  CausesValidation="true" UseSubmitBehavior="false"/>
    </div>
</asp:Content>

