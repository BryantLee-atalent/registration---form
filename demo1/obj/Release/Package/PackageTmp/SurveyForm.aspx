<%@ Page Title="" Language="C#" MasterPageFile="~/Head.Master" AutoEventWireup="true" CodeBehind="SurveyForm.aspx.cs" Inherits="demo1.SurveyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SurveyForm" runat="server">
    <style type="text/css">
        .radioStyle {
        }

        .labelStyle {
            font-size: large
        }

        .btnStyle {
            margin-top: 23px;
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
        .formStyle{
            border:1px
            /*background-color:#DCDCDC*/
        }
    </style>
    <div>
        <asp:Label runat="server" ForeColor="#FF6347" Text="Thank you for your registration." Font-Size="X-Large"></asp:Label><br />
        <div style="margin-top: 15px">
            <asp:Label runat="server" Text="You will receive confirmation on your registration within the next 2 working days." Font-Size="Medium"></asp:Label><br />
        </div>
        <div class="formStyle">
            <div style="margin-top: 12px;margin-bottom:12px">
                <asp:Label runat="server" ForeColor="#FF6347" Text="In the meantime, complete this survey for a free Starbucks drink:" Font-Size="Large"></asp:Label>
            </div>

            <div style="border-bottom:dashed 1px;border-bottom-color:tomato; margin-bottom:10px">
                <asp:Label runat="server" Text="1.How many followers you have in company WeChat recruitment account." CssClass="labelStyle"></asp:Label><br />
                <asp:RadioButtonList runat="server" ID="oneRadio" CellPadding="3">
                    <asp:ListItem Text="<2000" Value="<2000"></asp:ListItem>
                    <asp:ListItem Text="2000 to 4999" Value="2000 to 4999"></asp:ListItem>
                    <asp:ListItem Text="5000 to 9999" Value="5000 to 9999"></asp:ListItem>
                    <asp:ListItem Text=">10000" Value=">10000"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div style="border-bottom:dashed 1px;border-bottom-color:tomato; margin-bottom:10px">
                <asp:Label runat="server" CssClass="labelStyle" Text="2.How often you engage (directly communicate, not through regular WeChat post) with your followers in WeChat recruitment account."></asp:Label><br />
                <asp:RadioButtonList runat="server" CssClass="radioStyle" ID="twoRadio"  CellPadding="3">
                    <asp:ListItem Text="Never" Value="never"></asp:ListItem>
                    <asp:ListItem Text="Less than 3 time a year" Value="less than 3 time a year"></asp:ListItem>
                    <asp:ListItem Text="More than 3 but less than 6 time a year" Value="more than 3 but less than 6 time a year"></asp:ListItem>
                    <asp:ListItem Text="At least once a month" Value="at least once a month"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div style="border-bottom:dashed 1px;border-bottom-color:tomato; margin-bottom:10px">
                <asp:Label runat="server" CssClass="labelStyle" Text="3.How well you know your WeChat recruitment account followers."></asp:Label><br />
                <asp:RadioButtonList runat="server" CssClass="radioStyle" ID="threeRadio"  CellPadding="3">
                    <asp:ListItem Text="Don’t know them at all" Value="Don’t know at all"></asp:ListItem>
                    <asp:ListItem Text="I only know some simple demographic such as locations/genders" Value="I only know some simple demographic such as locations/genders"></asp:ListItem>
                    <asp:ListItem Text="I have a good and clear picture of who they are and their job/career preference" Value="I have a good and clear picture of who they are and their job/career preference"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div style="margin-bottom:10px">
                <asp:Label runat="server" CssClass="labelStyle" Text="4.What do you think the percentage of successful hires are coming from followers in WeChat recruitment accounts."></asp:Label><br />
                <asp:RadioButtonList runat="server" CssClass="radioStyle" ID="fourRadio"  CellPadding="3">
                    <asp:ListItem Text="No idea" Value="No idea"></asp:ListItem>
                    <asp:ListItem Text="I guess 10%" Value="I guess 10%"></asp:ListItem>
                    <asp:ListItem Text="I guess 10-20%" Value="I guess 10-20%"></asp:ListItem>
                    <asp:ListItem Text="I am quite positive it is more than 20%" Value="I am quite positive it is more than 20%"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <asp:Button runat="server" CssClass="btnStyle" Text="Submit." OnClick="Submit_Click" ID="submit"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false"/>
    </div>
</asp:Content>
