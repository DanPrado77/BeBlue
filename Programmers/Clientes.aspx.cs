using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using E = Programmers.Entity;
using B = Programmers.Business;

namespace Programmers.Web
{
    public partial class ClientesWeb : System.Web.UI.Page
    {
        List<B.ClientesBC> clientes = new List<B.ClientesBC>();
        B.ClientesBC Cliente = new B.ClientesBC();

        #region Métodos
        protected void LimpaTela()
        {
            this.NmCliente.Text = "";
            this.EmailCliente.Text = "";
            this.TelefoneCliente.Text = "";
            this.IdCliente.Value = "0";
        }

        protected void CarregaTela()
        {
            clientes = new B.ClientesBC().Listar();
            LimpaTela();

            this.grdClientes.DataSource = clientes;
            this.grdClientes.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CarregaTela();
            }
            catch { }
        }

        protected void grdClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                LimpaTela();

                var esteCliente = clientes.Where(c => c.IdCliente == int.Parse(e.CommandArgument.ToString())).First();

                this.NmCliente.Text = esteCliente.NmCliente;
                this.EmailCliente.Text = esteCliente.EmailCliente;
                this.TelefoneCliente.Text = esteCliente.TelefoneCliente;
                this.IdCliente.Value = esteCliente.IdCliente.ToString();
            }
            catch { }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente = new B.ClientesBC();

                Cliente.NmCliente = this.Request["NmCliente"].ToString();
                Cliente.EmailCliente = this.Request["EmailCliente"].ToString();
                Cliente.TelefoneCliente = this.Request["TelefoneCliente"].ToString();
                Cliente.IdCliente = int.Parse(this.Request["IdCliente"].ToString());

                if (Cliente.IdCliente == 0)
                    this.grdClientes.DataSource = Cliente.AdicionarCliente();
                else
                    this.grdClientes.DataSource = Cliente.AtualizarCliente();

                this.grdClientes.DataBind();
                LimpaTela();
            }
            catch { CarregaTela(); }
            finally { Cliente = null; }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpaTela();
                this.NmCliente.Focus();
            }
            catch { }
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente = new B.ClientesBC();

                Cliente.IdCliente = int.Parse(this.Request["IdCliente"].ToString());
                this.grdClientes.DataSource = Cliente.RemoverCliente();
                this.grdClientes.DataBind();
                LimpaTela();
            }
            catch { CarregaTela(); }
            finally
            {
                Cliente = null;
            }
        }
    }
}