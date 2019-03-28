using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Web;

namespace Programmers.Business
{
    public class ClientesBC : Entity.Clientes
    {
        #region Membros
        public List<ClientesBC> clientes;
        public OleDbConnection conexao;
        public OleDbDataAdapter adp;
        #endregion

        public ClientesBC() { }

        #region Métodos
        public void Conecta()
        {
            conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath(@"~/DB/Programmers.mdb"));
            adp = new OleDbDataAdapter("SELECT * FROM CLIENTES ", conexao);
        }

        public List<ClientesBC> Listar()
        {
            try
            {
                Conecta();

                clientes = new List<ClientesBC>();
                DataSet dtClientes = new DataSet();
                adp.Fill(dtClientes, "Clientes");

                if (dtClientes.Tables["Clientes"].Rows.Count > 0)
                    for (int i = 0; i < dtClientes.Tables["Clientes"].Rows.Count; i++)
                        clientes.Add(new ClientesBC()
                        {
                            IdCliente = Convert.ToInt32(dtClientes.Tables["Clientes"].Rows[i]["idCliente"]),
                            NmCliente = dtClientes.Tables["Clientes"].Rows[i]["nmCliente"].ToString(),
                            EmailCliente = dtClientes.Tables["Clientes"].Rows[i]["emailCliente"].ToString(),
                            TelefoneCliente = dtClientes.Tables["Clientes"].Rows[i]["telefoneCliente"].ToString()
                        });

                return clientes;
            }
            catch { return null; }
            finally { clientes = null; }
        }

        public ClientesBC Get(int idCliente)
        {
            try
            {
                var cliente = Listar().Where(c => c.IdCliente == IdCliente).First();

                return cliente;

            }
            catch { return null; }
        }

        public List<ClientesBC> AdicionarCliente()
        {
            try
            {
                Conecta();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("insert into Clientes ([nmCliente],[emailCliente], [telefoneCliente]) values ('{0}','{1}', '{2}')", this.NmCliente, this.EmailCliente, this.TelefoneCliente);
                cmd.Connection = conexao;
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }

            return Listar();
        }

        public List<ClientesBC> AtualizarCliente()
        {
            try
            {
                Conecta();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("update Clientes set [nmCliente] = '{1}', [emailCliente] = '{2}', [telefoneCliente] = '{3}' where [idCliente] = {0})", this.IdCliente, this.NmCliente, this.EmailCliente, this.TelefoneCliente);
                cmd.Connection = conexao;
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }

            return Listar();
        }

        public List<ClientesBC> RemoverCliente()
        {
            try
            {
                Conecta();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("delete from Clientes where [idCliente] = {0}", this.IdCliente);
                cmd.Connection = conexao;
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }

            return Listar();
        }
        #endregion
    }
}
