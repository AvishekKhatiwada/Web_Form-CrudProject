<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductCrud._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Product Details</h1>

    <a runat="server" href="~/Add" class="btn btn-primary">Add New</a>

    <asp:GridView ID="productGridView" runat="server"  AutoGenerateColumns="False" CssClass="table">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ProductId" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity(Pcs.)" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Color" HeaderText="Color" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" ID="editButton" Text="Edit" OnClick="Edit_Click" CommandArgument='<%#Eval("id")%>' />
                    <asp:LinkButton runat="server" CssClass="btn btn-danger" ID="DeleteButton" Text="Delete" OnClick="Delete_Click" CommandArgument='<%#Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
