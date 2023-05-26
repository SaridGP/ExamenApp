using apiexamen.dll;
using apiexamen.dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClsExamen clsExamen = new ClsExamen();
        protected void Page_Load(object sender, EventArgs e)
        {
            ApiHelper.InitializeClient();

            // Poblamos la tabla de un inicio con los datos almacenados
            List<ExamenModel> examenes = clsExamen.ConsultarExamenesPorSP();
            grvData.DataSource = examenes;
            grvData.DataBind();
        }

        protected async void BtAgregar_Click(object sender, EventArgs e)
        {
            bool res;

            string nombre = tbNombre.Text;
            string descripcion = tbDescripcion.Text;

            if (int.Parse(rbtServicio.SelectedValue.ToString()) == 0)
            {
                // Usamos stored procedures
                clsExamen.useApi = false;
            }
            else
            {
                // Usamos web service api
                clsExamen.useApi = true;
            }

            res = await clsExamen.AgregarExamen(nombre, descripcion);
            tbOutput.Text = res.ToString();
        }

        protected async void BtConsultar_Click(object sender, EventArgs e)
        {
            string idExamen = tbID.Text;
            string nombre = tbNombre.Text;
            string descripcion = tbDescripcion.Text;

            if (int.Parse(rbtServicio.SelectedValue.ToString()) == 0)
            {
                // Usamos stored procedures
                clsExamen.useApi = false;
            }
            else
            {
                // Usamos web service api
                clsExamen.useApi = true;
            }

            List<ExamenModel> examenes = await clsExamen.ConsultarExamen(idExamen, nombre, descripcion);
            grvData.DataSource = examenes;
            grvData.DataBind();
        }

        protected void BtConsultarTodo_Click(object sender, EventArgs e)
        {
            List<ExamenModel> examenes = clsExamen.ConsultarExamenesPorSP();
            grvData.DataSource = examenes;
            grvData.DataBind();
        }

        protected void rbtServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiamos el valor de uso de servicio dependiendo de lo seleccionado por el usuario
            if (int.Parse(rbtServicio.SelectedValue.ToString()) == 0)
            {
                // Usamos stored procedures
                clsExamen.useApi = false;
            }
            else
            {
                // Usamos web service api
                clsExamen.useApi = true;
            }

            tbOutput.Text = clsExamen.useApi.ToString();
        }

        protected async void BtActualizar_Click(object sender, EventArgs e)
        {
            bool res;

            string IdExamen = tbID.Text;
            string nombre = tbNombre.Text;
            string descripcion = tbDescripcion.Text;

            if (int.Parse(rbtServicio.SelectedValue.ToString()) == 0)
            {
                // Usamos stored procedures
                clsExamen.useApi = false;
            }
            else
            {
                // Usamos web service api
                clsExamen.useApi = true;
            }

            res = await clsExamen.ActualizarExamen(IdExamen, nombre, descripcion);
            tbOutput.Text = res.ToString();
        }

        protected async void BtEliminar_Click(object sender, EventArgs e)
        {
            bool res;

            string IdExamen = tbID.Text;

            if (int.Parse(rbtServicio.SelectedValue.ToString()) == 0)
            {
                // Usamos stored procedures
                clsExamen.useApi = false;
            }
            else
            {
                // Usamos web service api
                clsExamen.useApi = true;
            }

            res = await clsExamen.EliminarExamen(IdExamen);
            tbOutput.Text = res.ToString();
        }
    }
}