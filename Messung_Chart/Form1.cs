﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Messung_Chart
{
    public partial class Form1 : Form
    {
        float legendHeight;
        MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            addChartArea();
            connect();
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
            scale();

            foreach (var tf_obj in fuehler_list.CheckedItems)
            {
                Series series1 = new Series();
                series1.ChartType = SeriesChartType.Line;  // Diagrammtyp auf Linie setzen
                chart_main.Series.Add(series1);
                series1.Color = allColors[fuehler_list.Items.IndexOf(tf_obj)];

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
                        float.TryParse(reader["temperatur"].ToString(), out var t);
                        series1.Points.AddXY(d, t);
                    }
                }
            }
            chart_main.Legends["Legend1"].Position.Auto = true;
            legendHeight = chart_main.Legends["Legend1"].Position.Height;
        }


        private void connect()
        {
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
            chart_main.Legends.Add(new Legend("Legend1"));
            Legend legend = chart_main.Legends["Legend1"];

            legend.Position.Width = 20;
            legend.Position.X = 80;
            legend.Position.Y = 10;
            legend.Position.Height = legendHeight;
            legend.BackColor = Color.Transparent;

            // Set the titles of the X and Y axes
            chart_main.ChartAreas[0].AxisX.Title = "Uhrzeit";
            chart_main.ChartAreas[0].AxisY.Title = "Temperatur in °C";
            this.Text = "Messwerte";
        }

        private void scale()
        {
            // Create a new series and add data points to it
            Series series = new Series("MySeries");
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Transparent;
            series.LegendText = " ";

            DateTime.TryParse(datum.SelectedItem.ToString(), out var d);

            for (int i = 0; i < 24; i++)
            {
                // Adding data points for every hour; replace these with your actual data
                series.Points.AddXY(new DateTime(d.Year, d.Month, d.Day, i, 0, 0), i);
            }

            chart_main.Series.Add(series);

            // Configure the X-axis to show times of day in 4-hour increments
            ChartArea area = chart_main.ChartAreas[0];
            area.AxisX.LabelStyle.Format = "HH:mm";
            area.AxisX.Minimum = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0).ToOADate();
            area.AxisX.Maximum = new DateTime(d.Year, d.Month, d.Day + 1, 0, 0, 0).ToOADate();
            area.AxisX.IntervalType = DateTimeIntervalType.Hours;
            area.AxisX.Interval = 4;  // set the interval to 4 hours
        }

        private void addChartArea()
        {
            ChartArea area = new ChartArea("ChartArea1");
            chart_main.ChartAreas.Add(area);
            area.Position = new ElementPosition(0, 0, 80, 100);
        }
    }
}
