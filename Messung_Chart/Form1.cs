using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Messung_Chart
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connect();
        }

        private void datum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT DISTINCT temperaturfuehler FROM messungen WHERE Date(datum) = @datum;";
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
            }
            catch
            {
                MessageBox.Show("Fehler in der Datenbank!");
                connect();
            }
            update_chart_main();
        }

        private void fuehler_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_chart_main();
        }

        private void update_chart_main()
        {
            // 10 colors in System.Drawing.Color
            Color[] allColors = new System.Drawing.Color[]
            {
            System.Drawing.Color.Red,
            System.Drawing.Color.Blue,
            System.Drawing.Color.Green,
            System.Drawing.Color.Orange,
            System.Drawing.Color.Purple,
            System.Drawing.Color.Brown,
            System.Drawing.Color.Yellow,
            System.Drawing.Color.Black,
            System.Drawing.Color.Olive,
            System.Drawing.Color.Pink
            };

            int colorNumber = 0;
            chart_main.Series.Clear();
            try
            {
                foreach (var tf_obj in fuehler_list.CheckedItems)
                {
                    Legend legend = chart_main.Legends["Legend1"];
                    legend.CustomItems.Clear();

                    Series series1 = new Series();
                    series1.ChartType = SeriesChartType.Line;  // Diagrammtyp auf Linie setzen
                    chart_main.Series.Add(series1);
                    series1.Color = allColors[colorNumber];


                    colorNumber++;

                    string tf = tf_obj.ToString();
                    series1.LegendText = tf;

                    string query = "SELECT temperaturfuehler, datum, temperatur FROM messungen WHERE temperaturfuehler LIKE @tf;";
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@tf", tf);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        for (int i = 0; reader.Read(); i++)
                        {
                            DateTime.TryParse(reader["datum"].ToString(), out var d);
                            //var uhrzeit = d.TimeOfDay.TotalMilliseconds;
                            var uhrzeit = d.ToString("HH:mm:ss");
                            float.TryParse(reader["temperatur"].ToString(), out var t);
                            series1.Points.AddXY(uhrzeit, t);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Fehler in der Datenbank!");
            }
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void connect()
        {
            try
            {
                string connectionString = "Server=localhost;Database=messwerte;Uid=root;";
                connection = new MySqlConnection(connectionString);
                connection.Open();
                this.Text = "Verbunden mit Datenbank";
                try
                {
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
                }
                catch
                {
                    MessageBox.Show("Fehler in der Datenbank!");
                    connect();
                }



                chart_main.Legends.Add(new Legend("Legend1"));

                // Set the titles of the X and Y axes
                chart_main.ChartAreas[0].AxisX.Title = "Uhrzeit";
                chart_main.ChartAreas[0].AxisY.Title = "Temperatur in °C";

            }
            catch
            {
                MessageBox.Show("Keiner Verbindung zur Datenbank!");
            }
        }
    }
}
