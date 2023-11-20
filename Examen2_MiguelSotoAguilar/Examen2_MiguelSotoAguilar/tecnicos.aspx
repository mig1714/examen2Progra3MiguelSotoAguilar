<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="tecnicos.aspx.cs" Inherits="Examen2_MiguelSotoAguilar.tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Tecnicos</h1>
    </div>
    <div class="container text-center">
        <asp:GridView ID="datagrid" CssClass="mydatagrid" PageSize="10" HorizontalAlign="Center"
            AutoGenerateColumns="true" PagerStyle-CssClass="pager" runat="server" 
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="true"></asp:GridView>
    </div>

    <div class="container text-center">

        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Codigo</label>
            <asp:TextBox ID="txt_codigo" class="form-control" runat="server"></asp:TextBox>
            
        </div>

        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Nombre</label>
            <asp:TextBox ID="txt_NombreTecnico" class="form-control" runat="server"></asp:TextBox>
            
        </div>

        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Especialidad</label>
            
            <asp:TextBox ID="txt_Especialidad" class="form-control" runat="server"></asp:TextBox>
            
        </div>

        
            
        

    </div>
    <div class="container text-center">

        <asp:Button ID="Button1" class="btn btn-outline-primary"  runat="server" Text="Agregar" OnClick="Button1_Click" />
        <asp:Button ID="Button2" class="btn btn-outline-primary"  runat="server" Text="Borrar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" class="btn btn-outline-primary"  runat="server" Text="Modificar" OnClick="Button3_Click" />
        <asp:Button ID="BtnConsulta" class="btn btn-outline-primary"  runat="server" Text="Consultar" OnClick="BtnConsulta_Click" />
    </div>
 

</asp:Content>
