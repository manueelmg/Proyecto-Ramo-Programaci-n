using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace MineriaDatos
{
    public partial class GraficosDatos : Form
    {
        public GraficosDatos(DataTable dataTable)
        {
            InitializeComponent();

            // Configura el botón de exportar
            BtnExportarExcel.Click += BtnExportarExcel_Click;

            // Calcula y muestra datos por Ejecutivo
            MostrarPromedios(dataTable, "Ejecutivo", MayorPromedioEjecutivo, BajoPromedioEjecutivo, LblPromedioEjecutivo);

            // Calcula y muestra datos por Tipo de Venta
            MostrarPromedios(dataTable, "Tipo de Venta", MayorPromedioTipoVenta, BajoPromedioTipoVenta, LblPromedioTipoVenta);

            // Calcula y muestra datos por Plan
            MostrarPromedios(dataTable, "Plan", MayorPromedioPlan, BajoPromedioPlan, LblPromedioPlan);
        }

        //clase auxiliar para los resultados del agrupamiento
        public class GrupoPromedio
        {
            public string Key { get; set; }
            public int Promedio { get; set; }
        }

        //Muestra Promedios por tipo(Ejecutivo, Tipo de Venta y Plan)
        private void MostrarPromedios(DataTable dataTable, string columnName,
                              DataGridView mayorPromedioGrid, DataGridView bajoPromedioGrid, Label promedioLabel)
        {
            try
            {
                // Agrupar por la columna específica y calcular promedios
                var grupoPromedio = dataTable.AsEnumerable()
                    .GroupBy(row => row.Field<string>(columnName))
                    .Select(group => new GrupoPromedio
                    {
                        Key = group.Key,
                        Promedio = group.Count()
                    }).ToList();

                // Calcular el promedio general
                double promedioGeneral = grupoPromedio.Average(g => g.Promedio);


                // Actualizar el texto del Label con el promedio
                promedioLabel.Text = $"*Venta pomedio de {columnName} es: {promedioGeneral:F0}*";


                // Filtra registros por: igual o mayor y bajo el promedio
                var sobrePromedio = grupoPromedio.Where(g => g.Promedio >= promedioGeneral).ToList();
                var bajoPromedio = grupoPromedio.Where(g => g.Promedio < promedioGeneral).ToList();

                // Convertir a DataTable para asignar a los DataGridViews
                DataTable dtSobrePromedio = ConvertirADataTable(sobrePromedio, columnName);
                DataTable dtBajoPromedio = ConvertirADataTable(bajoPromedio, columnName);

                // Asignar a los DataGridViews
                mayorPromedioGrid.DataSource = dtSobrePromedio;
                bajoPromedioGrid.DataSource = dtBajoPromedio;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular promedios para {columnName}: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertirADataTable(List<GrupoPromedio> lista, string columnName)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(columnName, typeof(string));
            dataTable.Columns.Add("Cantidad", typeof(int));

            foreach (var item in lista)
            {
                dataTable.Rows.Add(item.Key, item.Promedio);
            }

            return dataTable;
        }

        //Boton para exportar los datos de los DataGridView a un excel
        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarDataGridsAExcel();
        }

        //Funcion que realiza la conversion y creacion del excel
        private void ExportarDataGridsAExcel()
        {
            try
            {
                // Crear la aplicación Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true; // Mostrar Excel al usuario

                // Crear un libro y una hoja de Excel
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Datos Exportados";

                // Exportar los datos de cada DataGridView
                int startRow = 1;

                ExportarDataGridView(MayorPromedioEjecutivo, worksheet, ref startRow, "Mayor Promedio Ejecutivo");
                ExportarDataGridView(BajoPromedioEjecutivo, worksheet, ref startRow, "Bajo Promedio Ejecutivo");

                ExportarDataGridView(MayorPromedioTipoVenta, worksheet, ref startRow, "Mayor Promedio Tipo de Venta");
                ExportarDataGridView(BajoPromedioTipoVenta, worksheet, ref startRow, "Bajo Promedio Tipo de Venta");

                ExportarDataGridView(MayorPromedioPlan, worksheet, ref startRow, "Mayor Promedio Plan");
                ExportarDataGridView(BajoPromedioPlan, worksheet, ref startRow, "Bajo Promedio Plan");

                MessageBox.Show("Datos exportados correctamente a Excel.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarDataGridView(DataGridView dgv, Excel.Worksheet worksheet, ref int startRow, string title)
        {
            if (dgv.DataSource == null) return;

            // Agregar título
            worksheet.Cells[startRow, 1] = title;
            worksheet.Range[worksheet.Cells[startRow, 1], worksheet.Cells[startRow, dgv.ColumnCount]].Merge();
            worksheet.Cells[startRow, 1].Font.Bold = true;
            startRow++;

            // Agregar encabezados
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                worksheet.Cells[startRow, i + 1] = dgv.Columns[i].HeaderText;
                worksheet.Cells[startRow, i + 1].Font.Bold = true;
            }
            startRow++;

            // Agregar filas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        worksheet.Cells[startRow, i + 1] = row.Cells[i].Value?.ToString() ?? "";
                    }
                    startRow++;
                }
            }

            // Espacio entre tablas
            startRow += 2;
        }
    }
}

