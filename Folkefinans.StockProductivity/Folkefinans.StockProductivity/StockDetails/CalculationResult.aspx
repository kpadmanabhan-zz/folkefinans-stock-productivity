<%@ Page Title="Calculation Result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalculationResult.aspx.cs" Inherits="Folkefinans.StockProductivity.StockDetails.CalculationResult" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div><p></p></div>
    <div>
        
        <asp:Table ID="tblCalculationResult" runat="server" Width="30%" GridLines="Both">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Field</asp:TableHeaderCell>
                <asp:TableHeaderCell>Value</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">StockName</asp:TableCell>
                <asp:TableCell runat="server" ID="tbcStockName"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Price</asp:TableCell>
                <asp:TableCell runat="server" ID="tbcPrice"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Quantity</asp:TableCell>
                <asp:TableCell runat="server" ID="tbcQuantity"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Percentage</asp:TableCell>
                <asp:TableCell runat="server" ID="tbcPercentage"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Years</asp:TableCell>
                <asp:TableCell runat="server" ID="tbcYears"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
    </div>

    <div><p></p></div>
    <div>
        
        <asp:Table ID="tblResults" runat="server" Width="20%" GridLines="Both">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Year</asp:TableHeaderCell>
                <asp:TableHeaderCell>Value</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        
    </div>
</asp:Content>