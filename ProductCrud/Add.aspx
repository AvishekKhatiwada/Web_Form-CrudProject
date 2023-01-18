<%@ Page Title="Add New Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ProductCrud.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

        <div class="form-group">
            <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control" placeholder="Enter name"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="QuantityLabel" runat="server" Text="Quantity(In Pcs.)"></asp:Label>
            <asp:TextBox ID="QuantityTextBox" runat="server" CssClass="form-control" placeholder="Enter quantity"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="PriceLabel" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="PriceTextBox" runat="server" CssClass="form-control" placeholder="Enter price"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="ColorLabel" runat="server" Text="Color"></asp:Label>
            <asp:TextBox ID="ColorTextBox" runat="server" CssClass="form-control" placeholder="Enter color"></asp:TextBox>
        </div>
        <asp:Button ID="SubmitButton" OnClick="Add_Product" runat="server" Text="Save" CssClass="btn btn-success"></asp:Button>

</asp:Content>
