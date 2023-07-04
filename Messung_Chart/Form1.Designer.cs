
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.connect_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_main)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_main
            // 
            this.chart_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_main.ChartAreas.Add(chartArea1);
            this.chart_main.Location = new System.Drawing.Point(183, 9);
            this.chart_main.MinimumSize = new System.Drawing.Size(480, 320);
            this.chart_main.Name = "chart_main";
            this.chart_main.Size = new System.Drawing.Size(805, 436);
            this.chart_main.TabIndex = 0;
            this.chart_main.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datum:";
            // 
            // datum
            // 
            this.datum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.datum.FormattingEnabled = true;
            this.datum.Location = new System.Drawing.Point(56, 39);
            this.datum.Name = "datum";
            this.datum.Size = new System.Drawing.Size(121, 21);
            this.datum.TabIndex = 2;
            this.datum.SelectedIndexChanged += new System.EventHandler(this.datum_SelectedIndexChanged);
            // 
            // fuehler_list
            // 
            this.fuehler_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fuehler_list.CheckOnClick = true;
            this.fuehler_list.FormattingEnabled = true;
            this.fuehler_list.Location = new System.Drawing.Point(12, 66);
            this.fuehler_list.MinimumSize = new System.Drawing.Size(0, 19);
            this.fuehler_list.Name = "fuehler_list";
            this.fuehler_list.Size = new System.Drawing.Size(165, 379);
            this.fuehler_list.TabIndex = 3;
            this.fuehler_list.SelectedIndexChanged += new System.EventHandler(this.fuehler_list_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 1);
            this.panel1.TabIndex = 4;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(12, 9);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(165, 23);
            this.connect_button.TabIndex = 5;
            this.connect_button.Text = "Verbinden";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1000, 456);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.panel1);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button connect_button;
    }
}

