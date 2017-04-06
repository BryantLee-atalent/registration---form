<%@ Page Title="" Language="C#" MasterPageFile="~/Head.Master" AutoEventWireup="true" CodeBehind="RegistraSuccess.aspx.cs" Inherits="demo1.RegistrSuccess" %>

<asp:Content ID="Content2" ContentPlaceHolderID="RegisterSuccess" runat="server">
<%--    <script type="text/javascript">
        var i = 5;
        setInterval(function timer() {
            document.getElementById('timeTitle').innerText = 'The system will jump to the survey page within '+(i--)+'s.';
        }, 1000);
    </script>--%>
    <asp:Label runat="server" ForeColor="#FF6347" Text="Thank you for your take part in our survey." Font-Size="Large"></asp:Label>
    <div style="margin-top: 18px">
        <asp:Label runat="server" Text="We are brewing the Starbucks coupon for you via weChat, stay tuned! <a style='color:tomato'>(你的星巴克优惠券，我们会通过微信发给你)</a>" Font-Size="Medium"></asp:Label>
    </div>
     <div style="margin-top: 18px">
        <asp:Label runat="server" Text="Enter your constellation via weChat, we will prepare you a special drink at the event!  <a style='color:tomato'>(在我们微信端，输入你的星座，我们会特此为你准备一个惊喜)</a>" Font-Size="Medium"></asp:Label>
    </div>
<%--    <div style="margin-top: 22px">
        <p id="timeTitle"></p>
    </div>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:Timer runat="server" Interval="5000" OnTick="surveyForm_Click" ID="timer"></asp:Timer>
    <asp:Button runat="server" ID="surveyForm" OnClick="surveyForm_Click"  Visible="false"/>--%>
</asp:Content>
