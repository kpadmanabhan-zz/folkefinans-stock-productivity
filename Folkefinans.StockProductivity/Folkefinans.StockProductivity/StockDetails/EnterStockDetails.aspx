<%@ Page Title="Enter stock details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnterStockDetails.aspx.cs" Inherits="Folkefinans.StockProductivity.StockDetails.EnterStockDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div><p></p></div>
    <div>
        
        <asp:Table ID="tblEnterStockDetails" runat="server" Width="50%">
            <asp:TableRow runat="server" Height="40">
                <asp:TableCell runat="server">StockName</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox runat="server" ID="txtStockName"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="40">
                <asp:TableCell runat="server">Price</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox runat="server" ID="txtPrice"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                        ControlToValidate="txtYears" runat="server"
                        ErrorMessage="Only decimals allowed"
                        ValidationExpression="^[0-9]([.,][0-9]{1,2})?$">
                    </asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="40">
                <asp:TableCell runat="server">Quantity</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox runat="server" ID="txtQuantity"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                        ControlToValidate="txtYears" runat="server"
                        ErrorMessage="Only numbers allowed"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="40">
                <asp:TableCell runat="server">Percentage</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox runat="server" ID="txtPercentage"></asp:TextBox>%
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                        ControlToValidate="txtYears" runat="server"
                        ErrorMessage="Only decimals allowed"
                        ValidationExpression="^[0-9]([.,][0-9]{1,2})?$">
                    </asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="40">
                <asp:TableCell runat="server">Years</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox runat="server" ID="txtYears"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        ControlToValidate="txtYears" runat="server"
                        ErrorMessage="Only Numbers allowed"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="40">
                <asp:TableCell runat="server" ColumnSpan="2">
                    <asp:Button runat="server" ID="btnCalculate" Text="Calculate" OnClick="btnCalculate_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
    </div>

    <div>
    </div>
</asp:Content>