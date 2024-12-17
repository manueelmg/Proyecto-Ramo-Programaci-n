using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MineriaDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargaCSV_Click(object sender, EventArgs e)
        {
            string pathFile = @"C:\Users\manue\Desktop\BaseMovil.csv";
            DataTable dataTable = ConvertirCSVaDataTable(pathFile);

            dtgProducts.DataSource = dataTable;

            // Llena los ComboBoxes con los nombres de las columnas
            Filtro1.Items.Clear();
            Filtro2.Items.Clear(); // Nuevo ComboBox
            foreach (DataColumn column in dataTable.Columns)
            {
                Filtro1.Items.Add(column.ColumnName);
                Filtro2.Items.Add(column.ColumnName); // Llenar también el segundo ComboBox
            }

            // Inicia contadores
            ActualizarContadores(dataTable);
        }

        private DataTable ConvertirCSVaDataTable(string path)
        {
            DataTable datatable = new DataTable();
            string data;
            using (StreamReader sr = new StreamReader(path))
            {
                char separator = ';';
                data = sr.ReadLine();

                //Consideramos que el archivo tiene un encabezado.
                foreach (string columns in data.Split(separator))
                {
                    datatable.Columns.Add(columns);
                }

                //Obtenemos la data.
                data = sr.ReadLine();
                while (!string.IsNullOrEmpty(data))
                {
                    DataRow dataRow = datatable.NewRow();
                    int indexColumn = 0;
                    foreach (string dataColumn in data.Split(separator))
                    {
                        dataRow[indexColumn] = dataColumn;
                        indexColumn++;
                    }
                    datatable.Rows.Add(dataRow);
                    data = sr.ReadLine();
                }

                // Convertir la columna de fecha a DateTime
                foreach (DataRow row in datatable.Rows)
                {
                    if (DateTime.TryParseExact(row["Fecha Venta"].ToString(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                    {
                        row["Fecha Venta"] = dateValue;
                    }
                }

                return datatable;
            }
        }

        private string almacenFiltro1 = string.Empty; // Almacena el filtro de Filtro1
        private string almacenFiltro2 = string.Empty; // Almacena el filtro de Filtro2

        //Primer cuadro de filtro
        private void btnFiltro1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (dtgProducts.DataSource is DataTable dataTable)
            {
                string selectedColumn1 = Filtro1.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(selectedColumn1))
                {
                    if (selectedColumn1 == "Fecha Venta")
                    {
                        // Solicitar filtro de fecha
                        almacenFiltro1 = ConstructorFiltroFechas(dataTable, selectedColumn1);
                    }
                    else
                    {
                        string filterValue1 = PromptForInput($"Ingrese un valor para filtrar en la columna '{selectedColumn1}'")?.ToUpper();
                        if (!string.IsNullOrEmpty(filterValue1))
                        {
                            almacenFiltro1 = $"[{selectedColumn1}] LIKE '%{filterValue1}%'";
                        }
                    }
                }
                else
                {
                    almacenFiltro1 = string.Empty; // Si no hay selección, limpiar el filtro
                }

                AplicarFiltrosCombinados(dataTable);
            }
        }

        //Segundo cuadro de filtros
        private void btnFiltro2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtgProducts.DataSource is DataTable dataTable)
            {
                string selectedColumn2 = Filtro2.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(selectedColumn2))
                {
                    if (selectedColumn2 == "Fecha Venta")
                    {
                        // Solicitar filtro de fecha
                        almacenFiltro2 = ConstructorFiltroFechas(dataTable, selectedColumn2);
                    }
                    else
                    {
                        string filterValue2 = PromptForInput($"Ingrese un valor para filtrar en la columna '{selectedColumn2}'")?.ToUpper();
                        if (!string.IsNullOrEmpty(filterValue2))
                        {
                            almacenFiltro2 = $"[{selectedColumn2}] LIKE '%{filterValue2}%'";
                        }
                    }
                }
                else
                {
                    almacenFiltro2 = string.Empty; // Si no hay selección, limpiar el filtro
                }

                AplicarFiltrosCombinados(dataTable);
            }
        }

        //Si se seleccionan los dos filtros con datos, los combina para mostrarlos en el DataGridView
        private void AplicarFiltrosCombinados(DataTable dataTable)
        {
            try
            {
                // Combinar ambos filtros y aplicar al DataView
                string combinedFilter = string.Join(" AND ", new[] { almacenFiltro1, almacenFiltro2 }.Where(f => !string.IsNullOrEmpty(f)));
                dataTable.DefaultView.RowFilter = combinedFilter;

                // Actualizar contadores después de aplicar los filtros
                ActualizarContadores(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar el filtro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Si se selecciona "Fecha venta" en algun filtro, se crea el filtro acá
        private string ConstructorFiltroFechas(DataTable dataTable, string selectedColumn)
        {
            // Solicita la fecha inicial
            string startDateInput = PromptForInput("Ingrese una fecha o la fecha inicial del rango (formato: DD-MM-AAAA):");
            string endDateInput = PromptForInput("Ingrese la fecha final (deje vacío si desea filtrar por una sola fecha):");
            try
            {
                string dateFilter = string.Empty;

                //Si startDateInput(fecha inicial) no esta vacia ni nula ingresa al if
                if (!string.IsNullOrEmpty(startDateInput) && DateTime.TryParseExact(startDateInput, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime startDate))
                {
                    if (string.IsNullOrEmpty(endDateInput))
                    {
                        // Si se ingresa solo fecha inicial, filtrar por la fecha exacta
                        dateFilter = $"[{selectedColumn}] = #{startDate:MM/dd/yyyy}#";
                    }
                    
                    else (DateTime.TryParseExact(endDateInput, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime endDate))
                    {
                        // Si solo hay una fecha final válida, filtrar hasta esa fecha
                        dateFilter = $"[{selectedColumn}] <= #{endDate:MM/dd/yyyy}#";
                    }
      
                }

                
                else
                {
                    MessageBox.Show("La fecha inicial no es válida. Por favor, inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                return dateFilter;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al construir el filtro de fechas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        // Cuadro de dialogo para solicitar un valor al usuario(Prompt)
        private string PromptForInput(string message)
        {
            using (Form inputForm = new Form())
            {
                inputForm.Width = 400;
                inputForm.Height = 150;
                inputForm.Text = "Filtro";
                inputForm.StartPosition = FormStartPosition.CenterScreen;

                Label lblMessage = new Label() { Left = 20, Top = 20, Text = message, Width = 350 };
                TextBox txtInput = new TextBox() { Left = 20, Top = 50, Width = 350 };
                Button btnOk = new Button() { Text = "Aceptar", Left = 150, Top = 80, Width = 100 };

                btnOk.Click += (sender, e) => { inputForm.DialogResult = DialogResult.OK; inputForm.Close(); };

                inputForm.Controls.Add(lblMessage);
                inputForm.Controls.Add(txtInput);
                inputForm.Controls.Add(btnOk);

                return inputForm.ShowDialog() == DialogResult.OK ? txtInput.Text : string.Empty;
            }
        }
        // Cierre cuadro de dialogo para solicitar un valor al usuario

        //Envia los datos de Form1 a Form2
        private void EnviarDatos_Click(object sender, EventArgs e)
        {
            if (dtgProducts.DataSource is DataTable dataTable)
            {
                // Crear una copia de los datos filtrados
                DataTable filteredData = dataTable.DefaultView.ToTable();

                GraficosDatos form2 = new GraficosDatos
                {
                    DataToDisplay = filteredData
                };

                form2.Show();
            }
            else
            {
                MessageBox.Show("No hay datos cargados en la tabla para mostrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Boton para borrar los filtros de los btnFiltro1 y btnFiltro2
        private void BorrarFiltros_Click(object sender, EventArgs e)
        {
            if (dtgProducts.DataSource is DataTable dataTable)
            {
                // Restablecer los filtros
                almacenFiltro1 = string.Empty;
                almacenFiltro2 = string.Empty;

                // Limpiar cualquier filtro aplicado en el DataView
                dataTable.DefaultView.RowFilter = string.Empty;

                // Limpiar las selecciones de los Filtros
                Filtro1.SelectedIndex = -1;
                Filtro2.SelectedIndex = -1;

                // Actualizar contadores después de eliminar los filtros
                ActualizarContadores(dataTable);

                MessageBox.Show("Filtros eliminados. Tabla restaurada a valores originales.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay datos cargados en la tabla para borrar filtros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Contador
        private void ActualizarContadores(DataTable dataTable)
        {
            // Contar registros por ejecutivo
            var contEjecutivo = dataTable.AsEnumerable()
                .GroupBy(row => row.Field<string>("Ejecutivo"))
                .Select(group => new { Ejecutivo = group.Key, Count = group.Count() })
                .ToList();

            // Contar registros por tipo de venta
            var contTipoVenta = dataTable.AsEnumerable()
                .GroupBy(row => row.Field<string>("Tipo de Venta"))
                .Select(group => new { TipoVenta = group.Key, Count = group.Count() })
                .ToList();

            // Contar registros por plan
            var contPlan = dataTable.AsEnumerable()
                .GroupBy(row => row.Field<string>("Plan"))
                .Select(group => new { Plan = group.Key, Count = group.Count() })
                .ToList();

            // Actualizar etiquetas con los contadores
            //lblCountEjecutivo.Text = "Ejecutivo:\n" + string.Join("\n", contEjecutivo.Select(e => $"{e.Ejecutivo}: {e.Count}"));
            //lblCountTipodeVenta.Text = "Tipo de Venta:\n" + string.Join("\n", contTipoVenta.Select(tv => $"{tv.TipoVenta}: {tv.Count}"));
            //lblCountPlan.Text = "Plan:\n" + string.Join("\n", contPlan.Select(p => $"{p.Plan}: {p.Count}"));
        }

    }
}
