using apiexamen.dll.Models;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace apiexamen.dll
{
    public class ClsExamen
    {
        SqlConnection _sqlConnection;
        public bool useApi { get; set; }
        public ClsExamen() 
        {
            _sqlConnection = new SqlConnection("Data Source=GPS-LEGIONLAP\\SQLEXPRESS;Initial Catalog=BdiExamen;User ID=spargz;Password=abcD1234");
            useApi = false;
        }

        public async Task<bool> AgregarExamen(string nombre, string descripcion)
        {
            bool result = false;

            if (useApi)
            {
                // Utilizamos web api
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiHelper.HttpClient.BaseAddress);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        nombre = nombre,
                        descripcion = descripcion
                    });

                    streamWriter.Write(json);
                }

                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            else
            {
                // Utilizamos stored procedure
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.spAgregar";
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = nombre;
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = descripcion;

                    _sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }
                finally
                {
                    if (_sqlConnection != null)
                    {
                        _sqlConnection.Close();
                    }
                    if (_sqlConnection != null)
                    {
                        _sqlConnection.Close();
                    }
                }
            }

            return result;
        }

        public async Task<bool> ActualizarExamen(string idExamen, string nombre, string descripcion)
        {
            bool result = false;
            int id;

            Int32.TryParse(idExamen, out id);

            if (useApi)
            {
                // Utilizamos web api
                string url = $"{id}";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiHelper.HttpClient.BaseAddress + url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        nombre = nombre,
                        descripcion = descripcion
                    });

                    streamWriter.Write(json);
                }

                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            else
            {
                // Utilizamos stored procedure
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.spActualizar";
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                    cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = nombre;
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = descripcion;

                    _sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }
                finally
                {
                    if (_sqlConnection != null)
                    {
                        _sqlConnection.Close();
                    }
                    if (_sqlConnection != null)
                    {
                        _sqlConnection.Close();
                    }
                }
            }

            return result;
        }

        public async Task<bool> EliminarExamen(string idExamen)
        {
            bool result = false;
            int id;

            Int32.TryParse(idExamen, out id);

            if (useApi)
            {
                // Utilizamos web api
                string url = $"{id}";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiHelper.HttpClient.BaseAddress + url);
                httpWebRequest.Method = "DELETE";

                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            else
            {
                // Utilizamos stored procedure
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.spEliminar";
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                    _sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }
                finally
                {
                    if (_sqlConnection != null)
                    {
                        _sqlConnection.Close();
                    }
                    if (_sqlConnection != null)
                    {
                        _sqlConnection.Close();
                    }
                }
            }

            return result;
        }

        public async Task<List<ExamenModel>> ConsultarExamen(string id = "", string nombre = "", string descripcion = "")
        {
            List<ExamenModel> examenes = new List<ExamenModel>();

            if (useApi)
            {
                // Utilizamos web api
                string url = $"{id}";
                using (HttpResponseMessage response = await ApiHelper.HttpClient.GetAsync(ApiHelper.HttpClient.BaseAddress + url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        ExamenModel examen = await response.Content.ReadAsAsync<ExamenModel>();
                        examenes.Add(examen);
                    }
                }
            }
            else
            {
                // Utilizamos stored procedures
                try
                {
                    _sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM tblExamen WHERE Nombre = '{nombre}' AND Descripcion = '{descripcion}'", _sqlConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ExamenModel examen = new ExamenModel();

                        examen.idExamen = (int)reader.GetValue(0);
                        examen.Nombre = reader.GetValue(1).ToString();
                        examen.Descripcion = reader.GetValue(2).ToString();

                        examenes.Add(examen);
                    }
                }
                finally
                {
                    if (_sqlConnection != null)
                    {
                        _sqlConnection.Close();
                    }
                    if (_sqlConnection != null)
                    {
                        _sqlConnection.Close();
                    }
                }
            }

            return examenes;
        }

        public List<ExamenModel> ConsultarExamenesPorSP()
        {
            List<ExamenModel> examenes = new List<ExamenModel>();

            try
            {
                _sqlConnection.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM tblExamen", _sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExamenModel examen = new ExamenModel();
                    examen.idExamen = (int)reader.GetValue(0);
                    examen.Nombre = reader.GetValue(1).ToString();
                    examen.Descripcion = reader.GetValue(2).ToString();
                    examenes.Add(examen);
                }
            }
            finally
            {
                if (_sqlConnection != null)
                {
                    _sqlConnection.Close();
                }
                if (_sqlConnection != null)
                {
                    _sqlConnection.Close();
                }
            }

            return examenes;
        }

    }
}
