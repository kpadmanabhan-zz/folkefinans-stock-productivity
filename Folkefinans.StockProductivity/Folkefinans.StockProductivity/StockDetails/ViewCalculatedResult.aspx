<%@ Page Title="Stock Productivity Result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCalculatedResult.aspx.cs" Inherits="Folkefinans.StockProductivity.StockDetails.ViewCalculatedResult" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div><p></p></div>
    <div>
        <asp:Table ID="tblProductivityResults" runat="server" Width="100%" GridLines="Both">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>StockName</asp:TableHeaderCell>
                <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                <asp:TableHeaderCell>Quantity</asp:TableHeaderCell>
                <asp:TableHeaderCell>Percentage</asp:TableHeaderCell>
                <asp:TableHeaderCell>Years</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>    
    
    <div><p></p></div>
    <div>
        <asp:Label runat="server" ID ="lblStockName" Font-Bold="True">Stock Name: </asp:Label>
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