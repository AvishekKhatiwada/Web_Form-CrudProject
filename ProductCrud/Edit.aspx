<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ProductCrud.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Edit Product Detail</h3>
       <div class="form-group">
           <asp:TextBox style="display:none" runat="server" id="Idtextbox"></asp:TextBox>
            <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="QuantityLabel" runat="server" Text="Quantity(In Pcs.)"></asp:Label>
            <asp:TextBox ID="QuantityTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="PriceLabel" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="PriceTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="ColorLabel" runat="server" Text="Color"></asp:Label>
            <asp:TextBox ID="ColorTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="UpdateButton" runat="server" OnClick="Edit_Product" Text="Update" CssClass="btn btn-success"></asp:Button>
</asp:Content>
