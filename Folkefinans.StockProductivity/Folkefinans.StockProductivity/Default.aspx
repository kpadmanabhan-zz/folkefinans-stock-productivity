<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Folkefinans.StockProductivity._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div><p></p></div>
    <div style="text-align:center; vertical-align: middle;">
        <asp:button runat="server" id="btnEnterStockDetails" Text="Enter Stock Details" OnClick="btnEnterStockDetails_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:button runat="server" id="btnViewCalculatedResult" Text="View Calculated Result" OnClick="btnViewCalculatedResult_Click" />
    </div>
</asp:Content>
