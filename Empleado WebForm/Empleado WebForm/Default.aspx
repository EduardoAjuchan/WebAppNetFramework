<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Empleado_WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">
            <asp:Button runat="server" OnClick="Nuevo_Click" CssClass="btn btn-sm btn-success" Text="Nuevo" />
            <asp:Button runat="server" CssClass="btn btn-sm btn-primary" Text="Reportes" OnClientClick="$('#reportModal').modal('show'); return false;" />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GVEmpleado" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" />
                    <asp:BoundField DataField="Departamento.Nombre" HeaderText="Departamento" />
                    <asp:BoundField DataField="Sueldo" HeaderText="Sueldo" />
                    <asp:BoundField DataField="FechaContrato" HeaderText="Fecha de contrato" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de nacimiento" />
                    <asp:BoundField DataField="Edad" HeaderText="Edad" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdEmpleado") %>'
                                OnClick="Editar_Click" CssClass="btn btn-sm btn-primary"
                                > Editar</asp:LinkButton>

                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdEmpleado") %>'
                                OnClick="Eliminar_Click" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Desea eliminar?')"
                                > Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

   <!-- Aqui tenemos el Modal -->
<div id="reportModal" class="modal fade" role="dialog">
    <div class="modal-dialog">
        
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Generar Reporte</h4>
            </div>
           <div class="modal-body">
    <div class="mb-3">
        <label class="form-label">Fecha de Inicio:</label>
        <asp:TextBox ID="startDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label class="form-label">Fecha de Fin:</label>
        <asp:TextBox ID="endDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <asp:Label runat="server" ID="lblMessage" Visible="false"></asp:Label>
</div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnGenerate" Text="Generar" CssClass="btn btn-primary" OnClick="GenerarReporte_Click" />
                <asp:Button runat="server" ID="btnClose" Text="Cerrar" CssClass="btn btn-default" OnClientClick="closeModal()" />

              
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function closeModal() {
        $('#reportModal').modal('hide');
    }
</script>



</asp:Content>

