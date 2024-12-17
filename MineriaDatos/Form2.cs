using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MineriaDatos
{
    public partial class Form2 : Form
    {
        public DataTable DataToDisplay { get; set; }

        public Form2()
        {
            InitializeComponent();
            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (DataToDisplay != null)
            {
                // Llenar los ComboBoxes con los nombres de las columnas
                FiltroX.Items.Clear();
                FiltroY.Items.Clear();
                foreach (DataColumn column in DataToDisplay.Columns)
                {
                    FiltroX.Items.Add(column.ColumnName);
                    FiltroY.Items.Add(column.ColumnName);
                }

                // Seleccionar valores predeterminados
                if (FiltroX.Items.Count > 0) FiltroX.SelectedIndex = 0;
                if (FiltroY.Items.Count > 0) FiltroY.SelectedIndex = 0;

                // Generar gráficos con los datos recibidos
                GenerarGraficos(DataToDisplay);
            }
            else
            {
                MessageBox.Show("No hay datos para mostrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        //Aun no funciona bien 
        private void GenerarGraficos(DataTable dataTable)
        {
            // Limpiar gráficos anteriores
            this.Controls.OfType<Chart>().ToList().ForEach(chart => this.Controls.Remove(chart));

            string selectedColumnX = FiltroX.SelectedItem?.ToString();
            string selectedColumnY = FiltroY.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedColumnX) || string.IsNullOrEmpty(selectedColumnY))
            {
                MessageBox.Show("Por favor, seleccione las columnas para X e Y.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Agrupar y contar los datos
            var groupedData = dataTable.AsEnumerable()
                .GroupBy(row => row.Field<string>(selectedColumnX))
                .Select(group => new { Key = group.Key, Count = group.Count() })
                .ToList();

            Chart chartControl = new Chart();
            chartControl.Dock = DockStyle.Top;
            chartControl.Height = 500;
            chartControl.ChartAreas.Add(new ChartArea());

            Series series = new Series
            {
                Name = selectedColumnY,
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Bar
            };

            chartControl.Series.Add(series);

            foreach (var item in groupedData)
            {
                series.Points.AddXY(item.Key, item.Count);
            }

            this.Controls.Add(chartControl);
        }

        //Funciona mal
        private void btnActualizarGrafico_Click(object sender, EventArgs e)
        {
            if (DataToDisplay != null)
            {
                GenerarGraficos(DataToDisplay);
            }
            else
            {
                MessageBox.Show("No hay datos para mostrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Espacio para agregar los filtros

    }
}
