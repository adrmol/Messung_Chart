using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Messung_Chart
{
    struct fuehler
    {
        public string fName;
        public List<messwerte> werteListe;
    }
    struct messwerte
    {
        public DateTime messzeit;
        public float temperatur;
    }

    public partial class Form1 : Form
    {
        MySqlConnection connection;
        Series series1;
        List<fuehler> fuehlerDaten;
        public Form1()
        {
            InitializeComponent();
            fuehlerDaten = new List<fuehler>();

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

            chart_main.Legends.Add(new Legend("Legende1"));
            //series = new Series();
            //series.ChartType = SeriesChartType.Line;  // Diagrammtyp auf Linie setzen
            //chart_main.Series.Add(series);

        }

        private void datum_SelectedIndexChanged(object sender, EventArgs e)
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

            update_chart_main();

        }

        private void fuehler_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_chart_main();
        }

        private void update_chart_main()
        {
            // Get all colors in the System.Drawing.Color namespace
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
            //series.Points.Clear();

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

                fuehlerDaten.Add(new fuehler {fName = tf, werteListe = new List<messwerte>() });

                string query = "SELECT temperaturfuehler, datum, temperatur FROM messungen WHERE temperaturfuehler LIKE @tf;";
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@tf", tf);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    for (int i = 0; reader.Read(); i++)
                    {
                        DateTime.TryParse(reader["datum"].ToString(), out var d);
                        float.TryParse(reader["temperatur"].ToString(), out var t);
                        series1.Points.AddXY(d, t);

                        //series1.Points.AddXY(1, 2);  // (x=1, y=2)
                        //series1.Points.AddXY(2, 4);  // (x=2, y=4)
                        //series1.Points.AddXY(3, 1);  // (x=3, y=1)
                        //series1.Points.AddXY(4, 7);  // (x=4, y=7)

                        //fuehlerDaten[i].werteListe.Add(new messwerte {messzeit = d, temperatur = t});
                    }
                }

                foreach (Series series in chart_main.Series)
                {
                    // Create a legend item with the series name and color
                    LegendItem legendItem = new LegendItem();
                    legendItem.Name = tf;
                    legendItem.Color = series.Color;

                    // Add the legend item to the legend
                    legend.CustomItems.Add(legendItem);
                }
            }
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
