<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Empleado_WebForm.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

    <div class="mb-3">
        <label class="form-label">Nombre Completo</label>
        <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label class="form-label">Departamento</label>
        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <label class="form-label">Sueldo</label>
        <asp:TextBox ID="txtSueldo" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label class="form-label">Fecha de Contrato</label>
        <asp:TextBox ID="txtFechaContrato" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label class="form-label">Fecha de Nacimiento</label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label class="form-label">Estatus</label>
        <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="form-select">
            <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
            <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click" />
    <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-sm btn-warning">Volver</asp:LinkButton>

</asp:Content>
