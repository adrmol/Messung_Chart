
namespace Messung_Chart
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart_main = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.datum = new System.Windows.Forms.ComboBox();
            this.fuehler_list = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_main)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_main
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_main.ChartAreas.Add(chartArea1);
            this.chart_main.Location = new System.Drawing.Point(12, 12);
            this.chart_main.Name = "chart_main";
            this.chart_main.Size = new System.Drawing.Size(776, 426);
            this.chart_main.TabIndex = 0;
            this.chart_main.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(820, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datum:";
            // 
            // datum
            // 
            this.datum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.datum.FormattingEnabled = true;
            this.datum.Location = new System.Drawing.Point(867, 12);
            this.datum.Name = "datum";
            this.datum.Size = new System.Drawing.Size(121, 21);
            this.datum.TabIndex = 2;
            this.datum.SelectedIndexChanged += new System.EventHandler(this.datum_SelectedIndexChanged);
            // 
            // fuehler_list
            // 
            this.fuehler_list.CheckOnClick = true;
            this.fuehler_list.FormattingEnabled = true;
            this.fuehler_list.Location = new System.Drawing.Point(823, 39);
            this.fuehler_list.Name = "fuehler_list";
            this.fuehler_list.Size = new System.Drawing.Size(165, 394);
            this.fuehler_list.TabIndex = 3;
            this.fuehler_list.SelectedIndexChanged += new System.EventHandler(this.fuehler_list_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.fuehler_list);
            this.Controls.Add(this.datum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart_main);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox datum;
        private System.Windows.Forms.CheckedListBox fuehler_list;
    }
}

