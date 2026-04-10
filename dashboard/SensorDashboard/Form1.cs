using System.Data;
using Microsoft.Data.SqlClient;
using ScottPlot;
using System.Linq;

namespace SensorDashboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cmbMachine.Items.AddRange(new[] { "machine_1", "machine_2", "machine_3" });
            cmbSensor.Items.AddRange(new[] { "temperature", "pressure", "vibration", "humidity" });
            cmbMachine.SelectedIndex = 0;
            cmbSensor.SelectedIndex = 0;

            cmbMachine.SelectedIndexChanged += (s, e) => LoadChart();
            cmbSensor.SelectedIndexChanged += (s, e) => LoadChart();

            LoadLiveReadings();
            LoadAnomalyAlerts();
            LoadSummary();
            LoadChart();

            refreshTimer.Start();
        }

        private const string ConnStr = "Server=localhost;Database=SensorData;Trusted_Connection=True;TrustServerCertificate=True;";

        private void LoadLiveReadings()
        {
            using var conn = new SqlConnection(ConnStr);
            conn.Open();

            string sql = @"
                SELECT machine_id, sensor, value, unit, timestamp
                FROM sensor_readings
                WHERE timestamp >= DATEADD(minute, -1, GETUTCDATE())
                ORDER BY timestamp DESC";

            using var adapter = new SqlDataAdapter(sql, conn);
            var table = new DataTable();
            adapter.Fill(table);

            dgvLiveReadings.DataSource = table;
        }

        private void LoadAnomalyAlerts()
        {
            using var conn = new SqlConnection(ConnStr);
            conn.Open();

            string sql = @"
                SELECT machine_id, sensor, value, unit, timestamp
                FROM sensor_readings
                WHERE anomaly = 1
                ORDER BY timestamp DESC";

            using var adapter = new SqlDataAdapter( sql, conn);
            var table = new DataTable();
            adapter.Fill(table);

            dgvAnomalyAlerts.DataSource = table;

            foreach (DataGridViewRow row in dgvAnomalyAlerts.Rows)
            {
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        private void LoadSummary()
        {
            using var conn = new SqlConnection(ConnStr);
            conn.Open();

            string sql = @"
                SELECT machine_id, sensor, unit,
                       MIN(value)   AS min_value,
                       MAX(value)   AS max_value,
                       AVG(value)   AS avg_value,
                       COUNT(*)     AS total_readings,
                       SUM(CAST(anomaly as INT)) AS anomaly_count
                FROM sensor_readings
                GROUP BY machine_id, sensor, unit
                ORDER BY machine_id, sensor";

            using var adapter = new SqlDataAdapter(sql, conn);
            var table = new DataTable();
            adapter.Fill(table);

            dgvSummary.DataSource = table;
        }

        private void LoadChart()
        {
            string machine = cmbMachine.SelectedItem?.ToString() ?? "machine_1";
            string sensor = cmbSensor.SelectedItem?.ToString() ?? "temperature";

            using var conn = new SqlConnection(ConnStr);
            conn.Open();

            string sql = @"
                SELECT TOP 50 value, timestamp
                FROM sensor_readings
                WHERE machine_id = @machine AND sensor = @sensor
                ORDER BY timestamp DESC";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@machine", machine);
            cmd.Parameters.AddWithValue("@sensor", sensor);

            var values = new List<double>();
            var labels = new List<DateTime>();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                values.Add((double)reader.GetDecimal(0));
                labels.Add(reader.GetDateTime(1));
            }

            values.Reverse();
            labels.Reverse();

            formsPlot1.Plot.Clear();
            var scatter = formsPlot1.Plot.Add.Scatter(
                labels.Select(d => d.ToOADate()).ToArray(),
                values.ToArray()
                );
            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            formsPlot1.Plot.Title($"{machine} - {sensor}");
            formsPlot1.Refresh();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            LoadLiveReadings();
            LoadAnomalyAlerts();
            LoadSummary();
            LoadChart();
        }
    }
}
