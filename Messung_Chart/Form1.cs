using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Messung_Chart
{
    struct messwerte
    {
        public DateTime messzeit;
        public float temperatur;
    }

    public partial class Form1 : Form
    {
        MySqlConnection connection;
        Series series;
        public Form1()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=messwerte;Uid=root;";

            connection = new MySqlConnection(connectionString);

            connection.Open();

            string query = "SELECT DISTINCT Date(datum) AS datum FROM messungen;";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                var daten = new List<string>();
                while (reader.Read())
                {
                    datum.Items.Add(reader["datum"].ToString().Substring(0, 10));
                }
            }

            series = new Series();
            series.ChartType = SeriesChartType.Line;  // Diagrammtyp auf Linie setzen
            chart_main.Series.Add(series);

        }

        private void datum_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT temperaturfuehler FROM messungen WHERE Date(datum) = @datum;";
            DateTime.TryParse(datum.SelectedItem.ToString(), out var selected_datum);
            string mysql_datum = selected_datum.ToString("yyyy-MM-dd");
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@datum", mysql_datum);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                var daten = new List<string>();
                while (reader.Read())
                {
                    string tf = reader["temperaturfuehler"].ToString();

                    if (!fuehler_list.Items.Contains(tf))
                    {
                        fuehler_list.Items.Add(tf);
                    }
                }
            }

            update_chart_main();

        }

        private void fuehler_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_chart_main();
        }

        private void update_chart_main()
        {

            //foreach(var m in messwerte)
            //{
            //    series.Points.AddXY(m.Item2, m.Item3);
            //}

            // Datenpunkte hinzufügen
            //series.Points.AddXY(1, 2);  // (x=1, y=2)
            //series.Points.AddXY(2, 4);  // (x=2, y=4)
            //series.Points.AddXY(3, 1);  // (x=3, y=1)
            //series.Points.AddXY(4, 7);  // (x=4, y=7)
        }
    }
}
