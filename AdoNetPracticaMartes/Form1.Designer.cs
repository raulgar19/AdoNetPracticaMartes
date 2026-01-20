namespace AdoNetPracticaMartes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            cmbHospitales = new ComboBox();
            lstEmpleados = new ListBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtSuma = new TextBox();
            txtMedia = new TextBox();
            txtPersonas = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Hospitales";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 9);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 1;
            label2.Text = "Empleados Hospital";
            // 
            // cmbHospitales
            // 
            cmbHospitales.FormattingEnabled = true;
            cmbHospitales.Location = new Point(12, 27);
            cmbHospitales.Name = "cmbHospitales";
            cmbHospitales.Size = new Size(121, 23);
            cmbHospitales.TabIndex = 2;
            cmbHospitales.SelectedIndexChanged += cmbHospitales_SelectedIndexChanged;
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(162, 27);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(227, 214);
            lstEmpleados.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 134);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 4;
            label3.Text = "Media Salarial";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 90);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 5;
            label4.Text = "Suma Salarial";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 178);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 6;
            label5.Text = "Personas";
            // 
            // txtSuma
            // 
            txtSuma.Location = new Point(12, 108);
            txtSuma.Name = "txtSuma";
            txtSuma.Size = new Size(100, 23);
            txtSuma.TabIndex = 7;
            // 
            // txtMedia
            // 
            txtMedia.Location = new Point(12, 152);
            txtMedia.Name = "txtMedia";
            txtMedia.Size = new Size(100, 23);
            txtMedia.TabIndex = 8;
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(12, 196);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(100, 23);
            txtPersonas.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 286);
            Controls.Add(txtPersonas);
            Controls.Add(txtMedia);
            Controls.Add(txtSuma);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lstEmpleados);
            Controls.Add(cmbHospitales);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbHospitales;
        private ListBox lstEmpleados;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtSuma;
        private TextBox txtMedia;
        private TextBox txtPersonas;
    }
}
