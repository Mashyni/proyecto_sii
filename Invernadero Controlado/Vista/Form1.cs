using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Windows.Forms;




namespace Registro_de_Plantas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }










        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurar controles
            txtPlantaID.ReadOnly = true;

            // Cargar tipos de plantas en el ComboBox
            CargarTiposPlantas();

            // Cargar estados en el ComboBox
            cboEstado.Items.Add("Disponible");
            cboEstado.Items.Add("No disponible");
            cboEstado.Items.Add("En crecimiento");
            cboEstado.SelectedIndex = 0;

            // Establecer fecha actual
            dtpFechaRegistro.Value = DateTime.Now;

            // Cargar plantas en DataGridView
            CargarPlantas();
        }

        private void CargarTiposPlantas()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TipoID, NombreTipo FROM TiposPlanta", conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboTipoPlanta.DataSource = dt;
                    cboTipoPlanta.DisplayMember = "NombreTipo";
                    cboTipoPlanta.ValueMember = "TipoID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de plantas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPlantas()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    string query = @"SELECT p.PlantaID, p.NombrePlanta, t.NombreTipo, p.CantidadStock, 
                           p.FechaRegistro, p.Estado 
                           FROM NombrePlantas p 
                           INNER JOIN TiposPlanta t ON p.TipoID = t.TipoID";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPlantas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar plantas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }















        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar datos
                if (string.IsNullOrWhiteSpace(txtNombrePlanta.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de la planta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboTipoPlanta.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de planta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboEstado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener valores
                string nombrePlanta = txtNombrePlanta.Text.Trim();
                int tipoID = Convert.ToInt32(cboTipoPlanta.SelectedValue);
                int cantidadStock = Convert.ToInt32(nudCantidadStock.Value);
                DateTime fechaRegistro = dtpFechaRegistro.Value;
                string estado = cboEstado.SelectedItem.ToString();

                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();

                    // Si hay un ID, actualizar; si no, insertar
                    if (!string.IsNullOrEmpty(txtPlantaID.Text))
                    {
                        // Actualizar planta existente
                        int plantaID = Convert.ToInt32(txtPlantaID.Text);
                        string updateQuery = @"UPDATE NombrePlantas SET NombrePlanta = @nombre, TipoID = @tipoID, 
                                     CantidadStock = @stock, FechaRegistro = @fecha, Estado = @estado 
                                     WHERE PlantaID = @plantaID";

                        SqlCommand cmd = new SqlCommand(updateQuery, conexion);
                        cmd.Parameters.AddWithValue("@nombre", nombrePlanta);
                        cmd.Parameters.AddWithValue("@tipoID", tipoID);
                        cmd.Parameters.AddWithValue("@stock", cantidadStock);
                        cmd.Parameters.AddWithValue("@fecha", fechaRegistro);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@plantaID", plantaID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Planta actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Insertar nueva planta
                        string insertQuery = @"INSERT INTO NombrePlantas (NombrePlanta, TipoID, CantidadStock, FechaRegistro, Estado) 
                                     VALUES (@nombre, @tipoID, @stock, @fecha, @estado)";

                        SqlCommand cmd = new SqlCommand(insertQuery, conexion);
                        cmd.Parameters.AddWithValue("@nombre", nombrePlanta);
                        cmd.Parameters.AddWithValue("@tipoID", tipoID);
                        cmd.Parameters.AddWithValue("@stock", cantidadStock);
                        cmd.Parameters.AddWithValue("@fecha", fechaRegistro);
                        cmd.Parameters.AddWithValue("@estado", estado);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Planta registrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Limpiar y recargar
                    LimpiarFormulario();
                    CargarPlantas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la planta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





















        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtPlantaID.Clear();
            txtNombrePlanta.Clear();
            if (cboTipoPlanta.Items.Count > 0)
                cboTipoPlanta.SelectedIndex = 0;
            nudCantidadStock.Value = 0;
            dtpFechaRegistro.Value = DateTime.Now;
            if (cboEstado.Items.Count > 0)
                cboEstado.SelectedIndex = 0;
            txtNombrePlanta.Focus();
        }













        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea salir?", "Confirmar",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
private void dgvPlantas_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0)
    {
        DataGridViewRow row = dgvPlantas.Rows[e.RowIndex];
        
        txtPlantaID.Text = row.Cells["PlantaID"].Value.ToString();
        txtNombrePlanta.Text = row.Cells["NombrePlanta"].Value.ToString();
        
        // Buscar el tipo de planta en el ComboBox
        string nombreTipo = row.Cells["NombreTipo"].Value.ToString();
        for (int i = 0; i < cboTipoPlanta.Items.Count; i++)
        {
            DataRowView drv = (DataRowView)cboTipoPlanta.Items[i];
            if (drv["NombreTipo"].ToString() == nombreTipo)
            {
                cboTipoPlanta.SelectedIndex = i;
                break;
            }
        }
        
        nudCantidadStock.Value = Convert.ToDecimal(row.Cells["CantidadStock"].Value);
        dtpFechaRegistro.Value = Convert.ToDateTime(row.Cells["FechaRegistro"].Value);
        cboEstado.Text = row.Cells["Estado"].Value.ToString();
    }
}

        }

















}

    }

