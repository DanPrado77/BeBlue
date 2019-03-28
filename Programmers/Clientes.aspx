<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Programmers.Web.ClientesWeb" EnableViewState="true" EnableEventValidation="true" Explicit="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Teste Programmers</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" type="text/css" />      
    </head>
    <body>
        <form id="frmProgrammers" runat="server">
           <div class="container-fluid">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">Clientes</div>
                        <div class="panel-body">
                            <div class="col-md-12">
                                <label>Nome</label>
                                <br /><asp:TextBox runat="server" ID="NmCliente" EnableViewState="true" MaxLength="70" class="form-control" Width="300px" placeHolder="Nome do Cliente"></asp:TextBox>
                            </div>
                            <div class="col-md-12"><hr /></div>
                            <div class="col-md-6">
                                <label>E-Mail</label>
                                <br /><asp:TextBox runat="server" ID="EmailCliente" MaxLength="70" class="form-control" Width="100%" placeHolder="endereço de e-mail"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Telefone</label>
                                <br /><asp:TextBox runat="server" ID="TelefoneCliente" ClientIDMode="Static" MaxLength="15" class="form-control" Width="150px" placeHolder="(__) _____-____"></asp:TextBox>
                            </div>
                             <div class="col-md-12"><hr /></div>
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="pull-left"><asp:Button ID="btnNovo" runat="server" CssClass="btn btn-success" Width="90px" Text="Novo" OnClick="btnNovo_Click" /></div>
                                </div>
                                <div class="col-md-6">
                                    <div class="pull-right">
                                       <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-default" Width="90px" Text="Salvar" OnClick="btnSalvar_Click" />
                                        <asp:Button ID="btnRemover" runat="server" CssClass="btn btn-warning" Width="90px" Text="Remover" OnClientClick="if(!confirm('Você confirma essa exclusão?')) return false;" OnClick="btnRemover_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-12"><hr /></div>
                    <div class="col-md-12">
                        <asp:GridView ID="grdClientes" runat="server" CssClass="table table-hover" GridLines="None" BorderWidth="0px" BorderColor="#ffffff" OnRowCommand="grdClientes_RowCommand" EmptyDataRowStyle-CssClass="text-info" EmptyDataText="Não existem clientes cadastrados!" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="5%">
                                    <ItemTemplate><span class="control-label"><%# Eval("IdCliente") %></span></ItemTemplate>
                                    <HeaderTemplate><h5>Id.</h5></HeaderTemplate>
                                </asp:TemplateField >
                                <asp:TemplateField ItemStyle-Width="40%">
                                    <ItemTemplate><asp:LinkButton ID="lnkEditar" runat="server" CssClass="btn" CommandArgument='<%# Eval("IdCliente") %>'><%# Eval("NmCliente") %></asp:LinkButton></ItemTemplate>
                                    <HeaderTemplate><h5>Nome</h5></HeaderTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30%">
                                    <ItemTemplate><span class="control-label"><%# Eval("EmailCliente") %></span></ItemTemplate>
                                    <HeaderTemplate><h5>E-Mail</h5></div></HeaderTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="25%">
                                    <ItemTemplate><span class="control-label"><%# Eval("TelefoneCliente") %></span></ItemTemplate>
                                    <HeaderTemplate><h5>Telefone</h5></div></HeaderTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-md-4"></div>
            </div>
            <asp:HiddenField ID="IdCliente" runat="server" Value="0" />
        </form>
    </body>
    
    <script src="https://code.jquery.com/jquery-1.11.2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.13.4/jquery.mask.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $('#TelefoneCliente').mask("(99) 9999-99999");
        });
    </script>
</html>
